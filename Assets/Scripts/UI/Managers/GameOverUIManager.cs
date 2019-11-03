using TMPro;
using Turn;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.Managers
{
    public class GameOverUIManager : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private TurnManager turnManager;
        [SerializeField] private TMP_Text winLoseText;

        private void Start()
        {
            Hide();
        }

        public void Show()
        {
            winLoseText.text = GetWinLose();
            gameOverPanel.SetActive(true);
        }

        public void Hide()
        {
            gameOverPanel.SetActive(false);
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private string GetWinLose()
        {
            var winner = turnManager.Winner;
            var loser = turnManager.Loser;
            var text = $"Winner: [{winner.Color}]{winner.Name}\nLoser: [{loser.Color}]{loser.Name}";
            return text;
        }
    }
}