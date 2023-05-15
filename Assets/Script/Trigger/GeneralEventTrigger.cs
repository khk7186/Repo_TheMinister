using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.QuestMachine;
using UnityEngine.SceneManagement;
using PixelCrushers.DialogueSystem;

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
    private int scene = 1;
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
    public void TriggerEnd(int result)
    {
        gameTracker.gameWin = result > 0;
        if (gameTracker != null)
        {
            //Win
            if (gameTracker.gameWin)
            {
                scene = 1;
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
                scene = 1;
                StartCoroutine(JumpToScene(scene));
            }
        }
    }
    private IEnumerator JumpToScene(int scene)
    {
        //Debug.Log("Start SceneChangeAnimation");
        string path = $"SceneTransPrefab/{(SceneType)scene}/{(SceneType)scene}Animation";
        var canvas = Instantiate(Resources.Load<Canvas>("SceneTransPrefab/Canvas"));
        DontDestroyOnLoad(canvas);
        var animation = Instantiate(Resources.Load<SceneTransController>(path), canvas.transform);
        animation.transDelegate = NextStep;

        animation.Close();
        yield return null;
    }
    IEnumerator NextStep()
    {
        var animation = FindObjectOfType<SceneTransController>();
        yield return new WaitUntil(() => animation.transition.GetCurrentAnimatorStateInfo(0).IsName("Wait"));
        SceneManager.LoadScene(scene);
        yield return WaitUntilSceneLoad.WaitUntilScene(scene);
        animation.Open();
        if (scene == 0)
        {
            while (SceneManager.GetActiveScene().buildIndex != 0)
            {
                yield return null;
            }
            Debug.Log("Game Over");
            Transform canvas = MainCanvas.FindMainCanvas();
            if (canvas != null)
            {
                var pannel = Instantiate(endGamePannel, canvas);
            }
            FindObjectOfType<StandardDialogueUI>().gameObject.SetActive(false);
        }
    }
    public void JumpToSceneTest(int scene)
    {
        StartCoroutine(JumpToScene(scene));
    }
}
