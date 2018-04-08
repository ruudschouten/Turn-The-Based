using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour {
    public UIManager UiManager;
    public Player Prototype;
    [HideInInspector]
    public Player CurrentPlayer;
    public Text CurrentPlayerText;
    public Player.TeamColor CurrentTeam;
    public Camera Camera;
    public List<Player> Players;

    public Player Winner;
    public Player Loser;

    public float SmoothCamera;

    public bool InAttackMode { get; set; }

    private Queue<Player> _players;
    private int _amountOfPlayers = 2;

    private Quaternion _targetRotation;

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
        _targetRotation = Camera.transform.rotation;
    }

    void Update() {
        Camera.transform.rotation = Quaternion.RotateTowards(Camera.transform.rotation, _targetRotation, SmoothCamera * Time.deltaTime);
    }

    public void NextTurn() {
        CurrentPlayer.PlayerEndTurn();
        _players.Enqueue(CurrentPlayer);
        CurrentPlayer = _players.Dequeue();
        CurrentPlayer.PlayerStartTurn();
        CurrentTeam = CurrentPlayer.Color;
        CurrentPlayerText.text = string.Format("[{0}] {1}", CurrentTeam, CurrentPlayer.Name);
        UiManager.Hide(true, true, false);
        UiManager.ShowForPlayer(CurrentPlayer);
        RotateCamera();
    }

    public void SetLoser(Player loser) {
        foreach (var player in Players) {
            if (player != loser) {
                Winner = player;
            }
        }
        Loser = loser;
        UiManager.GameOverUiManager.Show();
    }

    private void RotateCamera() {
        switch (CurrentTeam) {
            case Player.TeamColor.Red:
                _targetRotation = Quaternion.Euler(60, 45, 0);
                Camera.transform.localPosition = new Vector3(-2, 35, -2);
                break;
            case Player.TeamColor.Blue:
                _targetRotation = Quaternion.Euler(60, 225, 0);
                Camera.transform.localPosition = new Vector3(30, 35, 30);
                break;
        }
    }
}