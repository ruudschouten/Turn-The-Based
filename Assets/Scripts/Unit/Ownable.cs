using Turn;
using UnityEngine;
using UnityEngine.Events;

namespace Unit
{
    public class Ownable : MonoBehaviour
    {
        [SerializeField] private UnityEvent turnStartEvent = new UnityEvent();
        [SerializeField] private UnityEvent turnEndEvent = new UnityEvent();

        public UnityEvent TurnStartEvent => turnStartEvent;
        public UnityEvent TurnEndEvent => turnEndEvent;
        
        private Player _owner;

        public void Initialize(Player owner)
        {
            _owner = owner;
            _owner.OnTurnStart.AddListener(TurnStart);
            _owner.OnTurnEnd.AddListener(TurnEnd);
        }

        public Player GetOwner()
        {
            return _owner;
        }

        private void TurnStart()
        {
            turnStartEvent.Invoke();
        }

        private void TurnEnd()
        {
            turnEndEvent.Invoke();
        }
    }
}