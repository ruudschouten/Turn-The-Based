using System.Collections.Generic;
using Assets.Scripts.Battle;
using Assets.Scripts.Generators;
using Assets.Scripts.Unit;
using UnityEditor;

namespace Assets.Scripts.Inspector {
    [CustomEditor(typeof(Character))]
    public class CharacterEditor : Editor {
        private bool _showStats;
        private bool _showTraits;
        private bool _showSkills;

        public override void OnInspectorGUI() {
            Character character = (Character) target;
            EditorGUILayout.LabelField("Name", character.Name);
            EditorGUILayout.LabelField("Rarity", character.Rarity.ToString());
            EditorGUILayout.LabelField("Type", character.Type.ToString());
            PrintCosts(character.Cost);
            _showStats = EditorGUILayout.Foldout(_showStats, "Stats");
            if (_showStats) {
                EditorGUI.indentLevel++;
                PrintStats(character.Stats);
                EditorGUI.indentLevel--;
            }
            if (character.Skills.Count != 0) {
                _showSkills = EditorGUILayout.Foldout(_showSkills, "Skills");
                if (_showSkills) {
                    foreach (var skill in character.Skills) {
                        PrintSkills(skill);
                    }
                }
            }
            if (character.Rarity != Rarity.Normal) {
                _showTraits = EditorGUILayout.Foldout(_showTraits, "Traits");
                if (_showTraits) {
                    EditorGUI.indentLevel++;
                    foreach (var trait in character.Traits) {
                        PrintTrait(trait);
                        EditorGUILayout.Space();
                    }
                    EditorGUI.indentLevel--;
                }
            }
        }

        private void PrintCosts(Resource cost) {
            if(cost != null)
            EditorGUILayout.LabelField(string.Format("{0}: {1}", cost.Name, cost.Amount));
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
