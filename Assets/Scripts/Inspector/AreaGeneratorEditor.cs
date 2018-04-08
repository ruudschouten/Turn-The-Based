using UnityEditor;
using UnityEngine;


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