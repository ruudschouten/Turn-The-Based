using Turn;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIManager : MonoBehaviour {
    public GameObject GameOverPanel;

    public TurnManager TurnManager;

    private Text _winLoseText;
    private Button _btnRestart;

    // Use this for initialization
    void Start() {
        Hide();
        _winLoseText = GameOverPanel.transform.GetChild(1).GetComponent<Text>();
        _btnRestart = GameOverPanel.transform.GetChild(2).GetComponent<Button>();
        _btnRestart.onClick.AddListener(Restart);
    }

    public void Show() {
        _winLoseText.text = GetWinLose();
        GameOverPanel.SetActive(true);
    }

    public void Hide() {
        GameOverPanel.SetActive(false);
    }

    private void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private string GetWinLose() {
        var text = "";
        var winner = TurnManager.Winner;
        var loser = TurnManager.Loser;
        text = string.Format("Winner: [{0}]{1}\nLoser: [{2}]{3}", winner.Color, winner.Name,
            loser.Color, loser.Name);
        return text;
    }
}