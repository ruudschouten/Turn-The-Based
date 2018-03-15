using System.Collections.Generic;
using Assets.Scripts.Battle;
using Assets.Scripts.Generators;
using Assets.Scripts.Unit;
using UnityEditor;

namespace Assets.Scripts.Inspector {
    [CustomEditor(typeof(Character))]
    public class CharacterEditor : Editor {
        private bool showStats;
        private bool showTraits;
        private bool showSkills;

        public override void OnInspectorGUI() {
            Character character = (Character) target;
            EditorGUILayout.LabelField("Name", character.Name);
            EditorGUILayout.LabelField("Rarity", character.Rarity.ToString());
            EditorGUILayout.LabelField("Type", character.Type.ToString());
            showStats = EditorGUILayout.Foldout(showStats, "Stats");
            if (showStats) {
                EditorGUI.indentLevel++;
                PrintStats(character.Stats);
                EditorGUI.indentLevel--;
            }
            if (character.Skills.Count != 0) {
                showSkills = EditorGUILayout.Foldout(showSkills, "Skills");
                if (showSkills) {
                    foreach (var skill in character.Skills) {
                        PrintSkills(skill);
                    }
                }
            }
            if (character.Rarity != Rarity.Normal) {
                showTraits = EditorGUILayout.Foldout(showTraits, "Traits");
                if (showTraits) {
                    EditorGUI.indentLevel++;
                    foreach (var trait in character.Traits) {
                        PrintTrait(trait);
                        EditorGUILayout.Space();
                    }
                    EditorGUI.indentLevel--;
                }
            }
        }

        private void PrintCosts(Dictionary<Resource, int> costs) {
            
        }

        private void PrintStats(Stats stats) {
            StatsEditor statsEditor = new StatsEditor();
            statsEditor.PrintStatsLabel(stats);
        }

        private void PrintSkills(Skill skill) {
            SkillEditor skillEditor = new SkillEditor();
            skillEditor.PrintLabel(skill);
        }

        private void PrintTrait(Trait trait) {
            TraitEditor traitEditor = new TraitEditor();
            traitEditor.PrintTraitLabel(trait);
        }
    }
}
