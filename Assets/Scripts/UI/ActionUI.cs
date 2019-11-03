using System.Collections.Generic;
using Generators;
using Tiles;
using UI.Managers;
using Unit;
using UnityEngine;

namespace UI
{
    public class ActionUI : MonoBehaviour
    {
        [SerializeField] private GameObject container;
        [SerializeField] private CustomButton moveButton;
        [SerializeField] private CustomButton attackButton;
        [SerializeField] private UnitUIManager unitUIManager;
        
        [SerializeField] private MovementHighlight movementHighlightPrefab;
        [SerializeField] private AttackHighlight attackHighlightPrefab;
        [SerializeField] private AreaGenerator areaGen;
        
        private List<MovementHighlight> _moveHighlights = new List<MovementHighlight>();
        private List<AttackHighlight> _attackHighlights = new List<AttackHighlight>();
        
        public void Show(Character unit)
        {
            container.SetActive(true);
            moveButton.OnClickEvent.AddListener(() => ShowMovementRange(unit));
            attackButton.OnClickEvent.AddListener(() => ShowAttackRange(unit));
        }

        public void Hide()
        {
            container.SetActive(false);
            moveButton.OnClickEvent.RemoveAllListeners();
            attackButton.OnClickEvent.RemoveAllListeners();
        }

        private void HideUnitUI()
        {
            unitUIManager.HideStatPanel();
            unitUIManager.HideTraitPanel();
            Hide();
        }
        
        private void ShowMovementRange(Character unit)
        {
            HideAttackRange();
            
            if (unit.HasAttackedThisTurn)
            {
                Debug.Log("Unit already attacked, can't move anymore");
                return;
            }

            foreach (var tile in areaGen.GetTilesInRange(unit.GetStartTile(), unit.Stats.Movement.Move, unit.MoveType))
            {
                SpawnMovementTile(tile);
            }

            HideUnitUI();
        }

        private void ShowAttackRange(Character unit)
        {
            HideMovementRange();

            if (unit.HasAttackedThisTurn) return;
            
            unit.PrepareAttack();
            foreach (var tile in areaGen.GetTilesInRange(unit.GetTile(), 1.5f, MovementType.Radial, true))
            {
                SpawnAttackTile(tile);
            }

            HideUnitUI();
        }
        
        public void MoveToClick(Transform tile)
        {
            HideAttackRange();
            var unit = unitUIManager.GetSelectedUnit();
            unit.transform.SetParent(tile, false);
            HideMovementRange();
        }

        public void AttackOnClick(Transform tile)
        {
            HideMovementRange();
            var unit = tile.GetComponentInChildren<Character>();
            unit.GetHit(unitUIManager.GetSelectedUnit());
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
            var unit = unitUIManager.GetSelectedUnit();
            
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