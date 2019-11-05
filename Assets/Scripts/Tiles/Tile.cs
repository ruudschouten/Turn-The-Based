using UI;
using UI.Managers;
using Unit;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tiles
{
    public class Tile : HighlightableTile, IPointerClickHandler
    {
        public int Width;
        public int Height;
        public int X;
        public int Y;

        public Vector3 Position;

        public UIManager UiManager;

        public Character GetUnit()
        {
            return GetComponentInChildren<Character>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (UiManager == null) UiManager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();
            UiManager.Hide(true, true);
            if (transform.childCount > 1)
            {
                Character unit = GetUnit();
                if (unit != null)
                {
                    unit.OnPointerClick(null);
                }
            }
        }
    }
}