using System;
using Assets.Scripts.Battle;
using UnityEngine;

namespace Assets.Scripts.Unit {
    public class Trait : MonoBehaviour {
        public string Name;
        public string Description;

        //Expand with after turn, steal [health, magic, spirit]
        
        #region Toggles

        public bool DiagonalOnly;
        public bool RadialOnly;

        #endregion

        #region AfterHit

        public int HealthOnHit;
        public int MagicOnHit;
        public int GoldOnHit;

        #endregion

        #region AfterKill

        public int HealthOnKill;
        public int MagicOnKill;
        public int GoldOnKill;

        #endregion

        #region Additions

        //Movement related
        public int MoveAddition;

        public float JumpAddition;

        //Attack related
        public int DamageModifierAddition;

        //Base Stats
        public int HealthAddition;
        public int MagicAddition;
        public int StrengthAddition;
        public int DefenseAddition;
        public int IntelligenceAddition;
        public int ResistanceAddition;
        public int PrecisionAddition;

        public int AgilityAddition;

        //Elemental Resists
        public int FireAttunementAddition;
        public int IceAttunementAddition;
        public int WindAttunementAddition;

        #endregion

        #region Multipliers

        //Movement related
        public float MoveMultiplier;

        public float JumpMultiplier;

        //Attack related
        public float DamageModifierMultiplier;

        public Element ElementOverride;

        //Base Stats
        public float HealthMultiplier;
        public float MagicMultiplier;
        public float StrengthMultiplier;
        public float DefenseMultiplier;
        public float IntelligenceMultiplier;
        public float ResistanceMultiplier;
        public float PrecisionMultiplier;

        public float AgilityMultiplier;

        //Elemental Resists
        public float FireAttunementMultiplier;
        public float IceAttunementMultiplier;
        public float WindAttunementMultiplier;

        #endregion

        public void OnKill(TurnManager turnManager, Character unit) {
            if (HealthOnKill != 0) {
                unit.Stats.Health += HealthOnKill;
                if (unit.Stats.Health > unit.Stats.MaxHealth) {
                    unit.Stats.Health = unit.Stats.MaxHealth;
                }
            }

            if (MagicOnKill != 0) {
                unit.Stats.Magic += MagicOnKill;
                if (unit.Stats.Magic > unit.Stats.MaxMagic) {
                    unit.Stats.Magic = unit.Stats.MaxMagic;
                }
            }

            if (GoldOnKill != 0) {
                turnManager.CurrentPlayer.Gold.ChangeAmount(GoldOnKill);
            }
        }

        public void OnHit(TurnManager turnManager, Character unit) {
            if (HealthOnHit != 0) {
                unit.Stats.Health += HealthOnHit;
                if (unit.Stats.Health > unit.Stats.MaxHealth) {
                    unit.Stats.Health = unit.Stats.MaxHealth;
                }
            }

            if (MagicOnHit != 0) {
                unit.Stats.Magic += MagicOnHit;
                if (unit.Stats.Magic > unit.Stats.MaxMagic) {
                    unit.Stats.Magic = unit.Stats.MaxMagic;
                }
            }

            if (GoldOnHit != 0) {
                turnManager.CurrentPlayer.Gold.ChangeAmount(GoldOnHit);
            }
        }

