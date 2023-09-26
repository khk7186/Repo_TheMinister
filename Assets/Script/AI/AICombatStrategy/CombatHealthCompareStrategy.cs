using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatHealthCompareStrategy : MonoBehaviour, IAICombatStrategy
{
    public void MakeDecision(Dictionary<CombatAction, int> targetDic)
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
                targetDic[CombatAction.Assassin] += 1;
            }
            if (ch.health < highestHealth)
            {
                highestHealth = ch.health;
            }
        }
        Character highestAttackCharacter = CombatTool.FindSpecific(selfCharacters, targetBattletype);
        if (highestAttackCharacter.health < 10)
        {
            targetDic[CombatAction.Assassin] -= 1;
        }
        Character enemyLowestHealthCharacter = CombatTool.FindLowestHealth(playerCharacters, battleSystem.battleType);
        if (highestAttackCharacter.CharactersValueDict[targetBattletype] > enemyLowestHealthCharacter.health)
        {
            targetDic[CombatAction.Assassin] += 2;
        }
        foreach (Character ch in selfCharacters)
        {
            if (ch.health < 10)
            {
                targetDic[CombatAction.Surrender] += 5;
                targetDic[CombatAction.Attack] += 1;
                targetDic[CombatAction.Assassin] -= 2;
                targetDic[CombatAction.Defence] += 3;
                if (ch.health < 5)
                {
                    targetDic[CombatAction.Defence] += 3;
                    targetDic[CombatAction.Surrender] += 5;
                }
            }
            
        }
    }
}
