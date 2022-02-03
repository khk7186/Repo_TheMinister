using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatHealthCompareStrategy : MonoBehaviour, IAICombatStrategy
{
    public void MakeDecision(Dictionary<Action, int> targetDic)
    {
        BattleSystem battleSystem = CombatTool.FindBattleSystem();
        List<Character> selfCharacters = battleSystem.EnemyCharacters;
        List<Character> playerCharacters = battleSystem.PlayerCharacters;

        int highestHealth = 20;
        CharacterValueType targetBattletype = CharacterValueType.´Ì;
        if (battleSystem.battleType == BattleType.Debate)
        {
            targetBattletype = CharacterValueType.Ä±;
        }
        foreach (Character ch in playerCharacters)
        {
            if (ch.health < 10)
            {
                targetDic[Action.Assinate] += 1;
            }
            if (ch.health < highestHealth)
            {
                highestHealth = ch.health;
            }
        }
        Character highestAttackCharacter = CombatTool.FindSpecific(selfCharacters, targetBattletype);
        if (highestAttackCharacter.health < 10)
        {
            targetDic[Action.Assinate] -= 1;
        }
        Character enemyLowestHealthCharacter = CombatTool.FindLowestHealth(playerCharacters, battleSystem.battleType);
        if (highestAttackCharacter.CharactersValueDict[targetBattletype] > enemyLowestHealthCharacter.health)
        {
            targetDic[Action.Assinate] += 2;
        }
        foreach (Character ch in selfCharacters)
        {
            if (ch.health < 10)
            {
                targetDic[Action.Surrender] += 5;
                targetDic[Action.Attack] += 1;
                targetDic[Action.Assinate] -= 2;
                targetDic[Action.Defence] += 3;
                if (ch.health < 5)
                {
                    targetDic[Action.Defence] += 3;
                    targetDic[Action.Surrender] += 5;
                }
            }
            
        }
    }
}
