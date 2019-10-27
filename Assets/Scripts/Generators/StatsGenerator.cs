using System;
using Unit;
using Unit.Statistics;
using UnityEngine;

public class StatsGenerator : MonoBehaviour
{
    public Stats GetStats(CharacterType type)
    {
        var stats = new Stats();
        //35 points in total.
        switch (type)
        {
            case CharacterType.Acolyte:
                stats.Resources.Health = 40;
                stats.Resources.Magic = 60;
                stats.Movement.Move = 2;
                stats.Movement.Jump = 2;
                stats.Attributes.Strength = 5;
                stats.Attributes.Defense = 8;
                stats.Attributes.Intelligence = 14;
                stats.Attributes.Resistance = 14;
                stats.Attributes.Precision = 10;
                stats.Attributes.Agility = 8;
                break;
            case CharacterType.Esquire:
                stats.Resources.Health = 60;
                stats.Resources.Magic = 30;
                stats.Movement.Move = 2;
                stats.Movement.Jump = 2;
                stats.Attributes.Strength = 12;
                stats.Attributes.Defense = 12;
                stats.Attributes.Intelligence = 7;
                stats.Attributes.Resistance = 11;
                stats.Attributes.Precision = 10;
                stats.Attributes.Agility = 7;
                break;
            case CharacterType.Brute:
                stats.Resources.Health = 80;
                stats.Resources.Magic = 20;
                stats.Movement.Move = 2;
                stats.Movement.Jump = 2;
                stats.Attributes.Strength = 18;
                stats.Attributes.Defense = 12;
                stats.Attributes.Intelligence = 7;
                stats.Attributes.Resistance = 10;
                stats.Attributes.Precision = 8;
                stats.Attributes.Agility = 4;
                break;
            case CharacterType.Rogue:
                stats.Resources.Health = 50;
                stats.Resources.Magic = 30;
                stats.Movement.Move = 3;
                stats.Movement.Jump = 3;
                stats.Attributes.Strength = 8;
                stats.Attributes.Defense = 6;
                stats.Attributes.Intelligence = 8;
                stats.Attributes.Resistance = 6;
                stats.Attributes.Precision = 16;
                stats.Attributes.Agility = 15;
                break;
            case CharacterType.Ruler:
                stats.Resources.Health = 30;
                stats.Resources.Magic = 20;
                stats.Movement.Move = 1;
                stats.Movement.Jump = 2;
                stats.Attributes.Strength = 2;
                stats.Attributes.Defense = 2;
                stats.Attributes.Intelligence = 2;
                stats.Attributes.Resistance = 2;
                stats.Attributes.Precision = 2;
                stats.Attributes.Agility = 2;
                break;
        }

        stats.Resources.MaxHealth = stats.Resources.Health;
        stats.Resources.MaxMagic = stats.Resources.Magic;
        return stats;
    }

