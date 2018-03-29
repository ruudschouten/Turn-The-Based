using System.Collections.Generic;
using Assets.Scripts.Unit;
using Tiles;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour {
    public string Name;
    public TeamColor Color;
    public Resource Gold;

    public List<Character> Units { get; private set; }

    public UnityEvent OnTurnStart = new UnityEvent();
    public UnityEvent OnTurnEnd = new UnityEvent();

    public void PlayerStartTurn() {
        ActivateChildren(true);
        OnTurnStart.Invoke();
    }

    public void PlayerEndTurn() {
        ActivateChildren(false);
        OnTurnEnd.Invoke();
    }


    public void Act() {
        WaitForActionSelect();
        PerformAction();
    }

    public void WaitForActionSelect() {
    }

    public void PerformAction() {
    }


    public void ActivateChildren(bool active) {
        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).gameObject.SetActive(active);
        }
    }

    public enum TeamColor {
        Red,
        Blue
    }
}