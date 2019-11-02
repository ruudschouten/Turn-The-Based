using UnityEngine;
using UnityEngine.EventSystems;

namespace Tiles
{
    public class HighlightableTile : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] protected Material highlightMaterial;
        [SerializeField] protected new MeshRenderer renderer;

        [SerializeField] protected Material defaultMat;

        public void OnPointerEnter(PointerEventData eventData)
        {
            renderer.material = highlightMaterial;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            renderer.material = defaultMat;
        }
    }
}