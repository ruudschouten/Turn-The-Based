using System;
using UnityEngine;

namespace Unit.Statistics
{
    [Serializable]
    public class Attributes
    {
        [SerializeField] private float strength;
        [SerializeField] private float defense;
        [SerializeField] private float intelligence;
        [SerializeField] private float resistance;
        [SerializeField] private float precision;
        [SerializeField] private float agility;

        public float Strength
        {
            get => strength;
            set => strength = value;
        }

        public float Defense
        {
            get => defense;
            set => defense = value;
        }

        public float Intelligence
        {
            get => intelligence;
            set => intelligence = value;
        }

        public float Resistance
        {
            get => resistance;
            set => resistance = value;
        }

        public float Precision
        {
            get => precision;
            set => precision = value;
        }

        public float Agility
        {
            get => agility;
            set => agility = value;
        }
        
        public override string ToString() {
            return $"STR:\t\t\t{strength}\n" +
                   $"DEF:\t\t\t{defense}\n" +
                   $"INT:\t\t\t{intelligence}\n" +
                   $"RES:\t\t\t{resistance}\n" +
                   $"PRC:\t\t\t{precision}\n" +
                   $"AGI:\t\t\t{agility}";
        }
    }
}