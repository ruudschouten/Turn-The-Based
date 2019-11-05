using System.Collections;
using Generators;
using UI;
using UI.Managers;
using Unit;
using UnityEngine;
using UnityEngine.Events;

namespace Turn
{
    public class GameManager : MonoBehaviour 
    {
        [SerializeField] private AreaGenerator areaGenerator;
        [SerializeField] private CharacterGenerator characterGenerator;
        [SerializeField] private TurnManager turnManager;
        [SerializeField] private UIManager uiManager;
        [SerializeField] private int normalPrice;
        [SerializeField] private int magicPrice;
        [SerializeField] private int rarePrice;

        [SerializeField] private UnityEvent onUnitPurchased;

        public void Start()
        {
            StartCoroutine(LateStart(0.25f));
        }

        private IEnumerator LateStart(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);

            StartPlaying();
        }

        private void StartPlaying()
        {
            areaGenerator.Generate();
            //Add Rulers
            characterGenerator.Generate(CharacterType.Ruler, Rarity.Normal, 
                areaGenerator.GetTile(0, 0).transform, 
                turnManager.Players[0]);
            
            characterGenerator.Generate(CharacterType.Ruler, Rarity.Normal, 
                areaGenerator.GetTile(areaGenerator.GridSize - 1, areaGenerator.GridSize - 1).transform,
                turnManager.Players[1]);

            //Set actions for base panel
            uiManager.BasePanelUIManager.SetBuyNormal(() => BuyCharacter(Rarity.Normal));
            uiManager.BasePanelUIManager.SetBuyMagic(() => BuyCharacter(Rarity.Magic));
            uiManager.BasePanelUIManager.SetBuyRare(() => BuyCharacter(Rarity.Rare));
            
            uiManager.BasePanelUIManager.SetButtonValues(normalPrice, magicPrice, rarePrice);
        }

        private void BuyCharacter(Rarity rarity)
        {
            var price = 0;
            switch (rarity)
            {
                case Rarity.Normal:
                    price = normalPrice;
                    break;
                case Rarity.Magic:
                    price = magicPrice;
                    break;
                case Rarity.Rare:
                    price = rarePrice;
                    break;
            }

            var basePanel = areaGenerator.GetBase(turnManager.CurrentTeam);
            if (basePanel.childCount < 2)
            {
                if (turnManager.CurrentPlayer.Gold.Purchase(price))
                {
                    var character = characterGenerator.Generate(rarity, basePanel);
                    character.transform.parent = basePanel;
                }
                else
                {
                    uiManager.ShowMessage("You don't have enough money to purchase this unit");
                }
            }

            else
            {
                uiManager.ShowMessage("There is already a unit on the base panel");
            }
            
            onUnitPurchased.Invoke();

            uiManager.HideBasePanelUI();
        }
    }
}