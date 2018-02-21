using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Inspector {
    [CustomEditor(typeof(AreaGenerator))]
    public class AreaGeneratorEditor : Editor {
        public override void OnInspectorGUI() {
            AreaGenerator gen = (AreaGenerator) target;
            DrawDefaultInspector();
            if (Application.isPlaying) {
                if (GUILayout.Button("Generate area")) {
                    gen.Generate();
                }
            }
        }
    }
}