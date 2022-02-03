using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCompareStrategy : MonoBehaviour, IAICombatStrategy
{
    public void MakeDecision(Dictionary<Action, int> targetDic)
    {
        BattleSystem battleSystem = CombatTool.FindBattleSystem();
        List<Character> playerCharacters = battleSystem.PlayerCharacters;
        List<Character> selfCharacters = battleSystem.EnemyCharacters;
        BattleType battleType = battleSystem.battleType;
        foreach (Character character in playerCharacters)
        {

        }
    }
}
