using Turn;
using UI;
using UI.Managers;
using Unit;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace Tiles
{
    public class BasePanel : HighlightableTile, IPointerClickHandler 
    {
        [FormerlySerializedAs("UiManager")] [SerializeField] private UIManager uiManager;
        [FormerlySerializedAs("TurnManager")] [HideInInspector] [SerializeField] private TurnManager turnManager;
        [FormerlySerializedAs("Ownable")] [HideInInspector] [SerializeField] private Ownable ownable;

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