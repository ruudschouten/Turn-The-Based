﻿using System;
using System.Collections.Generic;
using Assets.Scripts.Generators;
using Assets.Scripts.Unit;
using Tiles;
using UnityEngine;
using UnityEngine.UI;

public class UnitUIManager : MonoBehaviour {
    public GameObject Parent;
    public GameObject StatPanel;
    public GameObject TraitParent;
    public GameObject TraitPanel;
    public GameObject ActionPanel;

    public GameObject HighlightPrefab;
    public AreaGenerator AreaGen;

    private GameObject _newStatPanel;
    private GameObject _newTraitPanel;
    private GameObject _newActionPanel;
    
    private List<GameObject> _moveHighlights = new List<GameObject>();

    private Text _nameText;
    private Text _classText;
    private Slider _healthSlider;
    private Slider _magicSlider;
    private Text _resourceText; //This is HP and SP
    private Text _statsText; //STR, INT, RES, PRE, AGI
    private Text _moveValue;
    private Text _jumpValue;
    private Text _fireValue;
    private Text _windValue;
    private Text _iceValue;
    private Text _ownerValue;

    private Button _btnMove;
    private Button _btnAttack;
    private Button _btnCancel;

    private Character currentUnit;
    private Vector3 unitTile;

    private int _traitCount = 0;
    private Vector3 _traitPos = new Vector3(0, -5, 0);
    private int _traitHeight = 70;

    private int _traitWidth = 150;
    //2 is -75 | 3 = -145

    public void Awake() {
        _newActionPanel = Instantiate(ActionPanel, Parent.transform);
        _newActionPanel.SetActive(false);
        _btnMove = _newActionPanel.transform.GetChild(0).GetComponent<Button>();
        _btnAttack = _newActionPanel.transform.GetChild(1).GetComponent<Button>();
        _btnCancel = _newActionPanel.transform.GetChild(2).GetComponent<Button>();
        _btnCancel.onClick.AddListener(HideActionUI);

        _newStatPanel = Instantiate(StatPanel, Parent.transform);
        _nameText = _newStatPanel.transform.GetChild(2).GetComponent<Text>();
        _classText = _newStatPanel.transform.GetChild(3).GetComponent<Text>();
        _healthSlider = _newStatPanel.transform.GetChild(4).GetComponent<Slider>();
        _magicSlider = _newStatPanel.transform.GetChild(5).GetComponent<Slider>();
        _resourceText = _newStatPanel.transform.GetChild(6).GetComponent<Text>();
        _statsText = _newStatPanel.transform.GetChild(7).GetComponent<Text>();
        _moveValue = _newStatPanel.transform.GetChild(9).GetComponent<Text>();
        _jumpValue = _newStatPanel.transform.GetChild(10).GetComponent<Text>();
        _fireValue = _newStatPanel.transform.GetChild(12).GetComponent<Text>();
        _windValue = _newStatPanel.transform.GetChild(13).GetComponent<Text>();
        _iceValue = _newStatPanel.transform.GetChild(14).GetComponent<Text>();
        _ownerValue = _newStatPanel.transform.GetChild(15).GetComponent<Text>();

        _newTraitPanel = Instantiate(TraitParent, Parent.transform);
        _newStatPanel.SetActive(false);
        _newTraitPanel.SetActive(false);
    }

    public void Hide() {
        _newStatPanel.SetActive(false);
        HideActionUI();
        HideMovementRange();
        Clear();
    }

    public void ShowUI(Character unit) {
        Clear();
        currentUnit = unit;
        unitTile = unit.TurnStartPos;
        _newStatPanel.SetActive(true);
        ShowStats(unit);
        ShowTraits(unit);
    }

    private void ShowStats(Character unit) {
        _nameText.text = unit.Name;
        _classText.text = unit.Type.ToString();
        _healthSlider.value = GetPercentage(unit.Stats.Health, unit.Stats.MaxHealth);
        _magicSlider.value = GetPercentage(unit.Stats.Magic, unit.Stats.MaxMagic);
        _resourceText.text = unit.Stats.PrintResources();
        _statsText.text = unit.Stats.PrintBaseStats();
        _moveValue.text = unit.Stats.Move.ToString();
        _jumpValue.text = unit.Stats.Jump.ToString();
        _fireValue.text = unit.Stats.FireAttunement.ToString();
        _windValue.text = unit.Stats.WindAttunement.ToString();
        _iceValue.text = unit.Stats.IceAttunement.ToString();
        _ownerValue.text = unit.Ownable.GetOwner().Name;
    }

