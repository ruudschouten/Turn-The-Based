using UnityEngine;
using UnityEngine.EventSystems;

namespace Tiles {
    public class Tile : MonoBehaviour, IPointerClickHandler {
        public int Width;
        public int Height;

        public UIManager UiManager;
        
        public void OnPointerClick(PointerEventData eventData) {
            if (UiManager == null) UiManager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();
            UiManager.Hide(true, true, true, true);
        }
    }
}