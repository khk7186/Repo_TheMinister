using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralEventTrigger : MonoBehaviour
{
    public BattleType battleType = BattleType.Combat;
    //rewards
    public int moneyRewards = 0;
    public int influenceRewards = 0;
    public int prestigeRewards = 0;
    public List<ItemName> itemRewards = new List<ItemName>();
    public List<Character> playerCharacters = new List<Character>();
    public List<Character> enemyCharacters = new List<Character>();
    // {CharacterUnit, Cards}
    public List<Character[]> enemyCharactersCardsList = new List<Character[]>();
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
                scene = 2;
                break;
            case BattleType.Debate:
                playerCharacters = SelectOnDuty.GetOndutyAll(OndutyType.Debate);
                scene = 3;
                break;
            case BattleType.GoBang:
                playerCharacters = SelectOnDuty.GetOndutyAll(OndutyType.Gobang);
                scene = 4;
                break;
            default:
                break;
        }
        gameTracker = GameTracker.NewGameTracker
                                                            (moneyRewards, influenceRewards, prestigeRewards, itemRewards);
        StartCoroutine(JumpToScene(scene));

    }
    public void TriggerEnd(int result = 0)
    {
        if (result != 0)
        {
            gameTracker.gameWin = result > 0;
        }
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
                scene = 0;
                StartCoroutine(JumpToScene(scene));
            }
        }
    }
    private IEnumerator JumpToScene(int scene)
    {
        //Debug.Log("Start SceneChangeAnimation");
        string path = $"CombatScene/SceneChangeAnimation";
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

    public void JumpToSceneTest(int scene)
    {
        StartCoroutine(JumpToScene(scene));
    }
}
