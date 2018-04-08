using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler {
    public int Width;
    public int Height;
    public int X;
    public int Y;

    public Vector3 Position;

    public UIManager UiManager;

    public Character GetUnit() {
        return GetComponentInChildren<Character>();
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (UiManager == null) UiManager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();
        UiManager.Hide(true, true, false);
        if (transform.childCount > 1) {
            Character unit = GetUnit();
            if (unit != null) {
                unit.OnPointerClick(null);
            }
        }
    }
}