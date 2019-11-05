using TMPro;
using UnityEngine;

namespace UI
{
    public class TraitUI : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private TMP_Text traitName;
        [SerializeField] private TMP_Text description;

        public TMP_Text Name => traitName;
        public TMP_Text Description => description;

        public void SetHeight(float height)
        {
            var pos = rectTransform.anchoredPosition3D;
            pos.y = height;
            rectTransform.anchoredPosition3D = pos;
        }
    }
}