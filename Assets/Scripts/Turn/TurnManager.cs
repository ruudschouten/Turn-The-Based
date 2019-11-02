using System.Collections.Generic;
using UI.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Turn
{
    public class TurnManager : MonoBehaviour
    {
        [SerializeField] private UIManager uiManager;
        [SerializeField] private Text currentPlayerText;
        
        [SerializeField] private Player prefab;
        [SerializeField] private new Camera camera;
        
        [SerializeField] private float smoothCamera;
        
        public Player.TeamColor CurrentTeam => CurrentPlayer.Color;
        public List<Player> Players => _players;

        public Player CurrentPlayer { get; private set; }
        public Player Winner { get; private set; }
        public Player Loser { get; private set; }
        public bool InAttackMode { get; set; }
        
        private List<Player> _players;
        private Queue<Player> _playerQueue;
        private const int AmountOfPlayers = 2;

        private Quaternion _targetRotation;

        private void Start()
        {
            _playerQueue = new Queue<Player>();
            _players = new List<Player>();
            for (var i = 0; i < AmountOfPlayers; i++)
            {
                var newPlayer = Instantiate(prefab, transform);
                newPlayer.ActivateChildren(false);
                newPlayer.Color = (Player.TeamColor) i;
                
                newPlayer.Name = i % 2 == 0 ? "Richard" : "Blueyard";
                
                _playerQueue.Enqueue(newPlayer);
                _players.Add(newPlayer);
            }

            CurrentPlayer = _playerQueue.Dequeue();
            CurrentPlayer.PlayerStartTurn();
            currentPlayerText.text = $"[{CurrentTeam}] {CurrentPlayer.Name}";
            _targetRotation = camera.transform.rotation;
        }

        private void Update()
        {
            camera.transform.rotation = 
                Quaternion.RotateTowards(camera.transform.rotation, _targetRotation, smoothCamera * Time.deltaTime);
        }

        public void NextTurn()
        {
            CurrentPlayer.PlayerEndTurn();
            _playerQueue.Enqueue(CurrentPlayer);
            CurrentPlayer = _playerQueue.Dequeue();
            CurrentPlayer.PlayerStartTurn();
            currentPlayerText.text = $"[{CurrentTeam}] {CurrentPlayer.Name}";
            uiManager.Hide(true, true);
            uiManager.ShowForPlayer(CurrentPlayer);
            RotateCamera();
        }

        public void SetLoser(Player loser)
        {
            foreach (var player in _players)
            {
                if (player != loser)
                {
                    Winner = player;
                }

                player.ResourceUIManager.Hide();
            }

            Loser = loser;
            uiManager.GameOverUIManager.Show();
        }

        private void RotateCamera()
        {
            switch (CurrentTeam)
            {
                case Player.TeamColor.Red:
                    _targetRotation = Quaternion.Euler(60, 45, 0);
                    camera.transform.localPosition = new Vector3(-2, 35, -2);
                    break;
                case Player.TeamColor.Blue:
                    _targetRotation = Quaternion.Euler(60, 225, 0);
                    camera.transform.localPosition = new Vector3(30, 35, 30);
                    break;
            }
        }
    }
}