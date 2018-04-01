using Assets.Scripts.Unit;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tiles {
    public class Tile : MonoBehaviour, IPointerClickHandler {
        public int Width;
        public int Height;
        public int X;
        public int Y;

        public Vector3 Position;

        public UIManager UiManager;
        
        public void OnPointerClick(PointerEventData eventData) {
            if (UiManager == null) UiManager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();
            UiManager.Hide(true, true, true, true, false);
            if (transform.childCount > 1) {
                Character unit = GetComponentInChildren<Character>();
                unit.OnPointerClick(eventData);
            }
        }
    }
}