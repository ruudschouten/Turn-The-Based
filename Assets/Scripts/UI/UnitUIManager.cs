using Assets.Scripts.Unit;
using UnityEngine.UI;

public class UnitUIManager {
    public Text NameText;
    public Text ClassText;
    public Slider HealthSlider;
    public Slider MagicSlider;
    public Text ResourceText; //This is HP and SP
    public Text StatsText; //STR, INT, RES, PRE, AGI
    public Text MoveValue;
    public Text JumpValue;
    public Text FireValue;
    public Text WindValue;
    public Text IceValue;

    public void ShowStats(Character unit) {
        NameText.text = unit.Name;
        ClassText.text = unit.Type.ToString();
        HealthSlider.value = GetPercentage(unit.Stats.Health, unit.Stats.MaxHealth);
        MagicSlider.value = GetPercentage(unit.Stats.Magic, unit.Stats.MaxMagic);
        ResourceText.text = unit.Stats.PrintResources();
        StatsText.text = unit.Stats.PrintBaseStats();
        MoveValue.text = unit.Stats.Move.ToString();
        JumpValue.text = unit.Stats.Jump.ToString();
        FireValue.text = unit.Stats.FireAttunement.ToString();
        WindValue.text = unit.Stats.WindAttunement.ToString();
        IceValue.text = unit.Stats.IceAttunement.ToString();
    }

    private float GetPercentage(int current, int max) {
        return ((float)current / max) * 100;
    }
}