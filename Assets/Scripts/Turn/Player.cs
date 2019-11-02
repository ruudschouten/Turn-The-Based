using UnityEngine;
using UnityEngine.Events;

namespace Turn
{
    public class Player : MonoBehaviour
    {
        public string Name;
        [SerializeField] private TeamColor color;
        [SerializeField] private Resource gold;

        [SerializeField] private UnityEvent onTurnStart = new UnityEvent();
        [SerializeField] private UnityEvent onTurnEnd = new UnityEvent();

        public TeamColor Color
        {
            get => color;
            set => color = value;
        }

        public Resource Gold
        {
            get => gold;
            set => gold = value;
        }

        public UnityEvent OnTurnStart => onTurnStart;
        public UnityEvent OnTurnEnd => onTurnEnd;
    
        public void PlayerStartTurn()
        {
            ActivateChildren(true);
            onTurnStart.Invoke();
        }

        public void PlayerEndTurn()
        {
            ActivateChildren(false);
            onTurnEnd.Invoke();
        }

        public void ActivateChildren(bool active)
        {
            for (var i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(active);
            }
        }

        public enum TeamColor
        {
            Red,
            Blue
        }
    }
}