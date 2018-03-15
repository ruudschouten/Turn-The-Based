using System;
using System.Collections.Generic;
using UnityEngine;


public class TurnManager : MonoBehaviour {
    public List<Player> players;

    public int CurrentPlayer;

    private bool firstRound;

    private void Start() {
    }

    private void Update() {
        if (firstRound) {
            //Wait for dice roll

            players[CurrentPlayer].Act();
            CurrentPlayer++;
            firstRound = false;
        }

        if (CurrentPlayer > players.Count - 1) CurrentPlayer = 0;
        players[CurrentPlayer].Act();
        CurrentPlayer++;
    }

    public void ShowDice() {
        throw new NotImplementedException();
    }

    public enum TurnActions {
        Move,
        Attack,
        Skills,
        Defend,
        NextTurn,
    }
}