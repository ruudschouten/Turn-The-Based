using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour {
    public Player Prototype;
    [HideInInspector]
    public Player CurrentPlayer;
    public Text CurrentPlayerText;
    public UnityEvent CurrentPlayerChanged = new UnityEvent();

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
            _players.Enqueue(newPlayer);
        }

        CurrentPlayer = _players.Dequeue();
        CurrentPlayer.PlayerStartTurn();
        CurrentPlayerText.text = CurrentPlayer.name;
    }

    public void NextTurn() {
        CurrentPlayer.PlayerEndTurn();
        _players.Enqueue(CurrentPlayer);
        CurrentPlayer = _players.Dequeue();
        CurrentPlayer.PlayerStartTurn();
    }
}