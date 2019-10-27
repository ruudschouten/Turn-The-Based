using System;
using UnityEngine;

namespace Unit.Statistics
{
    [Serializable]
    public class Resources
    {
        [SerializeField] private int health;
        [SerializeField] private int magic;
        [SerializeField] private int maxHealth;
        [SerializeField] private int maxMagic;

        public int Health
        {
            get => health;
            set => health = value;
        }

        public int Magic
        {
            get => magic;
            set => magic = value;
        }

        public int MaxHealth
        {
            get => maxHealth;
            set => maxHealth = value;
        }

        public int MaxMagic
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