    private void ShowTraits(Character unit) {
        if (unit.Rarity != Rarity.Normal) {
            _newTraitPanel.SetActive(true);
//            _newStatPanel.transform.localPosition = new Vector3(470, 0, 0);
            foreach (var trait in unit.Traits) {
                PrintTrait(trait);
                _traitCount++;
            }

            _traitCount = 0;
        }
    }

    public void ShowActionUI(Character unit) {
        _newActionPanel.SetActive(true);
        _btnMove.onClick.AddListener(() => ShowMovementRange(unit));
        _btnAttack.onClick.AddListener(() => ShowAttackRange(unit));
    }

    public void HideActionUI() {
        _newActionPanel.SetActive(false);
        _btnMove.onClick.RemoveAllListeners();
        _btnAttack.onClick.RemoveAllListeners();
    }

//    private void Movement(Character unit) {
//        if (highlights.Count == 0) {
//            ShowMovementRange(unit);
//        }
//        else {
//            
//        }
//    }
    
    private void ShowMovementRange(Character unit) {
        var movement = unit.Stats.Move;
        if (movement == 0) return;
        var tileWidth = 4f;
        Vector3 pos = new Vector3(0, 0.5f, 0);
        var newPos = new Vector3();
        for (int n = movement; n > 0; n--) {
            for (int x = 0; x < n + 1; x++) {
                var y = n - x;
                //TODO: Make this work better 
                var prevPos = new Vector3(pos.x + (x * tileWidth), pos.y, pos.z + (y * tileWidth));
                newPos = new Vector3(
                    unitTile.x - (pos.x + (x * tileWidth)), 
                    (pos.y), 
                    unitTile.z - (pos.z + (y * tileWidth))
                    );
                SpawnHighlightTile(newPos);

                prevPos = new Vector3(pos.x + (-x * tileWidth), pos.y, pos.z + (-y * tileWidth));
                
                newPos = new Vector3(
                    unitTile.x - (pos.x + (-x * tileWidth)), 
                    (pos.y), 
                    unitTile.z - (pos.z + (-y * tileWidth))
                );
                SpawnHighlightTile(newPos);
            }
        }
        SpawnHighlightTile(pos);
    }

    public void MoveToClick(Transform tile) {
        currentUnit.transform.SetParent(tile, false);
        HideMovementRange();
    }

    private void SpawnHighlightTile(Vector3 newPos) {
        GameObject tile = AreaGen.GetTile(newPos);
        if (tile == null) return;
        _moveHighlights.Add(tile);
        Instantiate(HighlightPrefab, new Vector3(0, 0.125f, 0), new Quaternion()).transform.SetParent(tile.transform, false);
    }

    private void ShowAttackRange(Character unit) {
        //TODO: Implement
    }

    private void HideMovementRange() {
        foreach (GameObject highlight in _moveHighlights) {
            Destroy(highlight.transform.GetChild(1).gameObject);
        }
        _moveHighlights.Clear();
    }

    private float GetPercentage(int current, int max) {
        return ((float) current / max) * 100;
    }

    private void PrintTrait(Trait trait) {
        var newTrait = Instantiate(TraitPanel, _newTraitPanel.transform);
        Text nameText = newTrait.transform.GetChild(0).GetComponent<Text>();
        Text descText = newTrait.transform.GetChild(1).GetComponent<Text>();
        nameText.text = trait.Name;
        descText.text = trait.Description;
        var newHeight = -5 - (_traitHeight * _traitCount);
        newTrait.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(_traitPos.x, newHeight, _traitPos.z);
    }

    private void Clear() {
        foreach (Transform child in _newTraitPanel.transform) {
            Destroy(child.gameObject);
        }

        _newTraitPanel.SetActive(false);
    }
}