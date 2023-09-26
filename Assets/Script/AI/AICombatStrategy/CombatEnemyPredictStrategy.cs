using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEnemyPredictStrategy : IAICombatStrategy
{
    public void MakeDecision(Dictionary<CombatAction, int> targetDic)
    {
        BattleSystem battleSystem = CombatTool.FindBattleSystem();
        List<Character> playerCharacters = battleSystem.PlayerCharacters;
        BattleType battleType = battleSystem.battleType;
        var targetAL = CombatTool.FindHighestValueCharacter(playerCharacters, battleType);
        var characterValueType = (CharacterValueType)targetAL[0];

        if (battleSystem.battleType == BattleType.Combat)
        {
            switch (characterValueType)
            {
                default:
                    break;
                case CharacterValueType.´Ì:
                    targetDic[CombatAction.Attack]++;
                    break;
                case CharacterValueType.Îä:
                    targetDic[CombatAction.Defence]++;
                    break;
                case CharacterValueType.ÊØ:
                    targetDic[CombatAction.Assassin]++;
                    break;
            }
        }
        else if (battleSystem.battleType == BattleType.Debate)
        {
            switch (characterValueType)
            {
                default:
                    break;
                case CharacterValueType.ÖÇ:
                    targetDic[CombatAction.Attack]++;
                    break;
                case CharacterValueType.²Å:
                    targetDic[CombatAction.Defence]++;
                    break;
                case CharacterValueType.Ä±:
                    targetDic[CombatAction.Assassin]++;
                    break;
            }
        }

    }
}
