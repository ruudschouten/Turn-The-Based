using System.Collections.Generic;
using Unit;
using UnityEngine;

namespace UI
{
    public class UnitUIManager : MonoBehaviour
    {
        [SerializeField] private GameObject container;
        [SerializeField] private UnitUI unitUI;
        [SerializeField] private TraitManager traitManager;
        public GameObject ActionPanel;

        public GameObject MovementHighlightPrefab;
        public GameObject AttackHighlightPrefab;
        public AreaGenerator AreaGen;
        
        private List<GameObject> _moveHighlights = new List<GameObject>();
        private List<GameObject> _attackHighlights = new List<GameObject>();

        private CustomButton _btnMove;
        private CustomButton _btnAttack;
        private CustomButton _btnCancel;

        private Character _currentUnit;
        private UnitUI _currentStatPanel;
        private GameObject _newActionPanel;

        public Character GetSelectedUnit()
        {
            return _currentUnit;
        }

        public void Awake()
        {
            _newActionPanel = Instantiate(ActionPanel, container.transform);
            _newActionPanel.SetActive(false);
            _btnMove = _newActionPanel.transform.GetChild(0).GetComponent<CustomButton>();
            _btnAttack = _newActionPanel.transform.GetChild(1).GetComponent<CustomButton>();
            _btnCancel = _newActionPanel.transform.GetChild(2).GetComponent<CustomButton>();
            _btnCancel.OnClickEvent.AddListener(HideActionUI);

            _currentStatPanel = Instantiate(unitUI, container.transform);
            
            _currentStatPanel.gameObject.SetActive(false);
            traitManager.Hide();
        }

        private void ShowStats(Character unit)
        {
            HideMovementRange();
            HideAttackRange();
            
            _currentStatPanel.ShowStats(unit);
        }

        public void Hide()
        {
            _currentStatPanel.gameObject.SetActive(false);
            HideActionUI();
            HideMovementRange();
            HideAttackRange();
            
            traitManager.Clear();
        }

        public void HideGUI()
        {
            _currentStatPanel.gameObject.SetActive(false);
            traitManager.Hide();
            HideActionUI();
        }

        public void ShowUI(Character unit)
        {
            traitManager.Clear();
            
            _currentUnit = unit;
            _currentStatPanel.gameObject.SetActive(true);
            
            ShowStats(unit);
            
            traitManager.ShowTraits(unit);
        }

        public void ShowActionUI(Character unit)
        {
            _newActionPanel.SetActive(true);
            _btnMove.OnClickEvent.AddListener(() => ShowMovementRange(unit));
            _btnAttack.OnClickEvent.AddListener(() => ShowAttackRange(unit));
        }

        public void HideActionUI()
        {
            _newActionPanel.SetActive(false);
            _btnMove.OnClickEvent.RemoveAllListeners();
            _btnAttack.OnClickEvent.RemoveAllListeners();
        }

        private void ShowMovementRange(Character unit)
        {
            HideAttackRange();
            if (unit.HasAttackedThisTurn)
            {
                Debug.Log("Unit already attacked, can't move anymore");
                return;
            }

            foreach (var tile in AreaGen.GetTilesInRange(unit.GetStartTile(), unit.Stats.Movement.Move, unit.MoveType))
            {
                SpawnMovementTile(tile);
            }

            HideGUI();
        }

        private void ShowAttackRange(Character unit)
        {
            HideMovementRange();
            if (!unit.HasAttackedThisTurn)
            {
                unit.PrepareAttack();
                foreach (var tile in AreaGen.GetTilesInRange(unit.GetTile(), 1.5f, MovementType.Radial, true))
                {
                    SpawnAttackTile(tile);
                }

                HideGUI();
            }
        }

        public void MoveToClick(Transform tile)
        {
            HideAttackRange();
            _currentUnit.transform.SetParent(tile, false);
            HideMovementRange();
        }

        public void AttackOnClick(Transform tile)
        {
            HideMovementRange();
            var unit = tile.GetComponentInChildren<Character>();
            unit.GetHit(_currentUnit);
            HideAttackRange();
        }

        private void SpawnMovementTile(GameObject tile)
        {
            if (tile == null) return;
            _moveHighlights.Add(tile);
            Instantiate(MovementHighlightPrefab, new Vector3(0, 0.125f, 0), new Quaternion()).transform
                .SetParent(tile.transform, false);
        }

        private void SpawnAttackTile(GameObject tile)
        {
            if (tile == null) return;
            _attackHighlights.Add(tile);
            Instantiate(AttackHighlightPrefab, new Vector3(0, 0.125f, 0), new Quaternion()).transform
                .SetParent(tile.transform, false);
        }

        public void HideMovementRange()
        {
            foreach (GameObject tile in _moveHighlights)
            {
                foreach (Transform child in tile.transform)
                {
                    if (child.name.ToLower().Contains("move"))
                    {
                        Destroy(child.gameObject);
                    }
                }
            }

            _moveHighlights.Clear();
        }

        public void HideAttackRange()
        {
            if (_currentUnit != null) _currentUnit.TurnManager.InAttackMode = false;
            foreach (GameObject tile in _attackHighlights)
            {
                foreach (Transform child in tile.transform)
                {
                    if (child.name.ToLower().Contains("attack"))
                    {
                        Destroy(child.gameObject);
                    }
                }
            }

            _attackHighlights.Clear();
        }
    }
}