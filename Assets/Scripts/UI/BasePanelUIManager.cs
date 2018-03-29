using Assets.Scripts.Generators;
using UnityEngine;

namespace UI {
    public class BasePanelUIManager : MonoBehaviour {
        public GameObject BasePanel;

        public int NormalCost = 50;
        public int MagicCost = 125;
        public int RareCost = 300;

        private Player _currentPlayer;
        
        public void ShowBaseUi(TurnManager turnManager) {
            _currentPlayer = turnManager.CurrentPlayer;
            BasePanel.SetActive(true);
        }

        public void BuyUnit(Rarity rarity) {
            switch (rarity) {
                case Rarity.Normal:
                    if (_currentPlayer.Gold.CanAfford(NormalCost)) {
                        //TODO: Spawn unit for player with CharacterGenerator
                    }
                    break;
                case Rarity.Magic:
                    if (_currentPlayer.Gold.CanAfford(MagicCost)) {
                        //TODO: Spawn unit for player with CharacterGenerator
                    }
                    break;
                case Rarity.Rare:
                    if (_currentPlayer.Gold.CanAfford(RareCost)) {
                        //TODO: Spawn unit for player with CharacterGenerator
                    }
                    break;
            }
        }

        public void Hide() {
            BasePanel.SetActive(false);
        }
    }
}