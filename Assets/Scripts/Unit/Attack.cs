using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Unit
{
    public class Attack : MonoBehaviour
    {
        [SerializeField] private BoostedBy boostedBy;
        [SerializeField] private Element element;
        [SerializeField] private int baseDamage = 4;
        [Range(0.25f, 2.5f)] [SerializeField] private float damageModifier = 1;
        [SerializeField] private float range = 1;
        [SerializeField] private float height = 1.5f;

        public Element Element
        {
            get => element;
            set => element = value;
        }

        public float DamageModifier
        {
            get => damageModifier;
            set => damageModifier = value;
        }
        
        public float Range => range;

        public int GetDamage(Character attacker, Character defender)
        {
            var damage = 0f;
            var aStats = attacker.Stats;
            var dStats = defender.Stats;

            var attack = 0f;
            var defense = 0f;
            var elementalModifier = 0f;

            switch (boostedBy)
            {
                case BoostedBy.Strength:
                    attack = aStats.Attributes.Strength * damageModifier;
                    defense = dStats.Attributes.Defense;
                    break;
                case BoostedBy.Intelligence:
                    attack = aStats.Attributes.Intelligence * damageModifier;
                    defense = dStats.Attributes.Resistance;
                    break;
                case BoostedBy.Precision:
                    attack = aStats.Attributes.Precision * damageModifier;
                    defense = dStats.Attributes.Agility;
                    break;
            }

            damage = baseDamage + (attack - defense);

            switch (element)
            {
                case Element.None:
                    break;
                case Element.Fire:
                    elementalModifier = aStats.Attunement.Fire - dStats.Attunement.Fire;
                    break;
                case Element.Ice:
                    elementalModifier = aStats.Attunement.Ice - dStats.Attunement.Ice;
                    break;
                case Element.Wind:
                    elementalModifier = aStats.Attunement.Wind - dStats.Attunement.Wind;
                    break;
            }

            damage *= 1 + (elementalModifier / 100);

            return Convert.ToInt32(damage);
        }

        public float GetChanceToHit(Character attacker, Character defender)
        {
            //Tweak this so missing is possible
            return (attacker.Stats.Attributes.Precision / defender.Stats.Attributes.Agility);
        }

        public bool Perform(Character attacker, Character defender)
        {
            var chanceToHit = GetChanceToHit(attacker, defender);
            var random = Random.Range(0, 100);
            if ((chanceToHit * 100) >= random)
            {
                var damage = GetDamage(attacker, defender);
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