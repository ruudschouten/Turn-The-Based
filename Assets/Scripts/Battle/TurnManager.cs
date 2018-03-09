using UnityEngine;


public class TurnManager : MonoBehaviour {

    public Player RedPlayer;
    public Player BluePlayer;

    public Player.TeamColor Beginner;

    private void Start() {
        
    }
    
    private void Update() {
        if (Beginner == Player.TeamColor.Red) {
            RedPlayer.Act();
        }
        else {
            
        }
    }

    public enum TurnActions {
        Move,
        Attack,
        Skills,
        Defend,
        NextTurn,
    }
}