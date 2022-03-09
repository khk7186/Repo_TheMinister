using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoBangBattle : MonoBehaviour
{
    public BattleState CurrentBattleState = default;
    public Character playerCharacter;
    public Character enemyCharacter;

    public GoBangUI goBangPrefeb;
    public GoBangUI currentGoBang;
    private void NextState()
    {
        switch (CurrentBattleState)
        {
            default:
                break;
            case BattleState.Start:
                CurrentBattleState = BattleState.Prepare;
                break;
            case BattleState.Fight:
                CurrentBattleState = BattleState.Prepare;
                break;
            case BattleState.Prepare:
                CurrentBattleState = BattleState.Fight;
                break;
            case BattleState.Win:
                CurrentBattleState = BattleState.End;
                break;
            case BattleState.Lose:
                CurrentBattleState = BattleState.End;
                break;
        }
    }

    public void StateAction()
    {
        switch (CurrentBattleState)
        {
            default:
                break;
            case BattleState.Start:
                DontDestroyOnLoad(gameObject); 
                SceneManager.LoadScene(2);
                break;
            case BattleState.Prepare:
                if (currentGoBang == null)
                {
                    var tool = GetComponent<SpawnUI>();
                    currentGoBang = tool.SpawnWithReturn().GetComponent<GoBangUI>();
                }
                break;
            case BattleState.Fight:
                
                break;
            case BattleState.Win:
                CurrentBattleState = BattleState.End;
                break;
            case BattleState.Lose:
                CurrentBattleState = BattleState.End;
                break;
        }
    }
}
