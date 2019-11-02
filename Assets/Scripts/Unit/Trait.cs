﻿using NaughtyAttributes;
using UI;
using Unit.Statistics;
using UnityEngine;
using Resources = Unit.Statistics.Resources;

namespace Unit
{
    public class Trait : MonoBehaviour
    {
        public string Name;
        [SerializeField] private string description;

        #region Toggles

        [BoxGroup("Movement Types")] [SerializeField] private bool diagonalOnly;
        [BoxGroup("Movement Types")] [SerializeField] private bool radialOnly;

        #endregion

        [BoxGroup("Triggers")] [SerializeField] private Trigger onHitTriggers;
        [BoxGroup("Triggers")] [SerializeField] private Trigger onKillTriggers;
        [BoxGroup("Triggers")] [SerializeField] private Trigger onTurnStartTriggers;
        [BoxGroup("Triggers")] [SerializeField] private Trigger onTurnEndTriggers;

        #region Additions

        [BoxGroup("Addition")] [SerializeField] private Resources resourceAddition;
        [BoxGroup("Addition")] [SerializeField] private Attributes attributeAddition;
        [BoxGroup("Addition")] [SerializeField] private Movement movementAddition;
        [BoxGroup("Addition")] [SerializeField] private Combat combatAddition;
        [BoxGroup("Addition")] [SerializeField] private Attunement attunementAddition;

        #endregion

        [BoxGroup("Modifier")] [SerializeField] private Resources resourceModifier;
        [BoxGroup("Modifier")] [SerializeField] private Attributes attributeModifier;
        [BoxGroup("Modifier")] [SerializeField] private Movement movementModifier;
        [BoxGroup("Modifier")] [SerializeField] private Combat combatModifier;
        [BoxGroup("Modifier")] [SerializeField] private Attunement attunementModifier;

        public string Description => description;
        public bool RadialOnly => radialOnly;
        public bool DiagonalOnly => diagonalOnly;
        public Trigger OnHitTriggers => onHitTriggers;
        public Trigger OnKillTriggers => onKillTriggers;
        public Trigger OnTurnStartTriggers => onTurnStartTriggers;
        public Trigger OnTurnEndTriggers => onTurnEndTriggers;
        public Resources ResourceAddition => resourceAddition;
        public Resources ResourceModifier => resourceModifier;
        public Movement MovementAddition => movementAddition;
        public Movement MovementModifier => movementModifier;
        public Combat CombatAddition => combatAddition;
        public Combat CombatModifier => combatModifier;
        public Attributes AttributeAddition => attributeAddition;
        public Attributes AttributeModifier => attributeModifier;
        public Attunement AttunementAddition => attunementAddition;
        public Attunement AttunementModifier => attunementModifier;

        private DamageUI _ui;
        
        public void SetUI(DamageUI ui)
        {
            _ui = ui;
        }
        
        public void OnKill(TurnManager turnManager, Character unit)
        {
            onKillTriggers.Activate(unit.Stats, turnManager, _ui);
        }

        public void OnHit(TurnManager turnManager, Character unit)
        {
            onHitTriggers.Activate(unit.Stats, turnManager, _ui);
        }

        public void OnTurnStart(TurnManager turnManager, Character unit)
        {
            onTurnStartTriggers.Activate(unit.Stats, turnManager, _ui);
        }

        public void OnTurnEnd(TurnManager turnManager, Character unit)
        {
            onTurnEndTriggers.Activate(unit.Stats, turnManager, _ui);
        }
    }
}