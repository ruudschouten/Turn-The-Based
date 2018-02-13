using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Battle {
    public class Attack : MonoBehaviour {
        public BoostedBy BoostedBy;
        public Element Element;
        [Range(0.25f, 2.5f)] public float DamageModifier = 1;
        public int Range = 1;
        public float Height = 1.5f;
    }

    public enum BoostedBy {
        Strength,
        Defense,
        Intelligence,
        Resistance,
        Precision,
        Agility
    }

    public enum Element {
        None,
        Fire,
        Ice,
        Wind
    }
}