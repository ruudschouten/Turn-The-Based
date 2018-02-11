using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Generators;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Inspector {
    [CustomEditor(typeof(CharacterGenerator))]
    public class CharacterGeneratorEditor : Editor {
        public override void OnInspectorGUI() {
            CharacterGenerator gen = (CharacterGenerator) target;
            DrawDefaultInspector();

            if (Application.isPlaying) {
                if (GUILayout.Button("Generate Character")) {
                    gen.Generate();
                }
            }
        }
    }
}
