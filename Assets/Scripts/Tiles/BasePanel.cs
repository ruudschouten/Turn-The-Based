using Tiles;
using UI;
using UnityEngine.EventSystems;

namespace DefaultNamespace {
    public class BasePanel : Tile, IPointerClickHandler {
        public BasePanelUIManager UiManager;
        public Player player;
        
        public void OnPointerClick(PointerEventData eventData) {
            UiManager.ShowUnitList(player.Units);
        }
    }
}