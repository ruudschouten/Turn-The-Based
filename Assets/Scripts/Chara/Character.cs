using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Generators;
using UnityEngine;

namespace Assets.Scripts.Chara {
    public class Character : MonoBehaviour {
        public string Name;
        public Stats Stats;
        public Rarity Rarity;
        public List<Trait> Traits = new List<Trait>();

        public void Start() {
        }
    }
}
