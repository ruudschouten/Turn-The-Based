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
        private RarityGetter rarityGetter;

        private Character character;

        public void Start() {
            nameGen = GetComponent<NameGenerator>();
            traitGen = GetComponent<TraitGenerator>();
            statsGen = GetComponent<StatsGenerator>();
            skillGen = GetComponent<SkillGenerator>();
            rarityGetter = new RarityGetter();
        }

        public void Generate() {
            GameObject go = new GameObject();
            go.AddComponent<Character>();
            character = go.GetComponent<Character>();
            character.Name = nameGen.GetName();
            character.Rarity = rarityGetter.Calculate();
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
        }

        private void InstantiateModel(GameObject go, Player.TeamColor color) {
            if (color == Player.TeamColor.Red) {
                int charaRoll = Random.Range(0, RedCharaPrefabs.Length);
                character.Type = (CharacterType) charaRoll;
                character.Skills = skillGen.GetSkills(character.Type);
                Instantiate(RedCharaPrefabs[charaRoll], go.transform);
            }
            else if (color == Player.TeamColor.Blue) {
                int charaRoll = Random.Range(0, BlueCharaPrefabs.Length);
                character.Type = (CharacterType) charaRoll;
                character.Skills = skillGen.GetSkills(character.Type);
                Instantiate(BlueCharaPrefabs[charaRoll], go.transform);
            }
        }
    }
}
