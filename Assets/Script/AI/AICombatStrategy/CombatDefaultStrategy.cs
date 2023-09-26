using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatDefaultStrategy : IAICombatStrategy
{
    public void MakeDecision(Dictionary<CombatAction, int> targetDic)
    {
        BattleSystem battleSystem = CombatTool.FindBattleSystem();
        List<Character> selfCharacters = battleSystem.EnemyCharacters;
        BattleType battleType = battleSystem.battleType;
        var targetAL = CombatTool.FindHighestValueCharacter(selfCharacters, battleType);
        var characterValueType = (CombatAction)targetAL[0];
        targetDic[characterValueType] += (int)targetAL[1];
    }
}
