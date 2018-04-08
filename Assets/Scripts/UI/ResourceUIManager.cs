using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class ResourceUIManager : MonoBehaviour {
    public GameObject PanelParent;
    public GameObject ResourcePanel;

    public bool ShowButtons;

    private GameObject _newPanel;

    private int _panelTotalHeight = 150;

    public void SetupPanel(Resource resource) {
        CreateResourcePanel(resource);
        UpdateUI(resource);
    }
    
    public void AddListener(Resource resource) {
        UnityAction action = () => UpdateUI(resource);
        resource.OnValueChanged.AddListener(action);
    }

    private void CreateResourcePanel(Resource resource) {
        _newPanel = Instantiate(ResourcePanel, PanelParent.transform);
        _newPanel.name = string.Format("{0} UI Element", resource.Name);
        _newPanel.transform.GetChild(0).GetComponent<Text>().text = resource.Name;
        _newPanel.transform.GetChild(1).GetComponent<Text>().text = resource.Amount.ToString();
        if (ShowButtons) {
            _newPanel.transform.GetChild(2).GetComponent<Button>().onClick
                .AddListener(() => resource.ChangeAmount(5));
            _newPanel.transform.GetChild(3).GetComponent<Button>().onClick
                .AddListener(() => resource.ChangeAmount(-5));
        }
        else {
            _newPanel.transform.GetChild(2).gameObject.SetActive(false);
            _newPanel.transform.GetChild(3).gameObject.SetActive(false);
        }

        _newPanel.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void ChangeValues(Resource resource) {
        if (_newPanel == null) return;
        _newPanel.transform.GetChild(0).GetComponent<Text>().text = resource.Name;
        _newPanel.transform.GetChild(1).GetComponent<Text>().text = resource.Amount.ToString();
    }


    private void UpdateUI(Resource resource) {
        var panel = PanelParent.transform.Find(string.Format("{0} UI Element", resource.Name));
        panel.transform.Find("ResourceName").GetComponent<Text>().text = resource.Name;
        panel.transform.Find("ResourceValue").GetComponent<Text>().text = resource.Amount.ToString();
    }

    public void Hide() {
        _newPanel.SetActive(false);
    }
}