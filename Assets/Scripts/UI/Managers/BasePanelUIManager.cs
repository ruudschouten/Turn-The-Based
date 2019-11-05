using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace UI.Managers
{
    public class BasePanelUIManager : MonoBehaviour 
    {
        [FormerlySerializedAs("BasePanel")] [SerializeField] private GameObject basePanel;

        [SerializeField] private CustomButton btnBuyNormal;
        [SerializeField] private CustomButton btnBuyMagic;
        [SerializeField] private CustomButton btnBuyRare;
        [SerializeField] private CustomButton btnClose;

        private void Awake()
        {
            btnClose.OnClickEvent.AddListener(Hide);
        }

        public void ShowBaseUi()
        {
            basePanel.SetActive(true);
        }

        public void Hide()
        {
            basePanel.SetActive(false);
        }

        public void SetBuyNormal(UnityAction evt)
        {
            btnBuyNormal.OnClickEvent.AddListener(evt);
        }

        public void SetBuyMagic(UnityAction evt)
        {
            btnBuyMagic.OnClickEvent.AddListener(evt);
        }

        public void SetBuyRare(UnityAction evt)
        {
            btnBuyRare.OnClickEvent.AddListener(evt);
        }

        public void SetButtonValues(int normal, int magic, int rare)
        {
            btnBuyNormal.SetText($"Normal ({normal})");
            btnBuyMagic.SetText($"Magic ({magic})");
            btnBuyRare.SetText($"Rare ({rare})");
        }
    }
}