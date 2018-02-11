using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Unit;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Generators {
    public class TraitGenerator : MonoBehaviour {
        public GameObject[] TraitPrefabs;

        private int lastIndex;

        public Trait GetTrait(Transform parent) {
            GameObject traitGameObject = TraitPrefabs[GetRandom(TraitPrefabs.Length)];
            traitGameObject = Instantiate(traitGameObject, parent);
            return traitGameObject.GetComponent<Trait>();
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
