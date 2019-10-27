using System.Collections;
using Unit;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public AreaGenerator AreaGenerator;
    public CharacterGenerator CharacterGenerator;
    public TurnManager TurnManager;
    public UIManager UiManager;
    public int NormalPrice;
    public int MagicPrice;
    public int RarePrice;

    public void Start() {
        StartCoroutine(LateStart(0.25f));
    }

    IEnumerator LateStart(float waitTime) {
        yield return new WaitForSeconds(waitTime);

        StartPlaying();
    }

    public void StartPlaying() {
        AreaGenerator.Generate();
        //Add Rulers
        CharacterGenerator.Generate(CharacterType.Ruler, Rarity.Normal, TurnManager.Players[0],
            AreaGenerator.GetTileObject(0, 0).transform);
        CharacterGenerator.Generate(CharacterType.Ruler, Rarity.Normal, TurnManager.Players[1],
            AreaGenerator.GetTileObject(AreaGenerator.GridSize - 1, AreaGenerator.GridSize - 1).transform);

        //Set actions for base panel
        UiManager.BasePanelUiManager.SetBuyNormal(() => BuyCharacter(Rarity.Normal));
        UiManager.BasePanelUiManager.SetBuyMagic(() => BuyCharacter(Rarity.Magic));
        UiManager.BasePanelUiManager.SetBuyRare(() => BuyCharacter(Rarity.Rare));
        UiManager.BasePanelUiManager.SetButtonValues(NormalPrice, MagicPrice, RarePrice);
        UiManager.ResourceUiManager.SetupPanel(TurnManager.Players[0].Gold);
        foreach (var player in TurnManager.Players) {
            UiManager.ResourceUiManager.AddListener(player.Gold);
        }
    }

    public void BuyCharacter(Rarity rarity) {
        int price = 0;
        switch (rarity) {
            case Rarity.Normal:
                price = NormalPrice;
                break;
            case Rarity.Magic:
                price = MagicPrice;
                break;
            case Rarity.Rare:
                price = RarePrice;
                break;
        }
        Transform basePanel = AreaGenerator.GetBase(TurnManager.CurrentTeam);
        if (basePanel.childCount < 2) {
            if (TurnManager.CurrentPlayer.Gold.Purchase(price)) {
                GameObject character = CharacterGenerator.Generate(rarity, basePanel);
                character.transform.parent = basePanel;   
            }
            else {
                Debug.Log("Player doesn't have enough money");
            }
        }

        else {
            Debug.Log("Already a unit on base panel");
        }
        UiManager.HideBasePanelUI();
    }
}