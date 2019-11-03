using Unit;
using UnityEngine;

namespace UI.Managers
{
    public class UnitUIManager : MonoBehaviour
    {
        [SerializeField] private GameObject container;
        [SerializeField] private UnitUI unitUI;
        [SerializeField] private TraitManager traitManager;
        [SerializeField] private ActionUI actionUI;

        public ActionUI ActionUI => actionUI;
        
        private Character _currentUnit;
        private UnitUI _currentStatPanel;

        public Character GetSelectedUnit()
        {
            return _currentUnit;
        }

        public void Awake()
        {
            _currentStatPanel = Instantiate(unitUI, container.transform);
            
            _currentStatPanel.gameObject.SetActive(false);
            traitManager.Hide();
        }

        private void ShowStats(Character unit)
        {
            actionUI.HideMovementRange();
            actionUI.HideAttackRange();
            
            _currentStatPanel.ShowStats(unit);
        }

        public void Hide()
        {
            HideStatPanel();
            
            actionUI.Reset();
            actionUI.HideMovementRange();
            actionUI.HideAttackRange();
            
            HideTraitPanel();
        }

        public void HideStatPanel()
        {
            _currentStatPanel.gameObject.SetActive(false);
        }

        public void HideTraitPanel()
        {
            traitManager.Clear();
        }

        public void Show(Character unit)
        {
            traitManager.Clear();
            
            _currentUnit = unit;
            _currentStatPanel.gameObject.SetActive(true);
            
            ShowStats(unit);
            
            traitManager.ShowTraits(unit);
        }
    }
}