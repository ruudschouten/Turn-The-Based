using UI;
using UnityEngine;

public class UIManager : MonoBehaviour {
    public BasePanelUIManager BasePanelUiManager;
    public ResourceUIManager ResourceUiManager;
    public SkillUIManager SkillUiManager;
    public TurnManagerUIManager TurnManagerUiManager;
    public UnitUIManager UnitUiManager;

    public void ShowForPlayer(Player player) {
        ResourceUiManager.ChangeValues(player.Gold);
    }

    public void HideAll() {
        HideUnitUI();
        HideSkillUI();
        HideResourceUI();
        HideBasePanelUI();
        HideTurnManagerUI();
    }

    public void Hide(bool unit, bool skill, bool basePanel, bool turnManager) {
        if(unit) HideUnitUI();
        if(skill) HideSkillUI();
        if(basePanel) HideBasePanelUI();
        if(turnManager) HideTurnManagerUI();
    }
    
    public void Hide(bool unit, bool skill, bool basePanel, bool turnManager, bool resource) {
        if(unit) HideUnitUI();
        if(skill) HideSkillUI();
        if(basePanel) HideBasePanelUI();
        if(turnManager) HideTurnManagerUI();
        if(resource) HideResourceUI();
    }
    
    public void HideUnitUI() {
        if (UnitUiManager != null) UnitUiManager.Hide();
    }

    public void HideSkillUI() {
        if (SkillUiManager != null) SkillUiManager.Hide();
    }

    public void HideResourceUI() {
        if (ResourceUiManager != null) ResourceUiManager.Hide();
    }

    public void HideBasePanelUI() {
        if (BasePanelUiManager != null) BasePanelUiManager.Hide();
    }

    public void HideTurnManagerUI() {
        if (TurnManagerUiManager != null) TurnManagerUiManager.Hide();
    }
}