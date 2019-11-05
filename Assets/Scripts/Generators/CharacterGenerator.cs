using System;
using Turn;
using UI.Managers;
using Unit;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Generators
{
    [RequireComponent(typeof(StatsGenerator))]
    [RequireComponent(typeof(TraitGenerator))]
    [RequireComponent(typeof(NameGenerator))]
    public class CharacterGenerator : MonoBehaviour
    {
        [SerializeField] private TurnManager turnManager;
        [SerializeField] private UnitUIManager unitUiManager;
        [SerializeField] private Character characterPrefab;
        [SerializeField] private GameObject[] redCharaPrefabs; //0 Acolyte || 1 Esquire || 2 Brute || 3 Rogue || 4 Ruler
        [SerializeField] private GameObject[] blueCharaPrefabs; //0 Acolyte || 1 Esquire || 2 Brute || 3 Rogue || 4 Ruler
        [SerializeField] private GameObject[] basePrefabs; //0 Normal || 1 Magic || 2 Rare
        [SerializeField] private Attack[] attackPrefabs; //0 STR || 1 INT || 2 PRC

        [SerializeField] private Camera cam;

        [SerializeField] private NameGenerator nameGen;
        [SerializeField] private TraitGenerator traitGen;
        [SerializeField] private StatsGenerator statsGen;

        private Character _newCharacter;
        
        public Character Generate(Rarity rarity, Transform parent)
        {
            var type = GetRandomCharacterType();
            return Generate(type, rarity, parent, turnManager.CurrentPlayer);
        }

        public Character Generate(CharacterType type, Rarity rarity, Transform parent, Player owner)
        {
            _newCharacter = Instantiate(characterPrefab, parent);
            
            SetValues(type, rarity, owner);

            Instantiate(basePrefabs[(int) rarity], _newCharacter.transform);
            
            InstantiateModel(owner.Color);
            
            for (var i = 0; i < (int) _newCharacter.Rarity; i++)
            {
                var trait = traitGen.GetTrait(_newCharacter.transform);
                trait.SetUI(_newCharacter.DamageUI);
                _newCharacter.Traits.Add(trait);
            }
            
            SetAttack();
            
            _newCharacter.Stats = statsGen.AlterWithTraits(statsGen.GetStats(_newCharacter.Type), _newCharacter);
            
            _newCharacter.name = $"[{_newCharacter.Rarity}] {_newCharacter.Name} {_newCharacter.Type}";
            
            return _newCharacter;
        }
        
        private void SetValues(CharacterType type, Rarity rarity, Player owner)
        {
            _newCharacter.Name = nameGen.GetName();
            _newCharacter.Type = type;
            _newCharacter.Rarity = rarity;
            _newCharacter.MoveType = MovementType.Straight;

            _newCharacter.UnitUI = unitUiManager;
            _newCharacter.TurnManager = turnManager;  
            
            _newCharacter.DamageUI.Camera = cam;
            
            _newCharacter.Ownable.Initialize(owner);
        }

        private CharacterType GetRandomCharacterType()
        {
            return (CharacterType) Random.Range(0, redCharaPrefabs.Length - 1);
        }

        private void InstantiateModel(Player.TeamColor color)
        {
            var index = (int) _newCharacter.Type;
            var model = color == Player.TeamColor.Red ? redCharaPrefabs[index] : blueCharaPrefabs[index];
            
            Instantiate(model, _newCharacter.transform);
        }

        private void SetAttack()
        {
            Attack attack;
            switch (_newCharacter.Type)
            {
                case CharacterType.Acolyte:
                    attack = Instantiate(attackPrefabs[1], _newCharacter.transform);
                    break;
                case CharacterType.Esquire:
                    attack = Instantiate(attackPrefabs[0], _newCharacter.transform);
                    break;
                case CharacterType.Brute:
                    attack = Instantiate(attackPrefabs[0], _newCharacter.transform);
                    break;
                case CharacterType.Rogue:
                    attack = Instantiate(attackPrefabs[2], _newCharacter.transform);
                    break;
                case CharacterType.Ruler:
                    attack = Instantiate(attackPrefabs[0], _newCharacter.transform);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            _newCharacter.Attack = attack;
        }
    }
}