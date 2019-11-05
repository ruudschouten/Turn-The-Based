using System.Collections.Generic;
using Tiles;
using UI.Managers;
using Unit;
using UnityEngine;

namespace Generators
{
    public class ActionTileGenerator : MonoBehaviour
    {
        [SerializeField] private UIManager uiManager;
        [SerializeField] private AreaGenerator areaGenerator;
        [SerializeField] private MovementHighlight movementHighlightPrefab;
        [SerializeField] private AttackHighlight attackHighlightPrefab;

        private UnitUIManager UnitUiManager => uiManager.UnitUIManager;
        
        private List<MovementHighlight> _moveHighlights = new List<MovementHighlight>();
        private List<AttackHighlight> _attackHighlights = new List<AttackHighlight>();

        public void Hide()
        {
            HideAttackRange();
            HideMovementRange();
        }
        
        private void HideUnitUI()
        {
            UnitUiManager.HideStatPanel();
            UnitUiManager.HideTraitPanel();
            UnitUiManager.HideAction();
        }
        
        public void ShowMovementRange(Character unit)
        {
            HideAttackRange();
            
            if (unit.HasAttackedThisTurn)
            {
                Debug.Log("Unit already attacked, can't move anymore");
                return;
            }

            foreach (var tile in areaGenerator.GetTilesInRange(unit.GetStartTile(), unit.Stats.Movement.Move, unit.MoveType))
            {
                SpawnMovementTile(tile);
            }

            HideUnitUI();
        }

        public void ShowAttackRange(Character unit)
        {
            HideMovementRange();

            if (unit.HasAttackedThisTurn) return;
            
            unit.PrepareAttack();
            var range = areaGenerator.GetTilesInRange(unit.GetTile(), unit.Attack.Range, MovementType.Radial, true);
            foreach (var tile in range)
            {
                // Skip own tile
                if(tile == unit.GetTile()) continue;
                
                SpawnAttackTile(tile);
            }

            HideUnitUI();
        }
        
        public void MoveToClick(Transform tile)
        {
            HideAttackRange();
            var unit = UnitUiManager.GetSelectedUnit();
            unit.transform.SetParent(tile, false);
            HideMovementRange();
        }

        public void AttackOnClick(Transform tile)
        {
            HideMovementRange();
            var unit = tile.GetComponentInChildren<Character>();
            unit.GetHit(UnitUiManager.GetSelectedUnit());
            HideAttackRange();
        }

        private void SpawnMovementTile(Tile tile)
        {
            if (tile == null)
            {
                return;
            }
            
            var highlight = Instantiate(movementHighlightPrefab, new Vector3(0, 0.125f, 0), new Quaternion());
            highlight.transform.SetParent(tile.transform, false);
            _moveHighlights.Add(highlight);
        }

        private void SpawnAttackTile(Tile tile)
        {
            if (tile == null)
            {
                return;
            }

            var highlight = Instantiate(attackHighlightPrefab, new Vector3(0, 0.125f, 0), new Quaternion());
            highlight.transform.SetParent(tile.transform, false);
            _attackHighlights.Add(highlight);
        }

        public void HideMovementRange()
        {
            foreach (var tile in _moveHighlights)
            {
                Destroy(tile.gameObject);
            }

            _moveHighlights.Clear();
        }

        public void HideAttackRange()
        {
            var unit = UnitUiManager.GetSelectedUnit();
            
            if (unit != null)
            {
                unit.TurnManager.InAttackMode = false;
            }
            
            foreach (var tile in _attackHighlights)
            {
                Destroy(tile.gameObject);
            }

            _attackHighlights.Clear();
        }
    }
}