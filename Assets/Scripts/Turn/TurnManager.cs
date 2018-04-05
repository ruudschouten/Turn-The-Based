﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour {
    public UIManager UiManager;
    public Player Prototype;
    [HideInInspector]
    public Player CurrentPlayer;
    public Text CurrentPlayerText;
    public Player.TeamColor CurrentTeam;
    public Camera Camera;

    private Queue<Player> _players;
    private int _amountOfPlayers = 2;

    public List<Player> Players;
    
    // Use this for initialization
    void Start() {
        _players = new Queue<Player>();
        Players = new List<Player>();
        for (int i = 0; i < _amountOfPlayers; i++) {
            Player newPlayer = Instantiate(Prototype);
            newPlayer.transform.SetParent(transform);
            newPlayer.ActivateChildren(false);
            newPlayer.Color = (Player.TeamColor) i;
            if (i % 2 == 0) newPlayer.Name = "Richard";
            else newPlayer.Name = "Notyard";
            _players.Enqueue(newPlayer);
            Players.Add(newPlayer);
        }

        CurrentPlayer = _players.Dequeue();
        CurrentPlayer.PlayerStartTurn();
        CurrentTeam = CurrentPlayer.Color;
        CurrentPlayerText.text = string.Format("[{0}] {1}", CurrentTeam, CurrentPlayer.Name);
        UiManager.ShowForPlayer(CurrentPlayer);
    }

    public void NextTurn() {
        CurrentPlayer.PlayerEndTurn();
        _players.Enqueue(CurrentPlayer);
        CurrentPlayer = _players.Dequeue();
        CurrentPlayer.PlayerStartTurn();
        CurrentTeam = CurrentPlayer.Color;
        CurrentPlayerText.text = string.Format("[{0}] {1}", CurrentTeam, CurrentPlayer.Name);
        UiManager.Hide(true, true, true, true, false);
        UiManager.ShowForPlayer(CurrentPlayer);
    }

    private void RotateCamera() {
        switch (CurrentTeam) {
            case Player.TeamColor.Red:
                Camera.transform.rotation = new Quaternion(60, 45, 0, 0);
                break;
            case Player.TeamColor.Blue:
                Camera.transform.rotation = new Quaternion(60, 225, 0, 0);
                break;
        }
    }
}