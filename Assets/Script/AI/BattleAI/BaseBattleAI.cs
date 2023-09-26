using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBattleAI
{
    public Dictionary<CombatAction, int> DecisionPoints =
        new Dictionary<CombatAction, int>()
                {
                    { CombatAction.Attack,5 },
                    { CombatAction.Defence, 5 },
                    { CombatAction.Assassin, 5 },
                    { CombatAction.Surrender, 0 }
                };
    public Character nextCharacter;

    public CombatAction MakeDecision(List<Character> characters, BattleSystem battleSystem)
    {
        int highestPoints = 0;
        CombatAction output = CombatAction.Attack;
        foreach (CombatAction key in DecisionPoints.Keys)
        {
            if (DecisionPoints[key] > highestPoints)
            {
                output = key;
                highestPoints = DecisionPoints[key];
            }
        }
        var information = CombatTool.FindHighestValueCharacter(characters, battleSystem.battleType);
        nextCharacter = information[2] as Character;
        return output;
    }


    public void SetDefaultDecision(BattleType battleType)
    {
        DecisionPoints = new Dictionary<CombatAction, int>()
                {
                    { CombatAction.Attack,5 },
                    { CombatAction.Defence, 5 },
                    {CombatAction.Assassin, 5 },
                    { CombatAction.Surrender, 0 }
                };
    }
}
