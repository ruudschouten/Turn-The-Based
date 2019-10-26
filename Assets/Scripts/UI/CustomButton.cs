using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace UI
{
    public class CustomButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private UnityEvent onClickEvent;

        public UnityEvent OnClickEvent => onClickEvent;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            onClickEvent.Invoke();
        }
    }
}