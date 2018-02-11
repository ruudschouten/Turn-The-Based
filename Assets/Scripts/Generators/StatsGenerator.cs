using System;
using Assets.Scripts.Unit;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Generators {
    public class StatsGenerator : MonoBehaviour {

        public Stats GetStats(CharacterType type) {
            Stats stats = new Stats();
            //35 points in total.
            switch (type) {
                case CharacterType.Acolyte:
                    stats.Health = 40;
                    stats.Magic = 60;
                    stats.Move = 2;
                    stats.Jump = 1.5f;
                    stats.Strength = 5;
                    stats.Defense = 8;
                    stats.Intelligence = 14;
                    stats.Resistance = 14;
                    stats.Precision = 10;
                    stats.Agility = 8;
                    break;
                case CharacterType.Esquire:
                    stats.Health = 80;
                    stats.Magic = 20;
                    stats.Move = 2;
                    stats.Jump = 1.5f;
                    stats.Strength = 18;
                    stats.Defense = 12;
                    stats.Intelligence = 7;
                    stats.Resistance = 10;
                    stats.Precision = 8;
                    stats.Agility = 4;
                    break;
                case CharacterType.Rogue:
                    stats.Health = 50;
                    stats.Magic = 30;
                    stats.Move = 3;
                    stats.Jump = 3f;
                    stats.Strength = 8;
                    stats.Defense = 6;
                    stats.Intelligence = 8;
                    stats.Resistance = 6;
                    stats.Precision = 16;
                    stats.Agility = 15;
                    break;
                case CharacterType.Ruler:
                    stats.Health = 160;
                    stats.Magic = 20;
                    stats.Move = 1;
                    stats.Jump = 1.5f;
                    stats.Strength = 10;
                    stats.Defense = 6;
                    stats.Intelligence = 10;
                    stats.Resistance = 6;
                    stats.Precision = 10;
                    stats.Agility = 6;
                    break;
                case CharacterType.Cavalry:
                    stats.Health = 50;
                    stats.Magic = 30;
                    stats.Move = 2;
                    stats.Jump = 3f;
                    stats.Strength = 18;
                    stats.Defense = 8;
                    stats.Intelligence = 6;
                    stats.Resistance = 6;
                    stats.Precision = 6;
                    stats.Agility = 15;
                    break;
            }
            return stats;
        }
    }
}
