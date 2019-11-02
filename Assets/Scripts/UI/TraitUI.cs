using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TraitUI : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private Text traitName;
        [SerializeField] private Text description;

        public Text Name => traitName;
        public Text Description => description;

        public void SetHeight(float height)
        {
            var pos = rectTransform.anchoredPosition3D;
            pos.y = height;
            rectTransform.anchoredPosition3D = pos;
        }
    }
}