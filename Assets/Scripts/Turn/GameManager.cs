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

    public void StartPlaying() {
        AreaGenerator.Generate();
        //Add Rulers
        redBase = AreaGenerator.GetBase(Player.TeamColor.Red);
        blueBase = AreaGenerator.GetBase(Player.TeamColor.Blue);
        CharacterGenerator.Generate(CharacterType.Ruler, Rarity.Normal, TurnManager.Players[0],
            AreaGenerator.GetTile(0, 0).transform);
        CharacterGenerator.Generate(CharacterType.Ruler, Rarity.Normal, TurnManager.Players[1],
            AreaGenerator.GetTile(AreaGenerator.GridSize - 1, AreaGenerator.GridSize - 1).transform);

        //Set actions for base panel
        UiManager.BasePanelUiManager.SetBuyNormal(() => BuyCharacter(Rarity.Normal));
        UiManager.BasePanelUiManager.SetBuyMagic(() => BuyCharacter(Rarity.Magic));
        UiManager.BasePanelUiManager.SetBuyRare(() => BuyCharacter(Rarity.Rare));
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