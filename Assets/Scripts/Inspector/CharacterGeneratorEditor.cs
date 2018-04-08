using UnityEditor;


[CustomEditor(typeof(CharacterGenerator))]
public class CharacterGeneratorEditor : Editor {
    public override void OnInspectorGUI() {
//            CharacterGenerator gen = (CharacterGenerator) target;
        DrawDefaultInspector();
//
//            if (Application.isPlaying) {
//                if (GUILayout.Button("Generate Character")) {
//                    gen.Generate();
//                }
//            }
    }
}