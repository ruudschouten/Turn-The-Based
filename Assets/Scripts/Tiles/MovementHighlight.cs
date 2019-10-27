using Unit;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementHighlight : MonoBehaviour, IPointerClickHandler {
    public UIManager UiManager;

    public void OnPointerClick(PointerEventData eventData) {
        if (UiManager == null) UiManager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();
        Transform parent = transform.parent;
        var unit = parent.GetComponentInChildren<Character>();
        if (unit == null) UiManager.UnitUiManager.MoveToClick(parent);
        else {
            Debug.Log("Another unit was already on the tile");
        }
    }
}