using UnityEngine;

public class UIManager : MonoBehaviour {
    public BasePanelUIManager BasePanelUiManager;
    public ResourceUIManager ResourceUiManager;
    public UnitUIManager UnitUiManager;
    public GameOverUIManager GameOverUiManager;

    public void ShowForPlayer(Player player) {
        ResourceUiManager.ChangeValues(player.Gold);
    }

    public void HideAll() {
        HideUnitUI();
        HideResourceUI();
        HideBasePanelUI();
    }

    public void Hide(bool unit, bool basePanel, bool resource) {
        if (unit) HideUnitUI();
        if (basePanel) HideBasePanelUI();
        if (resource) HideResourceUI();
    }

    public void HideUnitUI() {
        if (UnitUiManager != null) UnitUiManager.Hide();
    }

    public void HideResourceUI() {
        if (ResourceUiManager != null) ResourceUiManager.Hide();
    }

    public void HideBasePanelUI() {
        if (BasePanelUiManager != null) BasePanelUiManager.Hide();
    }

    public void HideGameOverPanelUI() {
        if (GameOverUiManager != null) GameOverUiManager.Hide();
    }
}