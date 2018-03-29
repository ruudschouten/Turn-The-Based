using Tiles;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace {
    public class BasePanel : Tile, IPointerClickHandler {
        public BasePanelUIManager UiManager;
        [HideInInspector]
        public TurnManager TurnManager;
        
        public void OnPointerClick(PointerEventData eventData) {
            UiManager.ShowBaseUi(TurnManager);
        }
    }
}