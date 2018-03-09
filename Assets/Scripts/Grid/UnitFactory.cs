using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Grid {
    public class UnitFactory : MonoBehaviour {

        public Unit Prototype;
        public Map Map;

        public List<ResourceCost> Costs;

        public int X;
        public int Y;
        
        public void SpawnUnit() {
            var canAfford = true;
            for (int i = 0; i < Costs.Count; i++) {
                ResourceCost cost = Costs[i];
                if (!cost.CanAfford()) {
                    canAfford = false;
                }
            }
            if (canAfford) {
                X = Random.Range(0, Map.SizeX);
                Y = Random.Range(0, Map.SizeY);
                Cell cell = Map.GetCell(X, Y);
                if (cell == null) {
                    Debug.Log("Unit already on tile");
                }
                else {
                    for (int i = 0; i < Costs.Count; i++) {
                        ResourceCost cost = Costs[i];
                        cost.Pay();
                    }
                    Unit newUnit = Instantiate(Prototype);
                    newUnit.transform.SetParent(cell.transform, false);   
                }
            }
            else {
                Debug.Log("Not enough resources");
            }
        }

        [Serializable]
        public class ResourceCost {
            public Resource.Resource Resource;
            public int Cost;

            public bool CanAfford() {
                return Resource.CanAfford(Cost);
            }

            public void Pay() {
                Resource.ChangeAmount(-Cost);
            }
        }
    }
}