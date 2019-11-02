﻿using System.Collections;
using Unit;
using UnityEngine;

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
            characterGenerator.Generate(CharacterType.Ruler, Rarity.Normal, turnManager.Players[0],
                areaGenerator.GetTileObject(0, 0).transform);
            characterGenerator.Generate(CharacterType.Ruler, Rarity.Normal, turnManager.Players[1],
                areaGenerator.GetTileObject(areaGenerator.GridSize - 1, areaGenerator.GridSize - 1).transform);

            //Set actions for base panel
            uiManager.BasePanelUIManager.SetBuyNormal(() => BuyCharacter(Rarity.Normal));
            uiManager.BasePanelUIManager.SetBuyMagic(() => BuyCharacter(Rarity.Magic));
            uiManager.BasePanelUIManager.SetBuyRare(() => BuyCharacter(Rarity.Rare));
            uiManager.BasePanelUIManager.SetButtonValues(normalPrice, magicPrice, rarePrice);
            uiManager.ResourceUIManager.SetupPanel(turnManager.Players[0].Gold);
            
            foreach (var player in turnManager.Players)
            {
                uiManager.ResourceUIManager.AddListener(player.Gold);
            }
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

            uiManager.HideBasePanelUI();
        }
    }
}