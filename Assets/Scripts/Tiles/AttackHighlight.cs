using UI;
using UI.Managers;
using Unit;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace Tiles
{
    public class AttackHighlight : MonoBehaviour, IPointerClickHandler
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
            if (unit != null)
            {
                uiManager.UnitUIManager.AttackOnClick(parent);
            }
            else
            {
                uiManager.ShowMessage("No target found");
            }

            uiManager.UnitUIManager.HideAttackRange();
        }
    }
}