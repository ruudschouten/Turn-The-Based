using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class ResourceUIManager : MonoBehaviour {
    public GameObject PanelParent;
    public GameObject ResourcePanel;

    public List<Resource> Resources;
    public bool ShowButtons;

    private GameObject newPanel;   
    
    private const int PanelHeightPerResource = 35;
    private int _panelTotalHeight = 150;
    private int _index;

    public void Awake() {
        foreach (var resource in Resources) {
            UnityAction action = () => UpdateUI(resource);
            resource.OnValueChanged.AddListener(action);
            CreateResourcePanel(resource);
            _index++;
            UpdateUI(resource);
        }
    }

    private void CreateResourcePanel(Resource resource) {
        newPanel = Instantiate(ResourcePanel, PanelParent.transform);
        newPanel.name = string.Format("{0} UI Element", resource.Name);
        newPanel.transform.GetChild(0).GetComponent<Text>().text = resource.Name;
        newPanel.transform.GetChild(1).GetComponent<Text>().text = resource.Amount.ToString();
        if (ShowButtons) {
            newPanel.transform.GetChild(2).GetComponent<Button>().onClick
                .AddListener(() => resource.ChangeAmount(5));
            newPanel.transform.GetChild(3).GetComponent<Button>().onClick
                .AddListener(() => resource.ChangeAmount(-5));
        }
        else {
            newPanel.transform.GetChild(2).gameObject.SetActive(false);
            newPanel.transform.GetChild(3).gameObject.SetActive(false);
        }

        var newY = _index * PanelHeightPerResource;
        newPanel.transform.localPosition = new Vector3(0, -newY, 0);
    }

    public void ChangeValues(Resource resource) {
        newPanel.transform.GetChild(0).GetComponent<Text>().text = resource.Name;
        newPanel.transform.GetChild(1).GetComponent<Text>().text = resource.Amount.ToString();
    }


    private void UpdateUI(Resource resource) {
        var panel = PanelParent.transform.Find(string.Format("{0} UI Element", resource.Name));
        panel.transform.Find("ResourceName").GetComponent<Text>().text = resource.Name;
        panel.transform.Find("ResourceValue").GetComponent<Text>().text = resource.Amount.ToString();
    }

    public void Hide() {
        newPanel.SetActive(false);
    }
}