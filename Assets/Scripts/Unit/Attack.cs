using System;
using UI;
using UnityEngine;
using Random = UnityEngine.Random;


public class Attack : MonoBehaviour {
    public BoostedBy BoostedBy;
    public Element Element;
    public int BaseDamage = 4;
    [Range(0.25f, 2.5f)] public float DamageModifier = 1;
    public int Range = 1;
    public float Height = 1.5f;

    public int GetDamage(Character attacker, Character defender) {
        float damage = 0;
        var aStats = attacker.Stats;
        var dStats = defender.Stats;

        float attack = 0;
        float defense = 0;
        float element = 0;

        switch (BoostedBy) {
            case BoostedBy.Strength:
                attack = aStats.Strength * DamageModifier;
                defense = dStats.Defense;
                break;
            case BoostedBy.Intelligence:
                attack = aStats.Intelligence * DamageModifier;
                defense = dStats.Resistance;
                break;
            case BoostedBy.Precision:
                attack = aStats.Precision * DamageModifier;
                defense = dStats.Agility;
                break;
        }

        damage = BaseDamage + (attack - defense);

        switch (Element) {
            case Element.None:
                break;
            case Element.Fire:
                element = aStats.FireAttunement - dStats.FireAttunement;
                break;
            case Element.Ice:
                element = aStats.IceAttunement - dStats.IceAttunement;
                break;
            case Element.Wind:
                element = aStats.WindAttunement - dStats.WindAttunement;
                break;
        }

        damage *= 1 + (element / 100);
        
        return Convert.ToInt32(damage);
    }

    public float GetChanceToHit(Character attacker, Character defender) {
        //Tweak this so missing is possible
        return ((float) attacker.Stats.Precision / defender.Stats.Agility);
    }

    public bool Perform(Character attacker, Character defender) {
        float cth = GetChanceToHit(attacker, defender);
        int random = Random.Range(0, 100);
        if ((cth * 100) >= random) {
            int damage = GetDamage(attacker, defender);
            if (damage < 1) damage = 1;
            defender.Stats.Health -= damage;
            defender.DamageUI.ShowHealthDegrade(defender.Stats.MaxHealth, defender.Stats.Health);
            return true;
        }

        defender.DamageUI.ShowText("Dodged");
        return false;
    }
}


public enum BoostedBy {
    Strength,
    Intelligence,
    Precision
}

public enum Element {
    None,
    Fire,
    Ice,
    Wind
}