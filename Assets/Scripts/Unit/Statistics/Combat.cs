using System;
using UnityEngine;

namespace Unit.Statistics
{
    [Serializable]
    public class Combat
    {
        [SerializeField] private float range;
        [SerializeField] private float height;
        [SerializeField] private float attackCost;
        [SerializeField] private float damageModifier;
        [SerializeField] private Element elementOverride;
        [SerializeField] private float areaOfEffectSize;
        
        public float Range
        {
            get => range;
            set => range = value;
        }
        
        public float Height
        {
            get => height;
            set => height = value;
        }

        public float AttackCost
        {
            get => attackCost;
            set => attackCost = value;
        }

        public float DamageModifier
        {
            get => damageModifier;
            set => damageModifier = value;
        }

        public Element ElementOverride
        {
            get => elementOverride;
            set => elementOverride = value;
        }

        public float AreaOfEffectSize
        {
            get => areaOfEffectSize;
            set => areaOfEffectSize = value;
        }
    }
}