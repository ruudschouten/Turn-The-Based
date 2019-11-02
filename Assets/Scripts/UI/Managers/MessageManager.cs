using System.Collections;
using TMPro;
using UnityEngine;

namespace UI.Managers
{
    public class MessageManager : MonoBehaviour
    {
        [SerializeField] private RectTransform container;
        [SerializeField] private TMP_Text messageText;
        [SerializeField] private CanvasGroup group;
        [SerializeField] private float timeVisible;
        [SerializeField] private float fadeDuration;

        public void ShowMessage(string message)
        {
            messageText.SetText(message);
            container.gameObject.SetActive(true);
            StartCoroutine(HideAfter(timeVisible));
        }

        private IEnumerator HideAfter(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            
            for (var t = 0.01f; t < fadeDuration;)
            {
                t += Time.deltaTime;
                group.alpha -= t;
                yield return null;
            }
            
            container.gameObject.SetActive(false);

            yield return null;
        }
    }
}