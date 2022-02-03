using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleInformationUI : MonoBehaviour
{
    public Text text;
    public void Setup()
    {
        var target = GetComponent<BattleSystem>();
        Action selfAction = target.currentPlayerAction;
        Action enemyAction = target.currentEnemyAction;
        switch (selfAction)
        {
            default:
                break;
            case Action.Attack:
                switch (enemyAction)
                {
                    default:
                        break;
                    case Action.Attack:
                        
                        break;
                }
                break;
        }       
    }

}
