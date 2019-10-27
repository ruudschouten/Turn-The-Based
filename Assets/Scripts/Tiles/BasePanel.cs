using Unit;
using UnityEngine;
using UnityEngine.EventSystems;

public class BasePanel : MonoBehaviour, IPointerClickHandler {
    public UIManager UiManager;
    [HideInInspector] public TurnManager TurnManager;
    [HideInInspector] public Ownable Ownable;

    public int Width;
    public int Height;

    public void OnPointerClick(PointerEventData eventData) {
        if (transform.childCount > 1) {
            //Unit in base
            Character unit = transform.GetChild(1).GetComponent<Character>();
            if (TurnManager.CurrentPlayer == Ownable.GetOwner()) {
                UiManager.UnitUiManager.ShowUI(unit);
                UiManager.UnitUiManager.ShowActionUI(unit);
            }
        }
        else {
            UiManager.Hide(true, true, false);
            if (TurnManager.CurrentPlayer == Ownable.GetOwner()) UiManager.BasePanelUiManager.ShowBaseUi();
            else {
                Debug.Log("Not my owner");
            }
        }
    }
}