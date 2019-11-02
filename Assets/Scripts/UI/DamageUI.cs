using System.Collections;
using TMPro;
using UnityEngine;

namespace UI
{
    public class DamageUI : MonoBehaviour
    {
        [SerializeField] private float canvasWidth;
        [SerializeField] private RectTransform textContainer;
        [SerializeField] private TMP_Text textfield;
        [Space]
        [SerializeField] private RectTransform sliderContainer;
        [SerializeField] private RectTransform healthSlider;
        [Space]
        [SerializeField] private CanvasGroup group;
        [SerializeField] private float timeVisible;
        [SerializeField] private float fadeDuration;
        public Camera Camera { private get; set; }

        public void Update()
        {
            transform.LookAt(Camera.transform.position, Vector3.up);
        }
        
        public void ShowHealthDegrade(float max, float current)
        {
            var perc = (current / max);
            var newPos = (perc * canvasWidth) - canvasWidth;
            healthSlider.offsetMax = new Vector2(newPos, healthSlider.offsetMax.y);
            sliderContainer.gameObject.SetActive(true);
            StartCoroutine(HideAfter(timeVisible));
        }
        
        public void ShowText(string text)
        {
            textfield.SetText(text);
            textContainer.gameObject.SetActive(true);
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
            
            textContainer.gameObject.SetActive(false);
            sliderContainer.gameObject.SetActive(false);

            yield return null;
        }
    }
}