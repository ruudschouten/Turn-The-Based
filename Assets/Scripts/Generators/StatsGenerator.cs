using Assets.Scripts.Chara;
using UnityEngine;

namespace Assets.Scripts.Generators {
    public class StatsGenerator : MonoBehaviour {

        public Stats GetStats() {
            Stats stats = new Stats();
            stats.HealthPoints = Random.Range(40, 60);
            stats.SpecialPoints = Random.Range(10, 20);
            stats.Move = 2;
            stats.Jump = Random.Range(1f, 2.25f);
            stats.Attack = Random.Range(4, 12);
            stats.Defense = Random.Range(4, 12);
            stats.Intelligence = Random.Range(4, 12);
            stats.Resistance = Random.Range(4, 12);
            stats.Hit = Random.Range(4, 12);
            stats.Speed = Random.Range(4, 12);
            return stats;
        }
    }
}
