using System;
using Assets.Scripts.Unit;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Generators {
    public class StatsGenerator : MonoBehaviour {
        public Stats GetStats(CharacterType type) {
            Stats stats = new Stats();
            //35 points in total.
            switch (type) {
                case CharacterType.Acolyte:
                    stats.Health = 40;
                    stats.Magic = 60;
                    stats.Move = 2;
                    stats.Jump = 1.5f;
                    stats.Strength = 5;
                    stats.Defense = 8;
                    stats.Intelligence = 14;
                    stats.Resistance = 14;
                    stats.Precision = 10;
                    stats.Agility = 8;
                    break;
                case CharacterType.Esquire:
                    stats.Health = 60;
                    stats.Magic = 30;
                    stats.Move = 2;
                    stats.Jump = 2f;
                    stats.Strength = 12;
                    stats.Defense = 12;
                    stats.Intelligence = 7;
                    stats.Resistance = 11;
                    stats.Precision = 10;
                    stats.Agility = 7;
                    break;
                case CharacterType.Brute:
                    stats.Health = 80;
                    stats.Magic = 20;
                    stats.Move = 2;
                    stats.Jump = 1.5f;
                    stats.Strength = 18;
                    stats.Defense = 12;
                    stats.Intelligence = 7;
                    stats.Resistance = 10;
                    stats.Precision = 8;
                    stats.Agility = 4;
                    break;
                case CharacterType.Rogue:
                    stats.Health = 50;
                    stats.Magic = 30;
                    stats.Move = 3;
                    stats.Jump = 3f;
                    stats.Strength = 8;
                    stats.Defense = 6;
                    stats.Intelligence = 8;
                    stats.Resistance = 6;
                    stats.Precision = 16;
                    stats.Agility = 15;
                    break;
                case CharacterType.Ruler:
                    stats.Health = 30;
                    stats.Magic = 20;
                    stats.Move = 1;
                    stats.Jump = 1.5f;
                    stats.Strength = 2;
                    stats.Defense = 2;
                    stats.Intelligence = 2;
                    stats.Resistance = 2;
                    stats.Precision = 2;
                    stats.Agility = 2;
                    break;
            }

            stats.MaxHealth = stats.Health;
            stats.MaxMagic = stats.Magic;
            return stats;
        }

        public Stats AlterWithTraits(Stats stats, Character character) {
            foreach (var trait in character.Traits) {
                #region Movement

                if (trait.RadialOnly) character.MoveType = MovementType.Radial;
                if (trait.DiagonalOnly) character.MoveType = MovementType.Diagonal;

                #endregion

                #region Additions

                if (trait.MoveAddition != 0) stats.Move += trait.MoveAddition;
                if (Math.Abs(trait.JumpAddition) > 0) stats.Jump += trait.JumpAddition;
                if (trait.HealthAddition != 0) stats.Health += trait.HealthAddition;
                if (trait.MagicAddition != 0) stats.Magic += trait.MagicAddition;
                if (trait.StrengthAddition != 0) stats.Strength += trait.StrengthAddition;
                if (trait.DefenseAddition != 0) stats.Defense += trait.DefenseAddition;
                if (trait.IntelligenceAddition != 0) stats.Intelligence += trait.IntelligenceAddition;
                if (trait.ResistanceAddition != 0) stats.Resistance += trait.ResistanceAddition;
                if (trait.PrecisionAddition != 0) stats.Precision += trait.PrecisionAddition;
                if (trait.AgilityAddition != 0) stats.Agility += trait.AgilityAddition;
                if (trait.FireAttunementAddition != 0) stats.FireAttunement += trait.FireAttunementAddition;
                if (trait.IceAttunementAddition != 0) stats.IceAttunement += trait.IceAttunementAddition;
                if (trait.WindAttunementAddition != 0) stats.WindAttunement += trait.WindAttunementAddition;

                #endregion

                #region Multipliers

                if (Math.Abs(trait.MoveMultiplier) > 0) {
                    stats.Move = (int) (trait.MoveMultiplier * stats.Move);
                }

                if (Math.Abs(trait.JumpMultiplier) > 0) {
                    stats.Jump = (int) (trait.JumpMultiplier * stats.Jump);
                }

                if (Math.Abs(trait.HealthMultiplier) > 0) {
                    stats.Health = (int) (trait.HealthMultiplier * stats.Health);
                }

                if (Math.Abs(trait.MagicMultiplier) > 0) {
                    stats.Magic = (int) (trait.MagicMultiplier * stats.Magic);
                }

                if (Math.Abs(trait.StrengthMultiplier) > 0) {
                    stats.Strength = (int) (trait.StrengthMultiplier * stats.Strength);
                }

                if (Math.Abs(trait.DefenseMultiplier) > 0) {
                    stats.Defense = (int) (trait.DefenseMultiplier * stats.Defense);
                }

                if (Math.Abs(trait.IntelligenceMultiplier) > 0) {
                    stats.Intelligence = (int) (trait.IntelligenceMultiplier * stats.Intelligence);
                }

                if (Math.Abs(trait.ResistanceMultiplier) > 0) {
                    stats.Resistance = (int) (trait.ResistanceMultiplier * stats.Resistance);
                }

                if (Math.Abs(trait.PrecisionMultiplier) > 0) {
                    stats.Precision = (int) (trait.PrecisionMultiplier * stats.Precision);
                }

                if (Math.Abs(trait.AgilityMultiplier) > 0) {
                    stats.Agility = (int) (trait.AgilityMultiplier * stats.Agility);
                }

                if (Math.Abs(trait.FireAttunementMultiplier) > 0) {
                    stats.FireAttunement = (int) (trait.FireAttunementMultiplier * stats.FireAttunement);
                }

                if (Math.Abs(trait.IceAttunementMultiplier) > 0) {
                    stats.IceAttunement = (int) (trait.IceAttunementMultiplier * stats.IceAttunement);
                }

                if (Math.Abs(trait.WindAttunementMultiplier) > 0) {
                    stats.WindAttunement = (int) (trait.WindAttunementMultiplier * stats.WindAttunement);
                }

                #endregion

                #region  Attack

                if (trait.ElementOverride != Element.None) {
                    character.Attack.Element = trait.ElementOverride;
                }

                if (trait.DamageModifierAddition != 0) {
                    character.Attack.DamageModifier += trait.DamageModifierAddition;
                }

                if (Math.Abs(trait.DamageModifierMultiplier) > 0) {
                    character.Attack.DamageModifier *= trait.DamageModifierMultiplier;
                }

                #endregion
            }

            stats.MaxHealth = stats.Health;
            stats.MaxMagic = stats.Magic;
            return stats;
        }
    }
}