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
        public Camera Camera { get; set; }

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
            StartCoroutine(HideAfter(1.5f));
        }
        
        public void ShowText(string text)
        {
            textfield.SetText(text);
            textContainer.gameObject.SetActive(true);
            StartCoroutine(HideAfter(1.5f));
        }

        private IEnumerator HideAfter(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            textContainer.gameObject.SetActive(false);
            sliderContainer.gameObject.SetActive(false);

            yield return null;
        }
    }
}