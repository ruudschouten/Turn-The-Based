using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Battle {
    public class Skill : Attack {
        public bool Heals;
        public bool Diagonal;
        public bool HasAoE;
        public string Name;
        public int ManaCost;
        public GameObject HighlightPrefab;

        public int AreaOfEffectSize;
        public float DamageFallOff; //Per Tile away from source

        public void DrawAoE() {
            if (AreaOfEffectSize == 0) return;
            var tileWidth = 2.8f;
            Vector3 sourcePos = new Vector3(0, 0, 0);
            //Source highlight
            GameObject parent = new GameObject("Area of Effect");

            var newPos = new Vector3();
            for (int n = AreaOfEffectSize; n > 0; n--) {
                for (int x = 0; x < n + 1; x++) {
                    var y = n - x;
                    newPos = new Vector3(sourcePos.x + (x * tileWidth), sourcePos.y, sourcePos.z + (y * tileWidth));
                    Instantiate(HighlightPrefab, newPos, new Quaternion(), parent.transform);

                    newPos = new Vector3(sourcePos.x + (-x * tileWidth), sourcePos.y, sourcePos.z + (-y * tileWidth));
                    Instantiate(HighlightPrefab, newPos, new Quaternion(), parent.transform);
                    if (x != 0 && y != 0) {
                        newPos = new Vector3(sourcePos.x + (-x * tileWidth), sourcePos.y, sourcePos.z + (y * tileWidth));
                        Instantiate(HighlightPrefab, newPos, new Quaternion(), parent.transform);

                        newPos = new Vector3(sourcePos.x + (x * tileWidth), sourcePos.y, sourcePos.z + (-y * tileWidth));
                        Instantiate(HighlightPrefab, newPos, new Quaternion(), parent.transform);
                    }
                }
            }
            Instantiate(HighlightPrefab, sourcePos, new Quaternion(), parent.transform);
        }
    }
}