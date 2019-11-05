using System;
using UnityEngine;

namespace Unit.Statistics
{
    [Serializable]
    public class Attunement
    {
        [SerializeField] private float fire;
        [SerializeField] private float ice;
        [SerializeField] private float wind;

        public float Fire
        {
            get => fire;
            set => fire = value;
        }

        public float Ice
        {
            get => ice;
            set => ice = value;
        }

        public float Wind
        {
            get => wind;
            set => wind = value;
        }
    }
}