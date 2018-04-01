using Assets.Scripts.Unit;
using UnityEngine;

namespace Assets.Scripts.Generators {
    [RequireComponent(typeof(StatsGenerator))]
    [RequireComponent(typeof(TraitGenerator))]
    [RequireComponent(typeof(SkillGenerator))]
    [RequireComponent(typeof(NameGenerator))]
    public class CharacterGenerator : MonoBehaviour {
        public TurnManager TurnManager;
        public UnitUIManager UnitUiManager;
        public GameObject[] RedCharaPrefabs;
        public GameObject[] BlueCharaPrefabs;
        public GameObject[] BasePrefabs;

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
            character = go.GetComponent<Character>();
            character.Name = nameGen.GetName();
            character.Rarity = rarity;
            character.Ownable = go.AddComponent<Ownable>();
            character.Ownable.Initialize(TurnManager.CurrentPlayer);
            character.UnitUI = UnitUiManager;
            character.TurnManager = TurnManager;
            Instantiate(BasePrefabs[(int)character.Rarity], go.transform);
            for (int i = 0; i < (int) character.Rarity; i++) {
                character.Traits.Add(traitGen.GetTrait(go.transform));
            }
            InstantiateModel(go, TurnManager.CurrentTeam);
            character.Stats = statsGen.AlterWithTraits(statsGen.GetStats(character.Type), character);
            go.name = string.Format("[{0}] {1} {2}",character.Rarity, character.Name, character.Type);
            return go;
        }
        
        public GameObject Generate(CharacterType type, Rarity rarity, Player owner, Transform parent) {
            GameObject go = new GameObject();
            go.transform.SetParent(parent, false);
            go.AddComponent<Character>();
            character = go.GetComponent<Character>();
            character.Name = nameGen.GetName();
            character.Rarity = rarity;
            character.Ownable = go.AddComponent<Ownable>();
            character.Ownable.Initialize(owner);
            character.UnitUI = UnitUiManager;
            character.TurnManager = TurnManager;
            Instantiate(BasePrefabs[(int)character.Rarity], go.transform);
            for (int i = 0; i < (int) character.Rarity; i++) {
                character.Traits.Add(traitGen.GetTrait(go.transform));
            }
            InstantiateModel(go, owner.Color, type);
            character.Stats = statsGen.AlterWithTraits(statsGen.GetStats(character.Type), character);
            go.name = string.Format("[{0}] {1} {2}",character.Rarity, character.Name, character.Type);
            return go;
        }

        private void InstantiateModel(GameObject go, Player.TeamColor color) {
            if (color == Player.TeamColor.Red) {
                int charaRoll = Random.Range(0, RedCharaPrefabs.Length - 1);
                character.Type = (CharacterType) charaRoll;
                character.Skills = skillGen.GetSkills(character.Type);
                Instantiate(RedCharaPrefabs[charaRoll], go.transform);
            }
            else if (color == Player.TeamColor.Blue) {
                int charaRoll = Random.Range(0, BlueCharaPrefabs.Length - 1);
                character.Type = (CharacterType) charaRoll;
                character.Skills = skillGen.GetSkills(character.Type);
                Instantiate(BlueCharaPrefabs[charaRoll], go.transform);
            }
        }
        
        private void InstantiateModel(GameObject go, Player.TeamColor color, CharacterType type) {
            if (color == Player.TeamColor.Red) {
                character.Type = type;
                character.Skills = skillGen.GetSkills(character.Type);
                Instantiate(RedCharaPrefabs[(int) type], go.transform);
            }
            else if (color == Player.TeamColor.Blue) {
                character.Type = type;
                character.Skills = skillGen.GetSkills(character.Type);
                Instantiate(BlueCharaPrefabs[(int) type], go.transform);
            }
        }
    }
}
