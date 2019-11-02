using Turn;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private BasePanelUIManager basePanelUiManager;
        [SerializeField] private UnitUIManager unitUiManager;
        [SerializeField] private GameOverUIManager gameOverUiManager;
        [SerializeField] private MessageManager messageManager;
    
        public BasePanelUIManager BasePanelUIManager => basePanelUiManager;
        public UnitUIManager UnitUIManager => unitUiManager;
        public GameOverUIManager GameOverUIManager => gameOverUiManager;
        public MessageManager MessageManager => messageManager;

        public void ShowForPlayer(Player player)
        {
            player.ResourceUIManager.ChangeValues(player.Gold);
        }

        public void HideAll()
        {
            HideUnitUI();
            HideBasePanelUI();
        }

        public void Hide(bool unit, bool basePanel, bool resource)
        {
            if (unit)
            {
                HideUnitUI();
            }

            if (basePanel)
            {
                HideBasePanelUI();
            }
        }

        private void HideUnitUI()
        {
            if (unitUiManager != null)
            {
                unitUiManager.Hide();
            }
        }

        private void HideGameOverPanelUI()
        {
            if (gameOverUiManager != null)
            {
                gameOverUiManager.Hide();
            }
        }

        public void HideBasePanelUI()
        {
            if (basePanelUiManager != null)
            {
                basePanelUiManager.Hide();
            }
        }

        public void ShowMessage(string message)
        {
            messageManager.ShowMessage(message);
        }
    }
}