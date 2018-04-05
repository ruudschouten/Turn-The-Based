using System.Collections;
using Assets.Scripts.Generators;
using Assets.Scripts.Unit;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public AreaGenerator AreaGenerator;
    public CharacterGenerator CharacterGenerator;
    public TurnManager TurnManager;
    public UIManager UiManager;

    private Transform redBase;
    private Transform blueBase;

    public void Start() {
        StartCoroutine(LateStart(0.25f));
    }
 
    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        
        StartPlaying();
    }
    
    public void StartPlaying() {
        AreaGenerator.Generate();
        //Add Rulers
        redBase = AreaGenerator.GetBase(Player.TeamColor.Red);
        blueBase = AreaGenerator.GetBase(Player.TeamColor.Blue);
        CharacterGenerator.Generate(CharacterType.Ruler, Rarity.Normal, TurnManager.Players[0],
            AreaGenerator.GetTileObject(0, 0).transform);
        CharacterGenerator.Generate(CharacterType.Ruler, Rarity.Normal, TurnManager.Players[1],
            AreaGenerator.GetTileObject(AreaGenerator.GridSize - 1, AreaGenerator.GridSize - 1).transform);

        //Set actions for base panel
        UiManager.BasePanelUiManager.SetBuyNormal(() => BuyCharacter(Rarity.Normal));
        UiManager.BasePanelUiManager.SetBuyMagic(() => BuyCharacter(Rarity.Magic));
        UiManager.BasePanelUiManager.SetBuyRare(() => BuyCharacter(Rarity.Rare));
        UiManager.ResourceUiManager.SetupPanel(TurnManager.Players[0].Gold);
        foreach (var player in TurnManager.Players) {
            UiManager.ResourceUiManager.AddListener(player.Gold);
        }
    }

    public void BuyCharacter(Rarity rarity) {
        int price = (int) (rarity + 1) * 50;
        if (TurnManager.CurrentPlayer.Gold.Purchase(price)) {
            GameObject character = CharacterGenerator.Generate(rarity, GetCurrentPlayersBase());
            character.transform.parent = AreaGenerator.GetBase(TurnManager.CurrentTeam);
        }
        else {
            Debug.Log("Player doesn't have enough dough");
        }
    }

    private Transform GetCurrentPlayersBase() {
        if (TurnManager.CurrentPlayer.Color == Player.TeamColor.Red) return redBase;
        return blueBase;
    }
}