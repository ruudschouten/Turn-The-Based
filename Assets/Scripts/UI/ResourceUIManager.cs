using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Resource {
    public class ResourceUIManager : MonoBehaviour {
        public GameObject PanelParent;
        public GameObject ResourcePanel;

        public List<Resource> Resources;

        private const int PanelHeightPerResource = 35;
        private int _panelTotalHeight = 150;
        private int _index;

        public void Awake() {
            foreach (var resource in Resources) {
                UnityAction action = () => UpdateUI(resource);
                resource.OnValueChanged.AddListener(action);
                CreateResourcePanel(resource);
                _index++;
            }
        }

        private void CreateResourcePanel(Resource resource) {
            var newPanel = Instantiate(ResourcePanel, PanelParent.transform);
            newPanel.name = string.Format("{0} UI Element", resource.Name);
            newPanel.transform.GetChild(0).GetComponent<Text>().text = resource.Name;
            newPanel.transform.GetChild(1).GetComponent<Text>().text = resource.Amount.ToString();
            newPanel.transform.GetChild(2).GetComponent<Button>().onClick
                .AddListener(() => resource.ChangeAmount(5));
            newPanel.transform.GetChild(3).GetComponent<Button>().onClick
                .AddListener(() => resource.ChangeAmount(-5));
            var newY = _index * PanelHeightPerResource;
            newPanel.transform.localPosition = new Vector3(0, -newY, 0);
        }


        private void UpdateUI(Resource resource) {
            var panel = PanelParent.transform.Find(string.Format("{0} UI Element", resource.Name));
            panel.transform.Find("ResourceName").GetComponent<Text>().text = resource.Name;
            panel.transform.Find("ResourceValue").GetComponent<Text>().text = resource.Amount.ToString();
        }
    }
}