using Generators;
using Unit;
using UnityEngine;

namespace UI
{
    public class ActionUI : MonoBehaviour
    {
        [SerializeField] private GameObject container;
        [SerializeField] private CustomButton moveButton;
        [SerializeField] private CustomButton attackButton;

        [SerializeField] private ActionTileGenerator tileGenerator;
        
        public void Show(Character unit)
        {
            container.SetActive(true);
            moveButton.OnClickEvent.AddListener(() => tileGenerator.ShowMovementRange(unit));
            moveButton.OnClickEvent.AddListener(Hide);
            
            attackButton.OnClickEvent.AddListener(() => tileGenerator.ShowAttackRange(unit));
            attackButton.OnClickEvent.AddListener(Hide);
        }

        public void Reset()
        {
            Hide();
            moveButton.OnClickEvent.RemoveAllListeners();
            attackButton.OnClickEvent.RemoveAllListeners();
        }

        private void Hide()
        {
            container.SetActive(false);
        }

        public void HideAttackRange()
        {
            tileGenerator.HideAttackRange();
        }

        public void HideMovementRange()
        {
            tileGenerator.HideMovementRange();
        }

        public void AttackOnClick(Transform tile)
        {
            tileGenerator.AttackOnClick(tile);
        }

        public void MoveToClick(Transform tile)
        {
            tileGenerator.MoveToClick(tile);
        }
    }
}