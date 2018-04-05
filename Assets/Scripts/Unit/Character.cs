using System.Collections.Generic;
using Assets.Scripts.Battle;
using Assets.Scripts.Generators;
using Tiles;
using TreeEditor;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Unit {
    [RequireComponent(typeof(Selectable))]
    public class Character : MonoBehaviour, IPointerClickHandler {
        public string Name;
        public Stats Stats;
        public Rarity Rarity;
        public CharacterType Type;
        public MovementType MoveType;

        public List<Trait> Traits = new List<Trait>();

        //Attacks
        public Attack DefaultAttack;

        public List<Skill> Skills = new List<Skill>();

        //Resource
        public Resource Cost;
        [HideInInspector] public Ownable Ownable;
        [HideInInspector] public TurnManager TurnManager;
//        [HideInInspector] public Vector3 TurnStartPos;
        [HideInInspector] private Tile _turnStartTile;

        //UI
        public UnitUIManager UnitUI;

        public void Start() {
            Ownable.TurnStartEvent.AddListener(SetStartTile);
            SetStartTile();
        }

//        private void SetStartPos() {
//            TurnStartPos = GetTilePosition();
//        }

        private void SetStartTile() {
            _turnStartTile = GetTile();
        }

        public Tile GetStartTile() {
            if (_turnStartTile == null) {
                SetStartTile();
            }

            return _turnStartTile;
        }

        public void OnPointerClick(PointerEventData eventData) {
            Debug.Log(string.Format("Clicked {0}-{1}", Type, Name));
            UnitUI.ShowUI(this);
            if (TurnManager.CurrentPlayer == Ownable.GetOwner()) {
                UnitUI.ShowUI(this);
                UnitUI.ShowActionUI(this);
            }
            else {
                UnitUI.HideActionUI();
            }
        }

        public Tile GetTile() {
            var t = transform.GetComponentInParent<Tile>();
            return t;
        }
    }

    public enum CharacterType {
        Acolyte = 0, // Bird
        Esquire = 1, // Goat
        Brute = 2, // Roided Goat
        Rogue = 3, // Ermine
        Ruler = 4 // Wolf
    }

    public enum MovementType {
        Straight,
        Radial,
        Diagonal
    }
}