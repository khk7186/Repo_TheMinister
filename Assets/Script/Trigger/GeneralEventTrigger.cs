using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralEventTrigger : MonoBehaviour
{
    BattleType battleType = BattleType.Combat;
    GameTracker gameResult = null;
    //rewards
    public int moneyRewards = 0;
    public int influenceRewards = 0;
    public int prestigeRewards = 0;
    public List<ItemName> itemRewards = new List<ItemName>();
    public List<Character> playerCharacters = new List<Character>();
    public List<Character> enemyCharacters = new List<Character>();
    public GameTracker gameTracker = null;
    private int scene = 0;
    public void TriggerEvent()
    {
        DontDestroyOnLoad(gameObject);
        switch (battleType)
        {
            case BattleType.Combat:
                playerCharacters = SelectOnDuty.GetOndutyAll(OndutyType.Combat);
                scene = 1;
                break;
            case BattleType.Debate:
                playerCharacters = SelectOnDuty.GetOndutyAll(OndutyType.Debate);
                scene = 2;
                break;
            case BattleType.GoBang:
                playerCharacters = SelectOnDuty.GetOndutyAll(OndutyType.Gobang);
                scene = 3;
                break;
            default:
                break;
        }
        gameTracker = GameTracker.NewGameTracker
                                                            (moneyRewards, influenceRewards, prestigeRewards, itemRewards);
        JumpToScene(scene);
    }
    public void TiggerEnd()
    {
        if (gameTracker != null)
        {
            //Win
            if (gameTracker.gameWin)
            {
                scene = 0;
                JumpToScene(scene);
                CurrencyInventory currencyInventory = FindObjectOfType<CurrencyInventory>();
                currencyInventory.Money += gameTracker.moneyRewards;
                currencyInventory.Influence += gameTracker.influenceRewards;
                currencyInventory.Prestige += gameTracker.prestigeRewards;
                ItemInventory itemInventory = FindObjectOfType<ItemInventory>();
                itemInventory.AddItem(itemRewards);
            }
            //Lose
            else
            {
                
            }
        }
    }
    private void JumpToScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
