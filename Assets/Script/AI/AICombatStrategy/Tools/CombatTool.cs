using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTool : MonoBehaviour
{
    public static ArrayList FindHighestValueCharacter(List<Character> characters, BattleType battleType)
    {
        int result = 0;
        CharacterValueType outputCharacterValueType = CharacterValueType.ÖÇ;
        Character outputCharacter = null; 
        foreach (Character ch in characters)
        {
            var duelValueType = CombatValueType(battleType);
            foreach (CharacterValueType valueType in duelValueType)
            {
                int tryValue = ch.CharactersValueDict[valueType];
                if (tryValue > result)
                {
                    result = tryValue;
                    outputCharacterValueType = valueType;
                    if (outputCharacter != ch)
                    {
                        outputCharacter = ch;
                    }
                }
            }
        }
        return new ArrayList(){outputCharacterValueType, result, outputCharacter};
    }

    public static List<CharacterValueType> CombatValueType(BattleType battleType)
    {
        if (battleType == BattleType.Duel)
        {
            return new List<CharacterValueType>()
            {
                CharacterValueType.Îä,
                CharacterValueType.ÊØ,
                CharacterValueType.´Ì
            };
        }
        else
        {
            return new List<CharacterValueType>()
            {
                CharacterValueType.ÖÇ,
                CharacterValueType.²Å,
                CharacterValueType.Ä±
            };
        }
    }
}
