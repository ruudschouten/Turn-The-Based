using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Battle;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Inspector {
    [CustomEditor(typeof(Skill))]
    public class SkillEditor : Editor {
        public bool showAreaOfEffect;

        public override void OnInspectorGUI() {
            Skill skill = (Skill) target;
            skill.Name = EditorGUILayout.TextField("Name", skill.Name);
            skill.Element = (Element) EditorGUILayout.EnumPopup("Element", skill.Element);
            skill.BoostedBy = (BoostedBy) EditorGUILayout.EnumPopup("Boosted By", skill.BoostedBy);
            skill.ManaCost = EditorGUILayout.IntField("Mana Cost", skill.ManaCost);
            skill.Range = EditorGUILayout.IntField("Range", skill.Range);
            skill.Height = EditorGUILayout.FloatField("Height", skill.Height);
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Damage Modifier");
            skill.DamageModifier = EditorGUILayout.Slider(skill.DamageModifier, 0.25f, 2.5f);
            EditorGUILayout.EndHorizontal();
            skill.Diagonal = EditorGUILayout.Toggle("Diagonal", skill.Diagonal);
            skill.Heals = EditorGUILayout.Toggle("Heals", skill.Heals);
            skill.HasAoE = EditorGUILayout.Toggle("Has Area of Effect", skill.HasAoE);
            if (skill.HasAoE) {
                skill.HighlightPrefab =
                    (GameObject) EditorGUILayout.ObjectField(skill.HighlightPrefab, typeof(GameObject), true);
                showAreaOfEffect = EditorGUILayout.Foldout(showAreaOfEffect, "Area of Effect");
            }
            if (showAreaOfEffect) {
                EditorGUI.indentLevel++;
                skill.AreaOfEffectSize = EditorGUILayout.IntField("Size", skill.AreaOfEffectSize);
                EditorGUI.indentLevel--;
                if (Application.isPlaying) {
                    if (GUILayout.Button("Show AoE")) {
                        skill.DrawAoE();
                    }
                }
            }
        }
    }
}