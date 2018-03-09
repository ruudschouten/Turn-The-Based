using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Unit;
using UnityEngine;

public class Player : MonoBehaviour {
	public string Name;
	public TeamColor Color;
	public GameObject[] UnitsPrefabs;
	public int Gold;
	[HideInInspector]
	public List<Character> Units { get; private set; }
	

	// Use this for initialization
	void Start () {
		foreach (var prefab in UnitsPrefabs) {
			Units.Add(prefab.GetComponent<Character>());
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Act() {
		WaitForActionSelect();
		PerformAction();
	}

	public void WaitForActionSelect() {
		
	}
	
	public void PerformAction() {
		
	}

	public enum TeamColor {
		Red,
		Blue
	}
}