        public string GetDetails() {
            string details = "";
            if (HealthOnHit != 0) {
                details += string.Format("{0} Health on Hit\n", HealthOnHit);
            }

            if (MagicOnHit != 0) {
                details += string.Format("{0} Magic on Hit\n", MagicOnHit);
            }

            if (GoldOnHit != 0) {
                details += string.Format("{0} Gold on Hit\n", GoldOnHit);
            }

            if (HealthOnKill != 0) {
                details += string.Format("{0} Health on Kill\n", GoldOnKill);
            }

            if (MagicOnKill != 0) {
                details += string.Format("{0} Magic on Kill\n", GoldOnKill);
            }

            if (GoldOnKill != 0) {
                details += string.Format("{0} Gold on Kill\n", GoldOnKill);
            }

            if (MoveAddition != 0) {
                details += "Adds " + MoveAddition + " Move\n";
            }

            if (Math.Abs(JumpAddition) > 0) {
                details += "Adds " + JumpAddition + " Jump\n";
            }

            if (HealthAddition != 0) {
                details += "Adds " + HealthAddition + " Health\n";
            }

            if (MagicAddition != 0) {
                details += "Adds " + MagicAddition + " Magic\n";
            }

            if (StrengthAddition != 0) {
                details += "Adds " + StrengthAddition + " Strength\n";
            }

            if (DefenseAddition != 0) {
                details += "Adds " + DefenseAddition + " Defense\n";
            }

            if (IntelligenceAddition != 0) {
                details += "Adds " + IntelligenceAddition + " Intelligence\n";
            }

            if (ResistanceAddition != 0) {
                details += "Adds " + ResistanceAddition + " Resistance\n";
            }

            if (PrecisionAddition != 0) {
                details += "Adds " + PrecisionAddition + " Precision\n";
            }

            if (AgilityAddition != 0) {
                details += "Adds " + AgilityAddition + " Agility\n";
            }

            if (FireAttunementAddition != 0) {
                details += "Adds " + FireAttunementAddition + " Fire Attunement\n";
            }

            if (IceAttunementAddition != 0) {
                details += "Adds " + IceAttunementAddition + " Ice Attunement\n";
            }

            if (WindAttunementAddition != 0) {
                details += "Adds " + WindAttunementAddition + " Wind Attunement\n";
            }

            if (Math.Abs(MoveMultiplier) > 0) {
                details += "Has " + MoveMultiplier * 100 + "% Move\n";
            }

            if (Math.Abs(JumpMultiplier) > 0) {
                details += "Has " + JumpMultiplier * 100 + "% Jump\n";
            }

            if (Math.Abs(HealthMultiplier) > 0) {
                details += "Has " + HealthMultiplier * 100 + "% Health\n";
            }

            if (Math.Abs(MagicMultiplier) > 0) {
                details += "Has " + MagicMultiplier * 100 + "% Magic\n";
            }

            if (Math.Abs(StrengthMultiplier) > 0) {
                details += "Has " + StrengthMultiplier * 100 + "% Strength\n";
            }

            if (Math.Abs(DefenseMultiplier) > 0) {
                details += "Has " + DefenseMultiplier * 100 + "% Defense\n";
            }

            if (Math.Abs(IntelligenceMultiplier) > 0) {
                details += "Has " + IntelligenceMultiplier * 100 + "% Intelligence\n";
            }

            if (Math.Abs(ResistanceMultiplier) > 0) {
                details += "Has " + ResistanceMultiplier * 100 + "% Resistance\n";
            }

            if (Math.Abs(PrecisionMultiplier) > 0) {
                details += "Has " + PrecisionMultiplier * 100 + "% Precision\n";
            }

            if (Math.Abs(AgilityMultiplier) > 0) {
                details += "Has " + AgilityMultiplier * 100 + "% Agility\n";
            }

            if (Math.Abs(FireAttunementMultiplier) > 0) {
                details += "Has " + FireAttunementMultiplier * 100 + "% Fire Attunement\n";
            }

            if (Math.Abs(IceAttunementMultiplier) > 0) {
                details += "Has " + IceAttunementMultiplier * 100 + "% Ice Attunement\n";
            }

            if (Math.Abs(WindAttunementMultiplier) > 0) {
                details += "Has " + WindAttunementMultiplier * 100 + "% Wind Attunement\n";
            }

            if (ElementOverride != Element.None) {
                details += "Deals " + ElementOverride + " damage\n";
            }

            if (DamageModifierAddition != 0) {
                details += "Adds " + DamageModifierAddition + " Damage Modifier\n";
            }

            if (Math.Abs(DamageModifierMultiplier) > 0) {
                details += "Has " + DamageModifierMultiplier * 100 + "% Damage Modifier\n";
            }

            return details;
        }
    }
}