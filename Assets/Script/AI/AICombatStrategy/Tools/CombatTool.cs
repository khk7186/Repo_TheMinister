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
        return new ArrayList() { outputCharacterValueType, result, outputCharacter };
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

    public static BattleSystem FindBattleSystem()
    {
        return GameObject.FindObjectOfType<BattleSystem>();
    }

    public static BaseBattleAI FindBattleAi()
    {
        return FindBattleSystem().battleAI;
    }

    public static Character FindSpecific(List<Character> characters, CharacterValueType valueType)
    {
        Character output = null;
        foreach (Character character in characters)
        {
            if (output == null) output = character;
            else
            {
                if (character.CharactersValueDict[valueType] > output.CharactersValueDict[valueType])
                {
                    output = character;
                }
            }
        }
        return output;
    }

    public static Character FindLowestHealth(List<Character> characters , BattleType battleType)
    {
        Character output = null;
        if (battleType == BattleType.Debate)
        {
            foreach (Character character in characters)
            {
                bool outputNotExist = output == null;
                bool lessCharacterLoyalty = output.loyalty > character.loyalty;
                if (outputNotExist || lessCharacterLoyalty)
                {
                    output = character;
                }
            }
        }
        else if (battleType == BattleType.Duel)
        {
            foreach (Character character in characters)
            {
                bool outputNotExist = output == null;
                bool lessCharacterHealth = output.health > character.health;
                if (outputNotExist || lessCharacterHealth)
                {
                    output = character;
                }
            }
        }
        return output;
    }
    public static Character FindHighestHealth(List<Character> characters , BattleType battleType)
    {
        Character output = null;
        if (battleType == BattleType.Debate)
        {
            foreach (Character character in characters)
            {
                bool outputNotExist = output == null;
                bool moreCharacterLoyalty = output.loyalty < character.loyalty;
                if (outputNotExist || moreCharacterLoyalty)
                {
                    output = character;
                }
            }
        }
        else if (battleType == BattleType.Duel)
        {
            foreach (Character character in characters)
            {
                bool outputNotExist = output == null;
                bool moreCharacterHealth = output.health < character.health;
                if (outputNotExist || moreCharacterHealth)
                {
                    output = character;
                }
            }
        }
        return output;
    }
}
