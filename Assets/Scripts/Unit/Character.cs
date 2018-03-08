using System.Collections.Generic;
using Assets.Scripts.Battle;
using Assets.Scripts.Generators;
using UnityEngine;

namespace Assets.Scripts.Unit {
    public class Character : MonoBehaviour {
        public string Name;
        public Stats Stats;
        public Rarity Rarity;
        public CharacterType Type;
        public List<Trait> Traits = new List<Trait>();
        //Attacks
        public Attack DefaultAttack;
        public List<Skill> Skills = new List<Skill>();
        //Resource
        public Dictionary<Resource.Resource, int> Cost;
    }

    public enum CharacterType {
        Acolyte = 0, // Bird
        Esquire = 1, // Goat
        Brute = 2, // Roided Goat
        Rogue = 3,   // Ermine
        Ruler = 4   // Wolf & Fox
    }
}
