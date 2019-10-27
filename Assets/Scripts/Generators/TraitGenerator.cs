using Unit;
using UnityEngine;
using Random = UnityEngine.Random;


public class TraitGenerator : MonoBehaviour {
    public GameObject[] TraitPrefabs;

    private int _lastIndex;

    public Trait GetTrait(Transform parent) {
        GameObject traitGameObject = TraitPrefabs[GetRandom(TraitPrefabs.Length)];
        traitGameObject = Instantiate(traitGameObject, parent);
        return traitGameObject.GetComponent<Trait>();
    }

    int GetRandom(int length) {
        if (length <= 1) {
            return 0;
        }

        int randomIndex = _lastIndex;
        while (randomIndex == _lastIndex) {
            randomIndex = Random.Range(0, length);
        }

        _lastIndex = randomIndex;
        return randomIndex;
    }
}