using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Assets.Scripts.Chara;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Trait))]
public class TraitEditor : Editor {
    private bool showToggles;
    private bool showOnHit;
    private bool showOnKill;

    private bool showMultipliers;
    private bool showMultiMove;
    private bool showMultiBase;
    private bool showMultiAff;
    private bool showMultiMisc;

    private bool showAddition;
    private bool showAddiMove;
    private bool showAddiBase;
    private bool showAddiAff;
    private bool showAddiMisc;

    public override void OnInspectorGUI() {
        Trait traits = (Trait) target;
        traits.Name = EditorGUILayout.TextField("Name", traits.Name);
        EditorGUILayout.LabelField("Description");
        traits.Description = EditorGUILayout.TextArea(traits.Description);
        showToggles = EditorGUILayout.Foldout(showToggles, "Toggles");
        if (showToggles) {
            EditorGUI.indentLevel++;
            traits.AllowDiagonal = EditorGUILayout.Toggle("Allow Diagonal Movement", traits.AllowDiagonal);
            traits.DisallowStraight = EditorGUILayout.Toggle("Disallow Straight Movement", traits.DisallowStraight);
            EditorGUI.indentLevel--;
        }
        showMultipliers = EditorGUILayout.Foldout(showMultipliers, "Multipliers");
        if (showMultipliers) {
            EditorGUI.indentLevel++;
            showMultiMove = EditorGUILayout.Foldout(showMultiMove, "Movement Related");
            if (showMultiMove) {
                EditorGUI.indentLevel++;
                traits.MoveMultiplier = EditorGUILayout.FloatField("Move", traits.MoveMultiplier);
                traits.JumpMultiplier = EditorGUILayout.FloatField("Jump", traits.JumpMultiplier);
                EditorGUI.indentLevel--;
            }
            showMultiBase = EditorGUILayout.Foldout(showMultiBase, "Base Stats");
            if (showMultiBase) {
                EditorGUI.indentLevel++;
                traits.HealthPointsMultiplier =
                    EditorGUILayout.FloatField("Health Points", traits.HealthPointsMultiplier);
                traits.SpecialPointsMultiplier =
                    EditorGUILayout.FloatField("Special Points", traits.SpecialPointsMultiplier);
                traits.AttackMultiplier = EditorGUILayout.FloatField("Attack", traits.AttackMultiplier);
                traits.DefenseMultiplier = EditorGUILayout.FloatField("Defense", traits.DefenseMultiplier);
                traits.IntelligenceMultiplier =
                    EditorGUILayout.FloatField("Intelligence", traits.IntelligenceMultiplier);
                traits.ResistanceMultiplier = EditorGUILayout.FloatField("Resistance", traits.ResistanceMultiplier);
                traits.HitMultiplier = EditorGUILayout.FloatField("Hit", traits.HitMultiplier);
                traits.SpeedMultiplier = EditorGUILayout.FloatField("Speed", traits.SpeedMultiplier);
                EditorGUI.indentLevel--;
            }
            showMultiAff = EditorGUILayout.Foldout(showMultiAff, "Affinity");
            if (showMultiAff) {
                EditorGUI.indentLevel++;
                traits.FireAffinityMultiplier = EditorGUILayout.FloatField("Fire", traits.FireAffinityMultiplier);
                traits.IceAffinityMultiplier = EditorGUILayout.FloatField("Ice", traits.IceAffinityMultiplier);
                traits.WindAffinityMultiplier = EditorGUILayout.FloatField("Wind", traits.WindAffinityMultiplier);
                EditorGUI.indentLevel--;
            }
            showMultiMisc = EditorGUILayout.Foldout(showMultiMisc, "Misc");
            if (showMultiMisc) {
                EditorGUI.indentLevel++;
                traits.GoldMultiplier = EditorGUILayout.FloatField("Gold Multiplier", traits.GoldMultiplier);
                EditorGUI.indentLevel--;
            }
            EditorGUI.indentLevel--;
        }

        showAddition = EditorGUILayout.Foldout(showAddition, "Additions");
        if (showAddition) {
            EditorGUI.indentLevel++;
            showAddiMove = EditorGUILayout.Foldout(showAddiMove, "Movement Related");
            if (showAddiMove) {
                EditorGUI.indentLevel++;
                traits.MoveAddition = EditorGUILayout.IntField("Move", traits.MoveAddition);
                traits.JumpAddition = EditorGUILayout.FloatField("Jump", traits.JumpAddition);
                EditorGUI.indentLevel--;
            }
            showAddiBase = EditorGUILayout.Foldout(showAddiBase, "Base Stats");
            if (showAddiBase) {
                EditorGUI.indentLevel++;
                traits.HealthPointsAddition =
                    EditorGUILayout.IntField("Health Points", traits.HealthPointsAddition);
                traits.SpecialPointsAddition =
                    EditorGUILayout.IntField("Special Points", traits.SpecialPointsAddition);
                traits.AttackAddition = EditorGUILayout.IntField("Attack", traits.AttackAddition);
                traits.DefenseAddition = EditorGUILayout.IntField("Defense", traits.DefenseAddition);
                traits.IntelligenceAddition =
                    EditorGUILayout.IntField("Intelligence", traits.IntelligenceAddition);
                traits.ResistanceAddition = EditorGUILayout.IntField("Resistance", traits.ResistanceAddition);
                traits.HitAddition = EditorGUILayout.IntField("Hit", traits.HitAddition);
                traits.SpeedAddition = EditorGUILayout.IntField("Speed", traits.SpeedAddition);
                EditorGUI.indentLevel--;
            }
            showAddiAff = EditorGUILayout.Foldout(showAddiAff, "Affinity");
            if (showAddiAff) {
                EditorGUI.indentLevel++;
                traits.FireAffinityAddition = EditorGUILayout.IntField("Fire", traits.FireAffinityAddition);
                traits.IceAffinityAddition = EditorGUILayout.IntField("Ice", traits.IceAffinityAddition);
                traits.WindAffinityAddition = EditorGUILayout.IntField("Wind", traits.WindAffinityAddition);
                EditorGUI.indentLevel--;
            }
            showAddiMisc = EditorGUILayout.Foldout(showAddiMisc, "Misc");
            if (showAddiMisc) {
                EditorGUI.indentLevel++;
                traits.GoldAddition = EditorGUILayout.IntField("Gold Addition", traits.GoldAddition);
                EditorGUI.indentLevel--;
            }
            EditorGUI.indentLevel--;
        }

        showOnHit = EditorGUILayout.Foldout(showOnHit, "On Hit");
        if(showOnHit) {
            EditorGUI.indentLevel++;
            traits.HealthOnHit = EditorGUILayout.IntField("Gain Health on Hit", traits.HealthOnHit);
            traits.SpecialOnHit = EditorGUILayout.IntField("Gain Special on Hit", traits.SpecialOnHit);
            traits.GoldOnHit = EditorGUILayout.IntField("Gain Gold on Hit", traits.GoldOnHit);
            EditorGUI.indentLevel--;
        }

        showOnKill = EditorGUILayout.Foldout(showOnKill, "On Kill");
        if(showOnKill) {
            EditorGUI.indentLevel++;
            traits.HealthOnKill = EditorGUILayout.IntField("Gain Health on Kill", traits.HealthOnKill);
            traits.SpecialOnKill = EditorGUILayout.IntField("Gain Special on Kill", traits.SpecialOnKill);
            traits.GoldOnKill = EditorGUILayout.IntField("Gain Gold on Kill", traits.GoldOnKill);
            EditorGUI.indentLevel--;
        }
    }
}