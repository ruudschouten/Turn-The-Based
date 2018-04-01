using UnityEngine;
using UnityEngine.EventSystems;

namespace Tiles {
    public class Highlight : MonoBehaviour, IPointerClickHandler {
        public UIManager UiManager;
        
        public void OnPointerClick(PointerEventData eventData) {
            if (UiManager == null) UiManager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();
            UiManager.UnitUiManager.MoveToClick(transform.parent);
        }
    }
}