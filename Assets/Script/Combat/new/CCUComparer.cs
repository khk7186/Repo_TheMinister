using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCUComparer : IComparer<CombatCharacterUnit>
{
    public int Compare(CombatCharacterUnit x, CombatCharacterUnit y)
    {
        CombatCharacterUnit ccuX = (CombatCharacterUnit)x;
        CombatCharacterUnit ccuY = (CombatCharacterUnit)y;
        int output = 0;
        if (ccuX.currentAction > ccuY.currentAction)
        {
            output = -1;
        }
        else if (ccuX.currentAction < ccuY.currentAction)
        {
            output = 1;
        }
        else
        {
            var intX = ccuX.character.CharactersValueDict[CharacterValueType.´Ì];
            var intY = ccuY.character.CharactersValueDict[CharacterValueType.´Ì];
            if (intX > intY)
            {
                output = -1;
            }
            else if (intX < intY)
            {
                output = 1;
            }
            else
            {
            }
        }
        return output;
    }
}
