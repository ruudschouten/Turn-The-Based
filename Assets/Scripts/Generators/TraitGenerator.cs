using Unit;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


namespace Generators
{
    public class TraitGenerator : MonoBehaviour
    {
        [SerializeField] private Trait[] traitPrefabs;

        private int _lastIndex;

        public Trait GetTrait(Transform parent)
        {
            var traitGameObject = traitPrefabs[GetRandom(traitPrefabs.Length)];
            traitGameObject = Instantiate(traitGameObject, parent);
            return traitGameObject;
        }

        private int GetRandom(int length)
        {
            if (length <= 1)
            {
                return 0;
            }

            var randomIndex = _lastIndex;
            while (randomIndex == _lastIndex)
            {
                randomIndex = Random.Range(0, length);
            }

            _lastIndex = randomIndex;
            return randomIndex;
        }
    }
}