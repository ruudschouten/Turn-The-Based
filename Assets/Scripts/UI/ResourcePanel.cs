using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ResourcePanel : MonoBehaviour
    {
        [SerializeField] private RectTransform container;
        [SerializeField] private Text resourceName;
        [SerializeField] private Text value;
        [SerializeField] private Button addButton;
        [SerializeField] private Button removeButton;

        public RectTransform Container => container;
        public Text Name => resourceName;
        public Text Value => value;
        public Button AddButton => addButton;
        public Button RemoveButton => removeButton;

        public void ChangeValues(Resource resource)
        {
            Name.text = resource.Name;
            Value.text = resource.Amount.ToString();
        }
    }
}