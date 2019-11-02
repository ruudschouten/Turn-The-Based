using Turn;
using UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private BasePanelUIManager basePanelUiManager;
    [SerializeField] private ResourceUIManager resourceUiManager;
    [SerializeField] private UnitUIManager unitUiManager;
    [SerializeField] private GameOverUIManager gameOverUiManager;
    [SerializeField] private MessageManager messageManager;
    
    public BasePanelUIManager BasePanelUIManager => basePanelUiManager;
    public ResourceUIManager ResourceUIManager => resourceUiManager;
    public UnitUIManager UnitUIManager => unitUiManager;
    public GameOverUIManager GameOverUIManager => gameOverUiManager;
    public MessageManager MessageManager => messageManager;

    public void ShowForPlayer(Player player)
    {
        resourceUiManager.ChangeValues(player.Gold);
    }

    public void HideAll()
    {
        HideUnitUI();
        HideResourceUI();
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

        if (resource)
        {
            HideResourceUI();
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

    private void HideResourceUI()
    {
        if (resourceUiManager != null)
        {
            resourceUiManager.Hide();
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