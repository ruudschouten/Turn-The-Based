using System.Collections.Generic;
using UnityEngine;


public class SkillGenerator : MonoBehaviour {
    public Skill[] AcolyteSkills;
    public Skill[] EsquireSkills;
    public Skill[] BruteSkills;
    public Skill[] RogueSkills;
    public Skill[] RulerSkills;

    public List<Skill> GetSkills(CharacterType type) {
        List<Skill> skills = new List<Skill>();

        switch (type) {
            case CharacterType.Acolyte:
                skills.AddRange(AcolyteSkills);
                break;
            case CharacterType.Esquire:
                skills.AddRange(EsquireSkills);
                break;
            case CharacterType.Brute:
                skills.AddRange(BruteSkills);
                break;
            case CharacterType.Rogue:
                skills.AddRange(RogueSkills);
                break;
            case CharacterType.Ruler:
                skills.AddRange(RulerSkills);
                break;
        }

        return skills;
    }
}