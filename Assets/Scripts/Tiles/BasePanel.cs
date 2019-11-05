using Turn;
using UI.Managers;
using Unit;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tiles
{
    public class BasePanel : HighlightableTile, IPointerClickHandler 
    {
        [SerializeField] private UIManager uiManager;
        [SerializeField] private Ownable ownable;
        [HideInInspector] [SerializeField] private TurnManager turnManager;

        public UIManager UIManager
        {
            get => uiManager;
            set => uiManager = value;
        }

        public TurnManager TurnManager
        {
            get => turnManager;
            set => turnManager = value;
        }

        public Ownable Ownable
        {
            get => ownable;
            set => ownable = value;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (transform.childCount > 1)
            {
                //Unit in base
                var unit = transform.GetChild(1).GetComponent<Character>();
                if (turnManager.CurrentPlayer == ownable.GetOwner())
                {
                    uiManager.UnitUIManager.Show(unit);
                    uiManager.UnitUIManager.ActionUI.Show(unit);
                }
            }
            else
            {
                uiManager.Hide(true, true);
                if (turnManager.CurrentPlayer == ownable.GetOwner())
                {
                    uiManager.BasePanelUIManager.ShowBaseUi();
                }
                else
                {
                    uiManager.ShowMessage("This isn't my base");
                }
            }
        }
    }
}