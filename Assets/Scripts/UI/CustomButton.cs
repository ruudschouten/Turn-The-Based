using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class CustomButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Text textField;
        [SerializeField] private UnityEvent onClickEvent;

        public UnityEvent OnClickEvent => onClickEvent;

        public void SetText(string text)
        {
            textField.text = text;
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            onClickEvent.Invoke();
        }
    }
}