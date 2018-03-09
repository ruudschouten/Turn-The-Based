using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

namespace Tiles {
    public class Map : MonoBehaviour {
        public int SizeX;
        public int SizeY;

        public Tile Prototype;
        
        public List<Tile> Tiles;

        public void Spawn() {
            for (int i = 0; i < SizeX; i++) {
                for (int j = 0; j < SizeY; j++) {
                    Instantiate(Prototype);
                }
            }
        }
    }
}