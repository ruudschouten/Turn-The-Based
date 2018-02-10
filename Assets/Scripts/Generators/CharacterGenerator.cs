using Assets.Scripts.Chara;
using UnityEngine;

namespace Assets.Scripts.Generators {
    [RequireComponent(typeof(StatsGenerator))]
    [RequireComponent(typeof(TraitGenerator))]
    [RequireComponent(typeof(NameGenerator))]
    public class CharacterGenerator : MonoBehaviour {
        public GameObject EmptyGameObj;
        public GameObject[] CharaPrefabs;
        public GameObject[] BasePrefabs;

        private NameGenerator nameGen;
        private TraitGenerator traitGen;
        private StatsGenerator statsGen;
        private RarityGetter rarityGetter;

        private Character character;

        public void Start() {
            nameGen = GetComponent<NameGenerator>();
            traitGen = GetComponent<TraitGenerator>();
            statsGen = GetComponent<StatsGenerator>();
            rarityGetter = new RarityGetter();
            Generate();
        }

        public void Generate() {
            GameObject go = Instantiate(EmptyGameObj);
            go.AddComponent<Character>();
            character = go.GetComponent<Character>();
            character.Name = nameGen.GetName();
            character.Rarity = rarityGetter.Calculate();
            for (int i = 0; i < (int) character.Rarity; i++) {
                character.Traits.Add(traitGen.GetTrait(go.transform));
            }
            character.Stats = statsGen.GetStats();
            Instantiate(BasePrefabs[(int) character.Rarity], go.transform);
            Instantiate(CharaPrefabs[Random.Range(0, CharaPrefabs.Length)], go.transform);
        }
    }
}
