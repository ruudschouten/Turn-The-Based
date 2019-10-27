using Unit;
using UnityEngine;
using UnityEngine.EventSystems;


public class AttackHighlight : MonoBehaviour, IPointerClickHandler {
    public UIManager UiManager;

    public void OnPointerClick(PointerEventData eventData) {
        if (UiManager == null) UiManager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();
        Transform parent = transform.parent;
        var unit = parent.GetComponentInChildren<Character>();
        if (unit == null) {
            Debug.Log("No unit was on the tile");
        }
        else {
            UiManager.UnitUiManager.AttackOnClick(parent);
        }

        UiManager.UnitUiManager.HideAttackRange();
    }
}