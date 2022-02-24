using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebateMain : MonoBehaviour
{
    private BattleState CurrentBattleState = BattleState.Start;
    public float waitingTime = 10f;
    public DebateUI debateUIPref;
    public DebateUI currentDebateUI;
    public List<Character> PlayerCharacterList = new List<Character>();
    public List<Character> EnemyACharacterList = new List<Character>();
    public List<Character> EnemyBCharacterList = new List<Character>();
    public List<DebateTopic> debateTopicList = new List<DebateTopic>();
    public Character EnemyACurrent;
    public Character EnemyBCurrent;

    public void StateAction()
    {
        switch (CurrentBattleState)
        {
            default:
                break;
            case BattleState.Start:
                DontDestroyOnLoad(gameObject);
                NextState();
                SceneManager.LoadScene(2);
                break;
            case BattleState.Prepare:
                currentDebateUI.Setup(debateTopicList,PlayerCharacterList, EnemyACurrent, EnemyBCurrent);
                break;
            case BattleState.Fight:
                break;
            case BattleState.Win:
                break;
            case BattleState.Lose:
                break;
            case BattleState.End:
                break;
        }
    }

    private void NextState()
    {
        switch (CurrentBattleState)
        {
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

    private IEnumerator WaitingProgress()
    {
        yield return new WaitForSeconds(waitingTime);
    }

}


