using Unit;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UnitUI : MonoBehaviour
    {
       [SerializeField] private Text nameText;
       [SerializeField] private Text classText;
       [SerializeField] private Slider healthSlider;
       [SerializeField] private Slider magicSlider;
       [SerializeField] private Text resourceText; //This is HP and SP
       [SerializeField] private Text statsText; //STR, INT, RES, PRE, AGI
       [SerializeField] private Text moveValue;
       [SerializeField] private Text jumpValue;
       [SerializeField] private Text fireValue;
       [SerializeField] private Text windValue;
       [SerializeField] private Text iceValue;
       [SerializeField] private Text ownerValue;

       public void ShowStats(Character unit)
       {
           nameText.text = unit.Name;
           classText.text = unit.Type.ToString();
           healthSlider.value = GetPercentage(unit.Stats.Resources.MaxHealth, unit.Stats.Resources.Health);
           magicSlider.value = GetPercentage(unit.Stats.Resources.MaxMagic, unit.Stats.Resources.Magic);
           resourceText.text = unit.Stats.Resources.ToString();
           statsText.text = unit.Stats.Attributes.ToString();
           moveValue.text = unit.Stats.Movement.Move.ToString();
           jumpValue.text = unit.Stats.Movement.Jump.ToString();
           fireValue.text = unit.Stats.Attunement.Fire.ToString();
           windValue.text = unit.Stats.Attunement.Wind.ToString();
           iceValue.text = unit.Stats.Attunement.Ice.ToString();
           ownerValue.text = unit.Ownable.GetOwner().Name;
       }

       private float GetPercentage(float max, float current)
       {
           return (current / max) * 100;
       }
    }
}