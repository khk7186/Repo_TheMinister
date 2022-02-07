using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBattleAI
{
    public Dictionary<Action, int> DecisionPoints =
        new Dictionary<Action, int>()
                {
                    { Action.Attack,5 },
                    { Action.Defence, 5 },
                    { Action.Assassinate, 5 },
                    { Action.Surrender, 0 }
                };
    public Character nextCharacter;

    public Action MakeDecision(List<Character> characters, BattleSystem battleSystem)
    {
        int highestPoints = 0;
        Action output = Action.Attack;
        foreach (Action key in DecisionPoints.Keys)
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
        DecisionPoints = new Dictionary<Action, int>()
                {
                    { Action.Attack,5 },
                    { Action.Defence, 5 },
                    {Action.Assassinate, 5 },
                    { Action.Surrender, 0 }
                };
    }
}
