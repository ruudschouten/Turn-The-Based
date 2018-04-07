using System.Collections.Generic;
using Assets.Scripts.Battle;
using Assets.Scripts.Generators;
using Assets.Scripts.Unit;
using Tiles;
using TreeEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Character : MonoBehaviour, IPointerClickHandler {
    public string Name;
    public Stats Stats;
    public Rarity Rarity;
    public CharacterType Type;
    public MovementType MoveType;
    public List<Trait> Traits = new List<Trait>();

    //Attacks
    public Attack Attack;
    public bool HasAttackedThisTurn;

    public List<Skill> Skills = new List<Skill>();

    //Resource
    public Resource Cost;
    [HideInInspector] public Ownable Ownable;
    [HideInInspector] public TurnManager TurnManager;
    private Tile _turnStartTile;

    //UI
    public UnitUIManager UnitUI;

    public void Start() {
        Ownable.TurnStartEvent.AddListener(NewTurn);
        NewTurn();
    }

    private void NewTurn() {
        _turnStartTile = GetTile();
        HasAttackedThisTurn = false;
    }

    public Tile GetStartTile() {
        if (_turnStartTile == null) {
            NewTurn();
        }

        return _turnStartTile;
    }

    public bool IsAlive() {
        return Stats.Health > 0;
    }

    public void Damage(Character other) {
        //Only attack enemies
        if (Ownable.GetOwner() == TurnManager.CurrentPlayer) return;

        TurnManager.InAttackMode = false;
        if (!other.HasAttackedThisTurn) {
            if (other.Attack.Perform(other, this)) {
                foreach (var traits in other.Traits) {
                    traits.OnHit(TurnManager, other);
                }
            }

            if (!IsAlive()) {
                foreach (var traits in other.Traits) {
                    traits.OnKill(TurnManager, other);
                }

                Die();
            }

            other.HasAttackedThisTurn = true;
        }
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (!IsAlive()) return;
//        Debug.Log(string.Format("Clicked {0}-{1}", Type, Name));
        if (TurnManager.CurrentPlayer == Ownable.GetOwner()) {
            UnitUI.ShowUI(this);
            UnitUI.ShowActionUI(this);
        }
        else {
            if (TurnManager.InAttackMode && !HasAttackedThisTurn) {
                if (Ownable.GetOwner() != TurnManager.CurrentPlayer) {
                    if (transform.parent.GetComponentsInChildren<AttackHighlight>() != null) {
                        //Only attack enemies
                        Damage(UnitUI.GetSelectedUnit());
                    }
                }

                TurnManager.InAttackMode = false;
                UnitUI.Hide();
            }
            else {
                UnitUI.ShowUI(this);
                UnitUI.HideActionUI();
            }
        }
    }

    public void Die() {
        if (Type == CharacterType.Ruler) {
            TurnManager.SetLoser(Ownable.GetOwner());
        }

        gameObject.SetActive(false);
    }

    public Tile GetTile() {
        return transform.GetComponentInParent<Tile>();
    }

    public void PrepareAttack() {
        Debug.Log("Preparing for attack");
        TurnManager.InAttackMode = true;
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