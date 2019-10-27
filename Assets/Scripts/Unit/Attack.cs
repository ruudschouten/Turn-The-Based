using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Unit
{
    public class Attack : MonoBehaviour
    {
        public BoostedBy BoostedBy;
        public Element Element;
        public int BaseDamage = 4;
        [Range(0.25f, 2.5f)] public float DamageModifier = 1;
        public int Range = 1;
        public float Height = 1.5f;

        public int GetDamage(Character attacker, Character defender)
        {
            float damage = 0;
            var aStats = attacker.Stats;
            var dStats = defender.Stats;

            float attack = 0;
            float defense = 0;
            float element = 0;

            switch (BoostedBy)
            {
                case BoostedBy.Strength:
                    attack = aStats.Attributes.Strength * DamageModifier;
                    defense = dStats.Attributes.Defense;
                    break;
                case BoostedBy.Intelligence:
                    attack = aStats.Attributes.Intelligence * DamageModifier;
                    defense = dStats.Attributes.Resistance;
                    break;
                case BoostedBy.Precision:
                    attack = aStats.Attributes.Precision * DamageModifier;
                    defense = dStats.Attributes.Agility;
                    break;
            }

            damage = BaseDamage + (attack - defense);

            switch (Element)
            {
                case Element.None:
                    break;
                case Element.Fire:
                    element = aStats.Attunement.Fire - dStats.Attunement.Fire;
                    break;
                case Element.Ice:
                    element = aStats.Attunement.Ice - dStats.Attunement.Ice;
                    break;
                case Element.Wind:
                    element = aStats.Attunement.Wind - dStats.Attunement.Wind;
                    break;
            }

            damage *= 1 + (element / 100);

            return Convert.ToInt32(damage);
        }

        public float GetChanceToHit(Character attacker, Character defender)
        {
            //Tweak this so missing is possible
            return ((float) attacker.Stats.Attributes.Precision / defender.Stats.Attributes.Agility);
        }

        public bool Perform(Character attacker, Character defender)
        {
            var cth = GetChanceToHit(attacker, defender);
            var random = Random.Range(0, 100);
            if ((cth * 100) >= random)
            {
                int damage = GetDamage(attacker, defender);
                if (damage < 1) damage = 1;
                defender.Stats.Resources.Health -= damage;
                defender.DamageUI.ShowHealthDegrade(defender.Stats.Resources.MaxHealth,
                    defender.Stats.Resources.Health);
                return true;
            }

            defender.DamageUI.ShowText("Dodged");
            return false;
        }
    }


    public enum BoostedBy
    {
        Strength,
        Intelligence,
        Precision
    }

    public enum Element
    {
        None,
        Fire,
        Ice,
        Wind
    }
}