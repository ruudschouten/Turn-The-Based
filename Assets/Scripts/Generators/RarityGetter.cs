using System.Linq;
using UnityEngine;

public class RarityGetter {
    public Rarity Calculate() {
        int normalChance = Random.Range(0, 100);
        int magicChance = Random.Range(0, 100);
        int rareChance = Random.Range(0, 100);
        int[] nums = {normalChance, magicChance, rareChance};
        int max = nums.Max();
        if (max == normalChance) return Rarity.Normal;
        if (max == magicChance) return Rarity.Magic;
        if (max == rareChance) return Rarity.Rare;
        return Rarity.Normal;
    }
}

public enum Rarity {
    Normal = 0,
    Magic = 1,
    Rare = 2
}