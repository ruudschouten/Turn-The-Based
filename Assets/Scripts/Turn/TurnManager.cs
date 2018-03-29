using System.Collections.Generic;
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

    private Queue<Player> _players;
    private int _amountOfPlayers = 2;

    // Use this for initialization
    void Start() {
        _players = new Queue<Player>();
        for (int i = 0; i < _amountOfPlayers; i++) {
            Player newPlayer = Instantiate(Prototype);
            newPlayer.transform.SetParent(transform);
            newPlayer.ActivateChildren(false);
            newPlayer.Color = (Player.TeamColor) i;
            if (i % 2 == 0) newPlayer.Name = "Richard";
            else newPlayer.Name = "Notyard";
            _players.Enqueue(newPlayer);
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
        UiManager.Hide(true, true, true, true);
        UiManager.ShowForPlayer(CurrentPlayer);
    }
}