using Assets.Scripts.Generators;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI {
    public class BasePanelUIManager : MonoBehaviour {
        public GameObject BasePanel;

//        private Player _currentPlayer;
        private Button _btnBuyNormal;
        private Button _btnBuyMagic;
        private Button _btnBuyRare;
        private Button _btnClose;

        void Awake() {
            _btnBuyNormal = BasePanel.transform.GetChild(0).GetComponent<Button>();
            _btnBuyMagic = BasePanel.transform.GetChild(1).GetComponent<Button>();
            _btnBuyRare = BasePanel.transform.GetChild(2).GetComponent<Button>();
            _btnClose = BasePanel.transform.GetChild(3).GetComponent<Button>();

            _btnClose.onClick.AddListener(Hide);
        }
        
        public void ShowBaseUi() {
//            _currentPlayer = turnManager.CurrentPlayer;
            BasePanel.SetActive(true);
        }

        public void Hide() {
            BasePanel.SetActive(false);
        }

        public void SetBuyNormal(UnityAction evt) {
            _btnBuyNormal.onClick.AddListener(evt);
        }

        public void SetBuyMagic(UnityAction evt) {
            _btnBuyMagic.onClick.AddListener(evt);
        }

        public void SetBuyRare(UnityAction evt) {
            _btnBuyRare.onClick.AddListener(evt);
        }
        
        public void SetButtonValues(int normal, int magic, int rare) {
            _btnBuyNormal.transform.GetChild(0).GetComponent<Text>().text = string.Format("Normal ({0})", normal);
            _btnBuyMagic.transform.GetChild(0).GetComponent<Text>().text = string.Format("Magic ({0})", magic);
            _btnBuyRare.transform.GetChild(0).GetComponent<Text>().text = string.Format("Rare ({0})", rare);
        }
    }
}