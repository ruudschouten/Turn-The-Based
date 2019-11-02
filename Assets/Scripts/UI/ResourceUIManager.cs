using UnityEngine;

namespace UI
{
    public class ResourceUIManager : MonoBehaviour {

        [SerializeField] private ResourcePanelDictionary panels;

        public void ChangeValues(Resource resource)
        {
            if (panels.ContainsKey(resource))
            {
                panels[resource].ChangeValues(resource);
            }
            else
            {
                Debug.LogError("Resource couldn't be found in panels", resource);
            }
        }

        public void Hide() {
            foreach (var panel in panels)
            {
                panel.Key.gameObject.SetActive(false);
            }
        }
    }
}