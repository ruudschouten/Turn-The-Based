﻿using Assets.Scripts.Generators;
using Assets.Scripts.Unit;
using UnityEngine;
using UnityEngine.UI;

public class UnitUIManager : MonoBehaviour {
    public GameObject Parent;
    public GameObject StatPanel;
    public GameObject TraitParent;
    public GameObject TraitPanel;

    private GameObject _newStatPanel;
    private GameObject _newTraitPanel;
    
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

    private int _traitCount = 0;
    private Vector3 _traitPos = new Vector3(0,-5,0);
    private int _traitHeight = 70;
    private int _traitWidth = 150;
    //2 is -75 | 3 = -145

    public void Awake() {
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
        
        _newTraitPanel = Instantiate(TraitParent, Parent.transform);
        _newStatPanel.SetActive(false);
        _newTraitPanel.SetActive(false);
    }
    
    public void Hide() {
        _newStatPanel.SetActive(false);
        Clear();
    }

    public void ShowUI(Character unit) {
        Clear();
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
    }

    private void ShowTraits(Character unit) {
        if (unit.Rarity != Rarity.Normal) {
            _newTraitPanel.SetActive(true);
//            _newStatPanel.transform.localPosition = new Vector3(470, 0, 0);
            foreach (var trait in unit.Traits) {
                PrintTrait(trait);
                _traitCount++;
            }
        }
    }

    private float GetPercentage(int current, int max) {
        return ((float)current / max) * 100;
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