using UI;
using UI.Managers;
using Unit;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tiles
{
    public class MovementHighlight : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private UIManager uiManager;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (uiManager == null)
            {
                uiManager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();
            }
            
            var parent = transform.parent;
            var unit = parent.GetComponentInChildren<Character>();
            if (unit == null)
            {
                uiManager.UnitUIManager.MoveToClick(parent);
            }
            else
            {
                uiManager.ShowMessage("This tile is occupied");
            }
        }
    }
}