using System;
using Assets.Scripts.Unit;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Generators {
    [RequireComponent(typeof(StatsGenerator))]
    [RequireComponent(typeof(TraitGenerator))]
    [RequireComponent(typeof(SkillGenerator))]
    [RequireComponent(typeof(NameGenerator))]
    public class CharacterGenerator : MonoBehaviour {
        public TurnManager TurnManager;
        public UnitUIManager UnitUiManager;
        public GameObject[] RedCharaPrefabs; //0 Acolyte || 1 Esquire || 2 Brute || 3 Rogue || 4 Ruler
        public GameObject[] BlueCharaPrefabs; //0 Acolyte || 1 Esquire || 2 Brute || 3 Rogue || 4 Ruler
        public GameObject[] BasePrefabs; //0 Normal || 1 Magic || 2 Rare
        public GameObject[] AttackPrefabs; //0 STR || 1 INT || 2 PRC

        private NameGenerator nameGen;
        private TraitGenerator traitGen;
        private StatsGenerator statsGen;
        private SkillGenerator skillGen;

        private Character character;

        public void Start() {
            nameGen = GetComponent<NameGenerator>();
            traitGen = GetComponent<TraitGenerator>();
            statsGen = GetComponent<StatsGenerator>();
            skillGen = GetComponent<SkillGenerator>();
        }

        public GameObject Generate(Rarity rarity, Transform parent) {
            GameObject go = new GameObject();
            go.transform.SetParent(parent, false);
            go.AddComponent<Character>();
            SetupCharacter(rarity, go);

            Instantiate(BasePrefabs[(int) character.Rarity], go.transform);
            for (int i = 0; i < (int) character.Rarity; i++) {
                character.Traits.Add(traitGen.GetTrait(go.transform));
            }

            InstantiateModel(go, TurnManager.CurrentTeam);
            AddAttack(go);
            character.Stats = statsGen.AlterWithTraits(statsGen.GetStats(character.Type), character);
            go.name = string.Format("[{0}] {1} {2}", character.Rarity, character.Name, character.Type);
            return go;
        }

        public GameObject Generate(CharacterType type, Rarity rarity, Player owner, Transform parent) {
            GameObject go = new GameObject();
            go.transform.SetParent(parent, false);
            go.AddComponent<Character>();
            SetupCharacter(rarity, go, owner);

            Instantiate(BasePrefabs[(int) character.Rarity], go.transform);
            for (int i = 0; i < (int) character.Rarity; i++) {
                character.Traits.Add(traitGen.GetTrait(go.transform));
            }

            InstantiateModel(go, owner.Color, type);
            AddAttack(go);
            character.Stats = statsGen.AlterWithTraits(statsGen.GetStats(character.Type), character);
            go.name = string.Format("[{0}] {1} {2}", character.Rarity, character.Name, character.Type);
            return go;
        }

        private void SetupCharacter(Rarity rarity, GameObject go, Player owner) {
            character = go.GetComponent<Character>();
            character.Name = nameGen.GetName();
            character.Rarity = rarity;
            character.MoveType = MovementType.Straight;
            character.Ownable = go.AddComponent<Ownable>();
            if (owner == null) {
                character.Ownable.Initialize(TurnManager.CurrentPlayer);
            }
            else {
                character.Ownable.Initialize(owner);
            }

            character.UnitUI = UnitUiManager;
            character.TurnManager = TurnManager;
        }

        private void SetupCharacter(Rarity rarity, GameObject go) {
            SetupCharacter(rarity, go, null);
        }

        private void InstantiateModel(GameObject go, Player.TeamColor color) {
            int charaRoll = Random.Range(0, RedCharaPrefabs.Length - 1);
            character.Type = (CharacterType) charaRoll;
            character.Skills = skillGen.GetSkills(character.Type);
            if (color == Player.TeamColor.Red) {
                Instantiate(RedCharaPrefabs[charaRoll], go.transform);
            }
            else if (color == Player.TeamColor.Blue) {
                Instantiate(BlueCharaPrefabs[charaRoll], go.transform);
            }
        }

        private void InstantiateModel(GameObject go, Player.TeamColor color, CharacterType type) {
            character.Type = type;
            character.Skills = skillGen.GetSkills(character.Type);
            if (color == Player.TeamColor.Red) {
                Instantiate(RedCharaPrefabs[(int) type], go.transform);
            }
            else if (color == Player.TeamColor.Blue) {
                Instantiate(BlueCharaPrefabs[(int) type], go.transform);
            }
        }

        private void AddAttack(GameObject go) {
            GameObject attack = null;
            switch (character.Type) {
                case CharacterType.Acolyte:
                    attack = Instantiate(AttackPrefabs[1]);
                    break;
                case CharacterType.Esquire:
                    attack = Instantiate(AttackPrefabs[0]);
                    break;
                case CharacterType.Brute:
                    attack = Instantiate(AttackPrefabs[0]);
                    break;
                case CharacterType.Rogue:
                    attack = Instantiate(AttackPrefabs[2]);
                    break;
                case CharacterType.Ruler:
                    attack = Instantiate(AttackPrefabs[0]);
                    break;
            }
            if(attack == null) throw new Exception("Failed to generate attack");
            attack.transform.SetParent(go.transform, false);
            character.Attack = attack.GetComponent<Attack>();
        }
    }
}