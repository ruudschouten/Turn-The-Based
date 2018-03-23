using UnityEngine;
using UnityEngine.Events;

public class Ownable : MonoBehaviour {
    private Player owner;

    public UnityEvent TurnStartEvent = new UnityEvent();
    public UnityEvent TurnEndEvent = new UnityEvent();

    public void Initialize(Player owner) {
        this.owner = owner;
        this.owner.OnTurnStart.AddListener(TurnStart);
        this.owner.OnTurnEnd.AddListener(TurnEnd);
    }

    public Player GetOwner() {
        return owner;
    }

    private void TurnStart() {
        TurnStartEvent.Invoke();
    }

    private void TurnEnd() {
        TurnEndEvent.Invoke();
    }
}