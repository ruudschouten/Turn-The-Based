using UnityEngine;
using Random = UnityEngine.Random;


public class NameGenerator : MonoBehaviour {
    public string[] Names;
    private int _lastIndex;

    public string GetName() {
        return Names[GetRandom(Names.Length)];
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