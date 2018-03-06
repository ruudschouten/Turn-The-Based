using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Assets.Scripts.Unit;
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
    
    private bool showAddition;
    private bool showAddiMove;
    private bool showAddiBase;
    private bool showAddiAff;

    //TODO: Refactor this into methods
    //TODO: Add Attack Additions and Modifiers
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
                traits.HealthMultiplier =
                    EditorGUILayout.FloatField("Health", traits.HealthMultiplier);
                traits.MagicMultiplier =
                    EditorGUILayout.FloatField("Special", traits.MagicMultiplier);
                traits.StrengthMultiplier = EditorGUILayout.FloatField("Strength", traits.StrengthMultiplier);
                traits.DefenseMultiplier = EditorGUILayout.FloatField("Defense", traits.DefenseMultiplier);
                traits.IntelligenceMultiplier =
                    EditorGUILayout.FloatField("Intelligence", traits.IntelligenceMultiplier);
                traits.ResistanceMultiplier = EditorGUILayout.FloatField("Resistance", traits.ResistanceMultiplier);
                traits.PrecisionMultiplier = EditorGUILayout.FloatField("Precision", traits.PrecisionMultiplier);
                traits.AgilityMultiplier = EditorGUILayout.FloatField("Agility", traits.AgilityMultiplier);
                EditorGUI.indentLevel--;
            }
            showMultiAff = EditorGUILayout.Foldout(showMultiAff, "Attunement");
            if (showMultiAff) {
                EditorGUI.indentLevel++;
                traits.FireAttunementMultiplier = EditorGUILayout.FloatField("Fire", traits.FireAttunementMultiplier);
                traits.IceAttunementMultiplier = EditorGUILayout.FloatField("Ice", traits.IceAttunementMultiplier);
                traits.WindAttunementMultiplier = EditorGUILayout.FloatField("Wind", traits.WindAttunementMultiplier);
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
                traits.HealthAddition =
                    EditorGUILayout.IntField("Health ", traits.HealthAddition);
                traits.MagicAddition =
                    EditorGUILayout.IntField("Special ", traits.MagicAddition);
                traits.StrengthAddition = EditorGUILayout.IntField("Strength", traits.StrengthAddition);
                traits.DefenseAddition = EditorGUILayout.IntField("Defense", traits.DefenseAddition);
                traits.IntelligenceAddition =
                    EditorGUILayout.IntField("Intelligence", traits.IntelligenceAddition);
                traits.ResistanceAddition = EditorGUILayout.IntField("Resistance", traits.ResistanceAddition);
                traits.PrecisionAddition = EditorGUILayout.IntField("Precision", traits.PrecisionAddition);
                traits.AgilityAddition = EditorGUILayout.IntField("Agility", traits.AgilityAddition);
                EditorGUI.indentLevel--;
            }
            showAddiAff = EditorGUILayout.Foldout(showAddiAff, "Attunement");
            if (showAddiAff) {
                EditorGUI.indentLevel++;
                traits.FireAttunementAddition = EditorGUILayout.IntField("Fire", traits.FireAttunementAddition);
                traits.IceAttunementAddition = EditorGUILayout.IntField("Ice", traits.IceAttunementAddition);
                traits.WindAttunementAddition = EditorGUILayout.IntField("Wind", traits.WindAttunementAddition);
                EditorGUI.indentLevel--;
            }
            EditorGUI.indentLevel--;
        }

        showOnHit = EditorGUILayout.Foldout(showOnHit, "On Hit");
        if (showOnHit) {
            EditorGUI.indentLevel++;
            traits.HealthOnHit = EditorGUILayout.IntField("Gain Health on Hit", traits.HealthOnHit);
            traits.MagicOnHit = EditorGUILayout.IntField("Gain Magic on Hit", traits.MagicOnHit);
            EditorGUI.indentLevel--;
        }

        showOnKill = EditorGUILayout.Foldout(showOnKill, "On Kill");
        if (showOnKill) {
            EditorGUI.indentLevel++;
            traits.HealthOnKill = EditorGUILayout.IntField("Gain Health on Kill", traits.HealthOnKill);
            traits.MagicOnKill = EditorGUILayout.IntField("Gain Magic on Kill", traits.MagicOnKill);
            EditorGUI.indentLevel--;
        }
    }

    public void PrintTraitLabel(Trait trait) {
        EditorGUILayout.LabelField(trait.Name);
        EditorGUILayout.LabelField(trait.Description);
        
        if (trait.HealthOnHit != 0) {
            EditorGUILayout.LabelField("Health on Hit", trait.HealthOnHit.ToString());
        }
        if (trait.MagicOnHit != 0) {
            EditorGUILayout.LabelField("Magic on Hit", trait.MagicOnHit.ToString());
        }

        if (trait.HealthOnKill != 0) {
            EditorGUILayout.LabelField("Health on Kill", trait.HealthOnKill.ToString());
        }
        if (trait.MagicOnKill != 0) {
            EditorGUILayout.LabelField("Magic on Kill", trait.MagicOnKill.ToString());
        }

        if (trait.MoveAddition != 0) {
            EditorGUILayout.LabelField("Adds " + trait.MoveAddition + " Move");
        }
        if (Math.Abs(trait.JumpAddition) > 0) {
            EditorGUILayout.LabelField("Adds " + trait.JumpAddition + " Jump");
        }
        if (trait.HealthAddition != 0) {
            EditorGUILayout.LabelField("Adds " + trait.HealthAddition + " Health");
        }
        if (trait.MagicAddition != 0) {
            EditorGUILayout.LabelField("Adds " + trait.MagicAddition + " Magic");
        }
        if (trait.StrengthAddition != 0) {
            EditorGUILayout.LabelField("Adds " + trait.StrengthAddition + " Strength");
        }
        if (trait.DefenseAddition != 0) {
            EditorGUILayout.LabelField("Adds " + trait.DefenseAddition + " Defense");
        }
        if (trait.IntelligenceAddition != 0) {
            EditorGUILayout.LabelField("Adds " + trait.IntelligenceAddition + " Intelligence");
        }
        if (trait.ResistanceAddition != 0) {
            EditorGUILayout.LabelField("Adds " + trait.ResistanceAddition + " Resistance");
        }
        if (trait.PrecisionAddition != 0) {
            EditorGUILayout.LabelField("Adds " + trait.PrecisionAddition + " Precision");
        }
        if (trait.AgilityAddition != 0) {
            EditorGUILayout.LabelField("Adds " + trait.AgilityAddition + " Agility");
        }
        if (trait.FireAttunementAddition != 0) {
            EditorGUILayout.LabelField("Adds " + trait.FireAttunementAddition + " Fire Attunement");
        }
        if (trait.IceAttunementAddition != 0) {
            EditorGUILayout.LabelField("Adds " + trait.IceAttunementAddition + " Ice Attunement");
        }
        if (trait.WindAttunementAddition != 0) {
            EditorGUILayout.LabelField("Adds " + trait.WindAttunementAddition + " Wind Attunement");
        }

        if (Math.Abs(trait.MoveMultiplier) > 0) {
            EditorGUILayout.LabelField("Has " + trait.MoveMultiplier * 100 + "% Move");
        }
        if (Math.Abs(trait.JumpMultiplier) > 0) {
            EditorGUILayout.LabelField("Has " + trait.JumpMultiplier * 100 + "% Jump");
        }
        if (Math.Abs(trait.HealthMultiplier) > 0) {
            EditorGUILayout.LabelField("Has " + trait.HealthMultiplier * 100 + "% Health");
        }
        if (Math.Abs(trait.MagicMultiplier) > 0) {
            EditorGUILayout.LabelField("Has " + trait.MagicMultiplier * 100 + "% Magic");
        }
        if (Math.Abs(trait.StrengthMultiplier) > 0) {
            EditorGUILayout.LabelField("Has " + trait.StrengthMultiplier * 100 + "% Strength");
        }
        if (Math.Abs(trait.DefenseMultiplier) > 0) {
            EditorGUILayout.LabelField("Has " + trait.DefenseMultiplier * 100 + "% Defense");
        }
        if (Math.Abs(trait.IntelligenceMultiplier) > 0) {
            EditorGUILayout.LabelField("Has " + trait.IntelligenceMultiplier * 100 + "% Intelligence");
        }
        if (Math.Abs(trait.ResistanceMultiplier) > 0) {
            EditorGUILayout.LabelField("Has " + trait.ResistanceMultiplier * 100 + "% Resistance");
        }
        if (Math.Abs(trait.PrecisionMultiplier) > 0) {
            EditorGUILayout.LabelField("Has " + trait.PrecisionMultiplier * 100 + "% Precision");
        }
        if (Math.Abs(trait.AgilityMultiplier) > 0) {
            EditorGUILayout.LabelField("Has " + trait.AgilityMultiplier * 100 + "% Agility");
        }
        if (Math.Abs(trait.FireAttunementMultiplier) > 0) {
            EditorGUILayout.LabelField("Has " + trait.FireAttunementMultiplier * 100 + "% Fire Attunement");
        }
        if (Math.Abs(trait.IceAttunementMultiplier) > 0) {
            EditorGUILayout.LabelField("Has " + trait.IceAttunementMultiplier * 100 + "% Ice Attunement");
        }
        if (Math.Abs(trait.WindAttunementMultiplier) > 0) {
            EditorGUILayout.LabelField("Has " + trait.WindAttunementMultiplier * 100 + "% Wind Attunement");
        }
    }
}