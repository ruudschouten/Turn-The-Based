using System.Collections.Generic;
using Unit;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UnitUIManager : MonoBehaviour
    {
        public GameObject Parent;
        public UnitUI unitUI;
        public GameObject TraitParent;
        public GameObject TraitPanel;
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
        private GameObject _newTraitPanel;
        private GameObject _newActionPanel;

        private int _traitCount = 0;
        private Vector3 _traitPos = new Vector3(0, -5, 0);
        private int _traitHeight = 70;

        private int _traitWidth = 150;
        //2 is -75 | 3 = -145

        public Character GetSelectedUnit()
        {
            return _currentUnit;
        }

        public void Awake()
        {
            _newActionPanel = Instantiate(ActionPanel, Parent.transform);
            _newActionPanel.SetActive(false);
            _btnMove = _newActionPanel.transform.GetChild(0).GetComponent<CustomButton>();
            _btnAttack = _newActionPanel.transform.GetChild(1).GetComponent<CustomButton>();
            _btnCancel = _newActionPanel.transform.GetChild(2).GetComponent<CustomButton>();
            _btnCancel.OnClickEvent.AddListener(HideActionUI);

            _currentStatPanel = Instantiate(unitUI, Parent.transform);
            
            _newTraitPanel = Instantiate(TraitParent, Parent.transform);
            _currentStatPanel.gameObject.SetActive(false);
            _newTraitPanel.SetActive(false);
        }

        private void ShowStats(Character unit)
        {
            HideMovementRange();
            HideAttackRange();
            
            _currentStatPanel.ShowStats(unit);
        }

        private void ShowTraits(Character unit)
        {
            if (unit.Rarity != Rarity.Normal)
            {
                _newTraitPanel.SetActive(true);
                foreach (var trait in unit.Traits)
                {
                    PrintTrait(trait);
                    _traitCount++;
                }

                _traitCount = 0;
            }
        }

        public void Hide()
        {
            _currentStatPanel.gameObject.SetActive(false);
            HideActionUI();
            HideMovementRange();
            HideAttackRange();
            Clear();
        }

        public void HideGUI()
        {
            _currentStatPanel.gameObject.SetActive(false);
            _newTraitPanel.SetActive(false);
            HideActionUI();
        }

        public void ShowUI(Character unit)
        {
            Clear();
            _currentUnit = unit;
            _currentStatPanel.gameObject.SetActive(true);
            ShowStats(unit);
            ShowTraits(unit);
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

        private void PrintTrait(Trait trait)
        {
            var newTrait = Instantiate(TraitPanel, _newTraitPanel.transform);
            Text nameText = newTrait.transform.GetChild(0).GetComponent<Text>();
            Text descText = newTrait.transform.GetChild(1).GetComponent<Text>();
            nameText.text = trait.Name;
            descText.text = trait.Description;
            var newHeight = -5 - (_traitHeight * _traitCount);
            newTrait.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(_traitPos.x, newHeight, _traitPos.z);
        }

        private void Clear()
        {
            foreach (Transform child in _newTraitPanel.transform)
            {
                Destroy(child.gameObject);
            }

            _newTraitPanel.SetActive(false);
        }
    }
}