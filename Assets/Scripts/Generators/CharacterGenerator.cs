using System;
using UI;
using Unit;
using UnityEngine;
using Random = UnityEngine.Random;


[RequireComponent(typeof(StatsGenerator))]
[RequireComponent(typeof(TraitGenerator))]
[RequireComponent(typeof(NameGenerator))]
public class CharacterGenerator : MonoBehaviour
{
    public TurnManager TurnManager;
    public UnitUIManager UnitUiManager;
    public GameObject[] RedCharaPrefabs; //0 Acolyte || 1 Esquire || 2 Brute || 3 Rogue || 4 Ruler
    public GameObject[] BlueCharaPrefabs; //0 Acolyte || 1 Esquire || 2 Brute || 3 Rogue || 4 Ruler
    public GameObject[] BasePrefabs; //0 Normal || 1 Magic || 2 Rare
    public GameObject[] AttackPrefabs; //0 STR || 1 INT || 2 PRC

    [SerializeField] private Camera cam;

    [SerializeField] private NameGenerator nameGen;
    [SerializeField] private TraitGenerator traitGen;
    [SerializeField] private StatsGenerator statsGen;

    private Character _character;

    public GameObject Generate(Rarity rarity, Transform parent)
    {
        GameObject go = new GameObject();
        go.transform.SetParent(parent, false);
        go.AddComponent<Character>();
        SetupCharacter(rarity, go);

        Instantiate(BasePrefabs[(int) _character.Rarity], go.transform);
        for (int i = 0; i < (int) _character.Rarity; i++)
        {
            _character.Traits.Add(traitGen.GetTrait(go.transform));
        }

        InstantiateModel(go, TurnManager.CurrentTeam);
        AddAttack(go);
        _character.Stats = statsGen.AlterWithTraits(statsGen.GetStats(_character.Type), _character);
        go.name = $"[{_character.Rarity}] {_character.Name} {_character.Type}";
        return go;
    }

    public GameObject Generate(CharacterType type, Rarity rarity, Player owner, Transform parent)
    {
        GameObject go = new GameObject();
        go.transform.SetParent(parent, false);
        go.AddComponent<Character>();
        SetupCharacter(rarity, go, owner);

        Instantiate(BasePrefabs[(int) _character.Rarity], go.transform);
        for (int i = 0; i < (int) _character.Rarity; i++)
        {
            var trait = traitGen.GetTrait(go.transform);
            trait.SetUI(_character.DamageUI);
            _character.Traits.Add(trait);
        }

        InstantiateModel(go, owner.Color, type);
        AddAttack(go);
        _character.Stats = statsGen.AlterWithTraits(statsGen.GetStats(_character.Type), _character);
        go.name = string.Format("[{0}] {1} {2}", _character.Rarity, _character.Name, _character.Type);
        return go;
    }

    private void SetupCharacter(Rarity rarity, GameObject go, Player owner)
    {
        _character = go.GetComponent<Character>();
        _character.Name = nameGen.GetName();
        _character.Rarity = rarity;
        _character.MoveType = MovementType.Straight;
        _character.Ownable = go.AddComponent<Ownable>();
        if (owner == null)
        {
            _character.Ownable.Initialize(TurnManager.CurrentPlayer);
        }
        else
        {
            _character.Ownable.Initialize(owner);
        }

        _character.UnitUI = UnitUiManager;
        _character.TurnManager = TurnManager;
    }

    private void SetupCharacter(Rarity rarity, GameObject go)
    {
        SetupCharacter(rarity, go, null);
    }

    private void InstantiateModel(GameObject go, Player.TeamColor color)
    {
        var charaRoll = (CharacterType) Random.Range(0, RedCharaPrefabs.Length - 1);
        InstantiateModel(go, color, charaRoll);
//        _character.Skills = _skillGen.GetSkills(_character.Type);
    }

    private void InstantiateModel(GameObject go, Player.TeamColor color, CharacterType type)
    {
        _character.Type = type;
//        _character.Skills = _skillGen.GetSkills(_character.Type);
        GameObject model;
        if (color == Player.TeamColor.Red)
        {
            model = Instantiate(RedCharaPrefabs[(int) type], go.transform);
        }
        else
        {
            model = Instantiate(BlueCharaPrefabs[(int) type], go.transform);
        }

        _character.DamageUI = model.GetComponentInChildren<DamageUI>();
        _character.DamageUI.Camera = cam;
    }

    private void AddAttack(GameObject go)
    {
        GameObject attack = null;
        switch (_character.Type)
        {
            case CharacterType.Acolyte:
                attack = Instantiate(AttackPrefabs[1]);
                break;
            case CharacterType.Esquire:
                attack = Instantiate(AttackPrefabs[0]);
                break;
            case CharacterType.Brute:
                attack = Instantiate(AttackPrefabs[0]);
                break;
            case CharacterType.Rogue:
                attack = Instantiate(AttackPrefabs[2]);
                break;
            case CharacterType.Ruler:
                attack = Instantiate(AttackPrefabs[0]);
                break;
        }

        if (attack == null) throw new Exception("Failed to generate attack");
        attack.transform.SetParent(go.transform, false);
        _character.Attack = attack.GetComponent<Attack>();
    }
}