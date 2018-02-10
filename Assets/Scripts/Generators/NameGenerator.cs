using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Generators {
    public class NameGenerator : MonoBehaviour {
        public string[] Names;
        private int lastIndex;

        public string GetName() {
            return Names[GetRandom(Names.Length)];
        }

        int GetRandom(int length) {
            if (length <= 1) { return 0; }
            int randomIndex = lastIndex;
            while (randomIndex == lastIndex) { randomIndex = Random.Range(0, length); }
            lastIndex = randomIndex;
            return randomIndex;
        }
    }
}
