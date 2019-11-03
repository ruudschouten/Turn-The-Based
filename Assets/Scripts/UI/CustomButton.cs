using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace UI
{
    public class CustomButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private TMP_Text textField;
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