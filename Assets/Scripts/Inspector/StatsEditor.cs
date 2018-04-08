using System;
using UnityEditor;

public class StatsEditor {
    public void PrintStatsLabel(Stats stats) {
        if (stats.Move != 0) EditorGUILayout.LabelField("Move", stats.Move.ToString());
        if (Math.Abs(stats.Jump) > 0) EditorGUILayout.LabelField("Jump", stats.Jump.ToString("##.00"));
        if (stats.Health != 0) EditorGUILayout.LabelField("Health", stats.Health.ToString());
        if (stats.Magic != 0) EditorGUILayout.LabelField("Magic", stats.Magic.ToString());
        if (stats.Strength != 0) EditorGUILayout.LabelField("Strength", stats.Strength.ToString());
        if (stats.Defense != 0) EditorGUILayout.LabelField("Defense", stats.Defense.ToString());
        if (stats.Intelligence != 0) EditorGUILayout.LabelField("Intelligence", stats.Intelligence.ToString());
        if (stats.Resistance != 0) EditorGUILayout.LabelField("Resistance", stats.Resistance.ToString());
        if (stats.Precision != 0) EditorGUILayout.LabelField("Precision", stats.Precision.ToString());
        if (stats.Agility != 0) EditorGUILayout.LabelField("Agility", stats.Agility.ToString());
        if (stats.FireAttunement != 0) EditorGUILayout.LabelField("Fire Attunement", stats.FireAttunement.ToString());
        if (stats.IceAttunement != 0) EditorGUILayout.LabelField("Ice Attunement", stats.IceAttunement.ToString());
        if (stats.WindAttunement != 0) EditorGUILayout.LabelField("Wind Attunement", stats.WindAttunement.ToString());
    }
}