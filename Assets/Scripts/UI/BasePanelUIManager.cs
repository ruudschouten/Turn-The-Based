using UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class BasePanelUIManager : MonoBehaviour {
    public GameObject BasePanel;

    [SerializeField] private CustomButton btnBuyNormal;
    [SerializeField] private CustomButton btnBuyMagic;
    [SerializeField] private CustomButton btnBuyRare;
    [SerializeField] private CustomButton btnClose;

    void Awake() {
        btnClose.OnClickEvent.AddListener(Hide);
    }

    public void ShowBaseUi() {
        BasePanel.SetActive(true);
    }

    public void Hide() {
        BasePanel.SetActive(false);
    }

    public void SetBuyNormal(UnityAction evt) {
        btnBuyNormal.OnClickEvent.AddListener(evt);
    }

    public void SetBuyMagic(UnityAction evt) {
        btnBuyMagic.OnClickEvent.AddListener(evt);
    }

    public void SetBuyRare(UnityAction evt) {
        btnBuyRare.OnClickEvent.AddListener(evt);
    }

    public void SetButtonValues(int normal, int magic, int rare) {
        btnBuyNormal.transform.GetChild(0).GetComponent<Text>().text = string.Format("Normal ({0})", normal);
        btnBuyMagic.transform.GetChild(0).GetComponent<Text>().text = string.Format("Magic ({0})", magic);
        btnBuyRare.transform.GetChild(0).GetComponent<Text>().text = string.Format("Rare ({0})", rare);
    }
}