    public Stats AlterWithTraits(Stats stats, Character character)
    {
        foreach (var trait in character.Traits)
        {
            #region Movement

            if (trait.RadialOnly)
            {
                character.MoveType = MovementType.Radial;
            }

            if (trait.DiagonalOnly)
            {
                character.MoveType = MovementType.Diagonal;
            }

            #endregion

            #region Additions

            if (trait.MovementAddition.Move != 0)
            {
                stats.Movement.Move += trait.MovementAddition.Move;
            }

            if (trait.MovementAddition.Jump != 0)
            {
                stats.Movement.Jump += trait.MovementAddition.Jump;
            }

            if (trait.ResourceAddition.Health != 0)
            {
                stats.Resources.Health += trait.ResourceAddition.Health;
            }

            if (trait.ResourceAddition.Magic != 0)
            {
                stats.Resources.Magic += trait.ResourceAddition.Magic;
            }

            if (Math.Abs(trait.AttributeAddition.Strength) > 0)
            {
                stats.Attributes.Strength += trait.AttributeAddition.Strength;
            }

            if (Math.Abs(trait.AttributeAddition.Defense) > 0)
            {
                stats.Attributes.Defense += trait.AttributeAddition.Defense;
            }

            if (Math.Abs(trait.AttributeAddition.Intelligence) > 0)
            {
                stats.Attributes.Intelligence += trait.AttributeAddition.Intelligence;
            }

            if (Math.Abs(trait.AttributeAddition.Resistance) > 0)
            {
                stats.Attributes.Resistance += trait.AttributeAddition.Resistance;
            }

            if (Math.Abs(trait.AttributeAddition.Precision) > 0)
            {
                stats.Attributes.Precision += trait.AttributeAddition.Precision;
            }

            if (Math.Abs(trait.AttributeAddition.Agility) > 0)
            {
                stats.Attributes.Agility += trait.AttributeAddition.Agility;
            }

            if (Math.Abs(trait.AttunementAddition.Fire) > 0)
            {
                stats.Attunement.Fire += trait.AttunementAddition.Fire;
            }

            if (Math.Abs(trait.AttunementAddition.Ice) > 0)
            {
                stats.Attunement.Ice += trait.AttunementAddition.Ice;
            }

            if (Math.Abs(trait.AttunementAddition.Wind) > 0)
            {
                stats.Attunement.Wind += trait.AttunementAddition.Wind;
            }

            #endregion

            #region Multipliers

            if (Math.Abs(trait.ResourceModifier.Health) > 0)
            {
                stats.Resources.Health = (trait.ResourceModifier.Health * stats.Resources.Health);
            }

            if (Math.Abs(trait.ResourceModifier.Magic) > 0)
            {
                stats.Resources.Magic = (trait.ResourceModifier.Magic * stats.Resources.Magic);
            }

            if (Math.Abs(trait.MovementModifier.Move) > 0)
            {
                stats.Movement.Move = (trait.MovementModifier.Move * stats.Movement.Move);
            }

            if (Math.Abs(trait.MovementModifier.Jump) > 0)
            {
                stats.Movement.Jump = (trait.MovementModifier.Jump * stats.Movement.Jump);
            }

            if (Math.Abs(trait.AttributeModifier.Strength) > 0)
            {
                stats.Attributes.Strength = (int) (trait.AttributeModifier.Strength * stats.Attributes.Strength);
            }

            if (Math.Abs(trait.AttributeModifier.Defense) > 0)
            {
                stats.Attributes.Defense = (int) (trait.AttributeModifier.Defense * stats.Attributes.Defense);
            }

            if (Math.Abs(trait.AttributeModifier.Intelligence) > 0)
            {
                stats.Attributes.Intelligence =
                    (int) (trait.AttributeModifier.Intelligence * stats.Attributes.Intelligence);
            }

            if (Math.Abs(trait.AttributeModifier.Resistance) > 0)
            {
                stats.Attributes.Resistance = (int) (trait.AttributeModifier.Resistance * stats.Attributes.Resistance);
            }

            if (Math.Abs(trait.AttributeModifier.Precision) > 0)
            {
                stats.Attributes.Precision = (int) (trait.AttributeModifier.Precision * stats.Attributes.Precision);
            }

            if (Math.Abs(trait.AttributeModifier.Agility) > 0)
            {
                stats.Attributes.Agility = (int) (trait.AttributeModifier.Agility * stats.Attributes.Agility);
            }

            if (Math.Abs(trait.AttunementModifier.Fire) > 0)
            {
                stats.Attunement.Fire = (int) (trait.AttunementModifier.Fire * stats.Attunement.Fire);
            }

            if (Math.Abs(trait.AttunementModifier.Ice) > 0)
            {
                stats.Attunement.Ice = (int) (trait.AttunementModifier.Ice * stats.Attunement.Ice);
            }

            if (Math.Abs(trait.AttunementModifier.Wind) > 0)
            {
                stats.Attunement.Wind = (int) (trait.AttunementModifier.Wind * stats.Attunement.Wind);
            }

            #endregion

            #region  Attack

            if (trait.CombatAddition.ElementOverride != Element.None)
            {
                character.Attack.Element = trait.CombatAddition.ElementOverride;
            }

            if (Math.Abs(trait.CombatAddition.DamageModifier) > 0)
            {
                character.Attack.DamageModifier += trait.CombatAddition.DamageModifier;
            }

            if (Math.Abs(trait.CombatModifier.DamageModifier) > 0)
            {
                character.Attack.DamageModifier *= trait.CombatModifier.DamageModifier;
            }

            #endregion
        }

        stats.Resources.MaxHealth = stats.Resources.Health;
        stats.Resources.MaxMagic = stats.Resources.Magic;
        return stats;
    }
}