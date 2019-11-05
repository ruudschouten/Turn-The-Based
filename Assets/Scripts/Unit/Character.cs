using System.Collections.Generic;
using Tiles;
using Turn;
using UI;
using UI.Managers;
using Unit.Statistics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Unit
{
    public class Character : MonoBehaviour, IPointerClickHandler
    {
        #region Editor Fields

        [SerializeField] private new string name;
        [SerializeField] private Stats stats;
        [SerializeField] private Rarity rarity;
        [SerializeField] private CharacterType type;
        [SerializeField] private MovementType moveType;
        [SerializeField] private List<Trait> traits = new List<Trait>();
        [SerializeField] private Ownable ownable;

        //Attacks
        [SerializeField] private Attack attack;
        [SerializeField] private bool hasAttackedThisTurn;

        //UI
        [SerializeField] private UnitUIManager unitUi;
        [SerializeField] private DamageUI damageUi;

        [SerializeField] private UnityEvent onSelect;
        [SerializeField] private UnityEvent onAttack;
        [SerializeField] private UnityEvent onGetHit;
        [SerializeField] private UnityEvent onDeath;
        [SerializeField] private UnityEvent onGameOver;
    
        #endregion
    
        #region Properties

        public string Name
        {
            get => name;
            set => name = value;
        }

        public Stats Stats
        {
            get => stats;
            set => stats = value;
        }

        public Rarity Rarity
        {
            get => rarity;
            set => rarity = value;
        }

        public CharacterType Type
        {
            get => type;
            set => type = value;
        }

        public MovementType MoveType
        {
            get => moveType;
            set => moveType = value;
        }

        public Attack Attack
        {
            get => attack;
            set => attack = value;
        }

        public bool HasAttackedThisTurn
        {
            get => hasAttackedThisTurn;
            set => hasAttackedThisTurn = value;
        }

        public Ownable Ownable => ownable;
        public TurnManager TurnManager { get; set; }
    
        public UnitUIManager UnitUI
        {
            get => unitUi;
            set => unitUi = value;
        }

        public DamageUI DamageUI
        {
            get => damageUi;
            set => damageUi = value;
        }

        public List<Trait> Traits => traits;
    
        #endregion

        private Tile _turnStartTile;

        public void Start()
        {
            Ownable.TurnStartEvent.AddListener(NewTurn);
            Ownable.TurnStartEvent.AddListener(TriggerStartTurn);
            
            Ownable.TurnEndEvent.AddListener(TriggerEndTurn);
            NewTurn();
        }

        private void NewTurn()
        {
            _turnStartTile = GetTile();
            hasAttackedThisTurn = false;
        }

        private void TriggerStartTurn()
        {
            foreach (var trait in traits)
            {
                trait.OnTurnStart(TurnManager, this);
            }
        }

        private void TriggerEndTurn()
        {
            foreach (var trait in traits)
            {
                trait.OnTurnEnd(TurnManager, this);
            }
        }

        public Tile GetStartTile()
        {
            if (_turnStartTile == null)
            {
                NewTurn();
            }

            return _turnStartTile;
        }

        public bool IsAlive()
        {
            return stats.Resources.Health > 0;
        }

        public void GetHit(Character attacker)
        {
            //Only attack enemies
            if (Ownable.GetOwner() == TurnManager.CurrentPlayer) return;

            TurnManager.InAttackMode = false;
            
            if (attacker.hasAttackedThisTurn) return;
            
            attacker.onAttack.Invoke();
            if (attacker.attack.Perform(attacker, this))
            {
                if (!IsAlive())
                {
                    onDeath.Invoke();
                    foreach (var trait in attacker.Traits)
                    {
                        trait.OnKill(TurnManager, attacker);
                    }
                    
                    Die();
                }
                else
                {
                    onGetHit.Invoke();
                    foreach (var trait in attacker.traits)
                    {
                        trait.OnHit(TurnManager, attacker);
                    }
                }
            }

            attacker.hasAttackedThisTurn = true;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!IsAlive()) return;
            if (TurnManager.InAttackMode)
            {
                var attacker = unitUi.GetSelectedUnit();
                if (!attacker.hasAttackedThisTurn)
                {
                    if (transform.parent.GetComponentsInChildren<AttackHighlight>() != null)
                    {
                        GetHit(attacker);
                    }
                }

                TurnManager.InAttackMode = false;
                unitUi.Hide();
            }
            else
            {
                onSelect.Invoke();
                unitUi.Show(this);
                if (TurnManager.CurrentPlayer == Ownable.GetOwner())
                {
                    unitUi.ActionUI.Show(this);
                }
                else
                {
                    unitUi.ActionUI.Reset();
                }
            }
        }

        public void Die()
        {
            if (type == CharacterType.Ruler)
            {
                TurnManager.SetLoser(Ownable.GetOwner());
                onGameOver.Invoke();
            }
            
            // TODO: Disable after death sound is done

            gameObject.SetActive(false);
        }

        public Tile GetTile()
        {
            return transform.GetComponentInParent<Tile>();
        }

        public void PrepareAttack()
        {
            TurnManager.InAttackMode = true;
        }
    }
}