using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AbleToCombat
{

    public static bool Check(BattleType BattleType, List<IAfterAbleToCombatCheck> afterAbleToCombatCheckList)
    {
        var result = CheckingForDuty(BattleType);
        if (result == true)
        {
            foreach (var action in afterAbleToCombatCheckList)
            {
                action.AfterCombatCheck().Invoke();
            }
        }
        return result;
    }

    public static bool CheckingForDuty(BattleType BattleType)
    {
        switch (BattleType)
        {
            case BattleType.Combat:
                var playerCharacters = SelectOnDuty.GetOndutyAll(OndutyType.Combat);
                if (playerCharacters != null && playerCharacters.Count > 0)
                {
                    return true;
                }
                return false;

            case BattleType.Debate:
                var playerDebateCharacters = SelectOnDuty.GetOndutyAll(OndutyType.Debate);
                if (playerDebateCharacters != null && playerDebateCharacters.Count > 0)
                {
                    return true;
                }
                return false;

            default: return false;
        }
    }
}
public interface IAfterAbleToCombatCheck
{
    public UnityEvent AfterCombatCheck();
}
