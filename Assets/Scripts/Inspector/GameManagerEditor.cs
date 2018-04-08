using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameManager))]
public class GameEditor : Editor {
    public override void OnInspectorGUI() {
        GameManager gen = (GameManager) target;
        DrawDefaultInspector();
        if (Application.isPlaying) {
            if (GUILayout.Button("Start")) {
                gen.StartPlaying();
            }

            if (GUILayout.Button("Buy Normal Character")) {
                gen.BuyCharacter(Rarity.Normal);
            }

            if (GUILayout.Button("Buy Magic Character")) {
                gen.BuyCharacter(Rarity.Magic);
            }

            if (GUILayout.Button("Buy Rare Character")) {
                gen.BuyCharacter(Rarity.Rare);
            }
        }
    }
}