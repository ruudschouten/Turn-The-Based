using System.Collections.Generic;
using Assets.Scripts.Battle;
using Assets.Scripts.Generators;
using Tiles;
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

        public List<Trait> Traits = new List<Trait>();

        //Attacks
        public Attack DefaultAttack;

        public List<Skill> Skills = new List<Skill>();

        //Resource
        public Resource Cost;
        [HideInInspector] public Ownable Ownable;
        [HideInInspector] public TurnManager TurnManager;
        [HideInInspector] public Vector3 TurnStartPos;
        
        //UI
        public UnitUIManager UnitUI;

        public void Start() {
            Ownable.TurnStartEvent.AddListener(SetStartPos);
        }

        private void SetStartPos() {
            TurnStartPos = GetTilePosition();
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

        
       
        public Vector3 GetTilePosition() {
            return transform.parent.transform.position;
        }
    }

    public enum CharacterType {
        Acolyte = 0, // Bird
        Esquire = 1, // Goat
        Brute = 2, // Roided Goat
        Rogue = 3, // Ermine
        Ruler = 4 // Wolf
    }
}