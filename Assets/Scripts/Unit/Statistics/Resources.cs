using System;
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

        public override string ToString()
        {
            return $"HP:\t\t\t{health}/{maxHealth}\n" +
                   $"MP:\t\t\t{magic}/{maxMagic}";
        }
    }
}