using System;
using UI;
using UnityEngine;

namespace Unit.Statistics
{
    [Serializable]
    public class Resources
    {
        [SerializeField] private float health;
        [SerializeField] private float magic;
        [SerializeField] private float maxHealth;
        [SerializeField] private float maxMagic;

        public float Health
        {
            get => health;
            set => health = value;
        }

        public float Magic
        {
            get => magic;
            set => magic = value;
        }

        public float MaxHealth
        {
            get => maxHealth;
            set => maxHealth = value;
        }

        public float MaxMagic
        {
            get => maxMagic;
            set => maxMagic = value;
        }

        public void Apply(Resources other, DamageUI ui)
        {
            var changed = false;
            if (Math.Abs(other.Health) > 0)
            {
                Health += other.Health;
                changed = true;
            }
            if (Math.Abs(other.Magic) > 0)
            {
                Magic += other.Magic;
                changed = true;
            }
            if (Math.Abs(other.MaxHealth) > 0)
            {
                MaxHealth += other.MaxHealth;
                changed = true;
            }
            if (Math.Abs(other.MaxMagic) > 0)
            {
                MaxMagic += other.MaxMagic;
                changed = true;
            }

            if (!changed) return;
            
            ui.ShowHealthDegrade(maxHealth, health);
        }

        public override string ToString()
        {
            return $"HP:\t\t\t{health}/{maxHealth}\n" +
                   $"MP:\t\t\t{magic}/{maxMagic}";
        }
    }
}