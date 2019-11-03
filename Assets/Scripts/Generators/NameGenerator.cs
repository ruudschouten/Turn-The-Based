using UnityEngine;
using Random = UnityEngine.Random;

namespace Generators
{
    public class NameGenerator : MonoBehaviour
    {
        [SerializeField] private string[] names;

        private int _lastIndex;

        public string GetName()
        {
            return names[GetRandom(names.Length)];
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