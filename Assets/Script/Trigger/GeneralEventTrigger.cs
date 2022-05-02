using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralEventTrigger : MonoBehaviour
{
    public BattleType battleType = BattleType.Combat;
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
    public List<Character> LostCharacters = new List<Character>();
    public EndGamePannel endGamePannel;
    private void Awake()
    {
        var pannelPath = "CombatScene/VictoryUI";
        endGamePannel = Resources.Load<EndGamePannel>(pannelPath);
    }
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
        StartCoroutine(JumpToScene(scene));

    }
    public void TiggerEnd()
    {
        if (gameTracker != null)
        {
            //Win
            if (gameTracker.gameWin)
            {
                scene = 0;
                StartCoroutine(JumpToScene(scene));
                CurrencyInventory currencyInventory = FindObjectOfType<CurrencyInventory>();
                currencyInventory.Money += gameTracker.moneyRewards;
                currencyInventory.Influence += gameTracker.influenceRewards;
                currencyInventory.Prestige += gameTracker.prestigeRewards;
                if (itemRewards.Count > 0)
                {
                    ItemInventory itemInventory = FindObjectOfType<ItemInventory>();
                    itemInventory.AddItem(itemRewards);
                }
            }
            //Lose
            else
            {
            }
        }
    }
    private IEnumerator JumpToScene(int scene)
    {
        var path = $"CombatScene/SceneChangeAnimation";
        var animation = Instantiate(Resources.Load<SceneTrans>(path));
        yield return StartCoroutine(animation.StartChange((SceneType)scene));
        SceneManager.LoadScene(scene);
        

        StartCoroutine(animation.EndChange());
        if (scene == 0)
        {
            while (SceneManager.GetActiveScene().buildIndex != 0)
            {
                yield return null;
            }
            Debug.Log("Game Over");
            var pannel = Instantiate(endGamePannel, MainCanvas.FindMainCanvas());
        }
    }
}
