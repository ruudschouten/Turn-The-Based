using Generators;
using Unit;
using UnityEngine;

namespace UI.Managers
{
    public class TraitManager : MonoBehaviour
    {
        [SerializeField] private GameObject container;
        [SerializeField] private TraitUI traitUI;

        private int _traitCount;

        private const int TraitHeight = 70;
        
        public void ShowTraits(Character unit)
        {
            if (unit.Rarity == Rarity.Normal) return;
            
            container.SetActive(true);
            
            foreach (var trait in unit.Traits)
            {
                PrintTrait(trait);
                _traitCount++;
            }

            _traitCount = 0;
        }

        private void PrintTrait(Trait trait)
        {
            var newTrait = Instantiate(traitUI, container.transform);
            newTrait.Name.text = trait.Name;
            newTrait.Description.text = trait.Description;
            var newHeight = -(TraitHeight * _traitCount) - 5;
            newTrait.SetHeight(newHeight);
        }

        public void Hide()
        {
            container.SetActive(false);
        }

        public void Clear()
        {
            foreach (Transform child in container.transform)
            {
                Destroy(child.gameObject);
            }

            container.SetActive(false);
        }
    }
}