using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TopicPointsCalculator : MonoBehaviour
{
    public enum DebatePointCollector
    {
        闺秀,
        大家闺秀,
        才子,
        大才子,
        有理有据,
        感同身受,
        力压众异,
        地位超然,
        言语粗鄙,
        权威,
        词不对板,
        乱纪,
        一枝独秀,
        在其位,
        披靡,
        破绽百出,
        破绽,
        内幕,
        乱心,
        绣花枕头,
        子不语,
        以众敌寡,
        国士无双,
        尽诚竭节,
        不臣之心,
        强自镇定
    }
    private delegate bool TopicPointsCalculatorDelegate(DebateTopic topic, Character[] playerCharacters, object value);
    static TopicPointsCalculatorDelegate isCharacterFemale = IsCharacterFemale;
    static TopicPointsCalculatorDelegate isWisdomAboveR = IsWisdomAboveR;
    static TopicPointsCalculatorDelegate isWisdomAboveSR = IsWisdomAboveSR;
    static TopicPointsCalculatorDelegate isWisdomAboveSSR = IsWisdomAboveSSR;
    static TopicPointsCalculatorDelegate isWisdomBelowN = IsWisdomBelowN;
    static TopicPointsCalculatorDelegate isGetRightTag = IsGetRightTag;
    static TopicPointsCalculatorDelegate isGetAllRightTags = IsGetAllRightTags;
    static TopicPointsCalculatorDelegate isRollingOthers = IsRollingOthers;
    static TopicPointsCalculatorDelegate isOnlyGoverner = IsOnlyGoverner;
    static TopicPointsCalculatorDelegate isStatHighest = IsStatHighest;
    static TopicPointsCalculatorDelegate isStatBelowN = IsStatBelowN;
    static TopicPointsCalculatorDelegate isCarryWeapon = IsCarryWeapon;
    static TopicPointsCalculatorDelegate isOtherCarryWeapon = IsOtherCarryWeapon;
    static TopicPointsCalculatorDelegate isSolo = IsSolo;
    static TopicPointsCalculatorDelegate isRarityFit = IsRarityFit;
    static TopicPointsCalculatorDelegate isAnyUR = IsAnyUR;
    static TopicPointsCalculatorDelegate isStrategyLowest = IsStrategyLowest;
    static TopicPointsCalculatorDelegate isStrategyLowerThanAny = IsStrategyLowerThanAny;
    static TopicPointsCalculatorDelegate isStrategyRequiredAndGotHighest = IsStrategyRequiredAndGotHighest;
    static TopicPointsCalculatorDelegate isStrategyNotRequiredAndGotHighest = IsStrategyNotRequiredAndGotHighest;
    static TopicPointsCalculatorDelegate isAnyFemaleGotHigherStrategyThanMale = IsAnyFemaleGotHigherStrategyThanMale;
    static TopicPointsCalculatorDelegate isAnyFemaleExist = IsAnyFemaleExist;
    static TopicPointsCalculatorDelegate isAnyRequiredStatLowest = IsAnyRequiredStatLowest;
    static TopicPointsCalculatorDelegate isFallingOnTopic = IsFallingOnTopic;
    static TopicPointsCalculatorDelegate isGotHelp = IsGotHelp;
    static TopicPointsCalculatorDelegate isRollingOnTopic = IsRollingOnTopic;
    static TopicPointsCalculatorDelegate isLoyaltyHigh = IsLoyaltyHigh;
    static TopicPointsCalculatorDelegate isLoyaltyLow = IsLoyaltyLow;

    private static Dictionary<DebatePointCollector, List<TopicPointsCalculatorDelegate>> debatePointCollectorToDelegate
        = new Dictionary<DebatePointCollector, List<TopicPointsCalculatorDelegate>>()
        {
            { DebatePointCollector.闺秀, new List<TopicPointsCalculatorDelegate> {isCharacterFemale } },

        };

    static bool IsCharacterFemale(DebateTopic topic, Character[] playerCharacters, object value)
    {
        bool output = false;
        return output;
    }
    static bool IsWisdomAboveR(DebateTopic topic, Character[] playerCharacters, object value = null)
    {
        foreach (Character character in playerCharacters)
        {
            if (character.characterValueRareDict[CharacterValueType.才] > Rarerity.R)
            {
                return true;
            }
        }
        return false;
    }
    static bool IsWisdomAboveSR(DebateTopic topic, Character[] playerCharacters, object value = null)
    {
        foreach (Character character in playerCharacters)
        {
            if (character.characterValueRareDict[CharacterValueType.才] > Rarerity.SR)
            {
                return true;
            }
        }
        return false;
    }

    static bool IsWisdomAboveSSR(DebateTopic topic, Character[] playerCharacters, object value = null)
    {
        foreach (Character character in playerCharacters)
        {
            if (character.characterValueRareDict[CharacterValueType.才] > Rarerity.SSR)
            {
                return true;
            }
        }
        return false;
    }
    static bool IsWisdomBelowN(DebateTopic topic, Character[] playerCharacters, object value = null)
    {
        foreach (Character character in playerCharacters)
        {
            if (character.characterValueRareDict[CharacterValueType.才] < Rarerity.N)
            {
                return true;
            }
        }
        return false;
    }
    static bool IsGetRightTag(DebateTopic topic, Character[] playerCharacters, object value)
    {
        Tag tag = (Tag)value;
        foreach (Character character in playerCharacters)
        {
            if (character.tagList.Contains(tag))
            {
                return true;
            }
        }
        return false;
    }
    static bool IsGetAllRightTags(DebateTopic topic, Character[] playerCharacters, object value)
    {
        List<Tag> tagList = (List<Tag>)value;
        foreach (Tag tag in tagList)
        {
            for (int i = playerCharacters.Length; i > 0; i--)
            {
                var character = playerCharacters[i - 1];
                if (character.tagList.Contains(tag))
                {
                    break;
                }
                else if (i == 1)
                {
                    return false;
                }
            }
        }
        return true;
    }
    static bool IsRollingOthers(DebateTopic topic, Character[] playerCharacters, object value)
    {
        int playerTotal = 0;
        foreach (Character character in playerCharacters)
        {
            foreach (CharacterValueType valueType in topic.characterValue)
            {
                playerTotal += character.CharactersValueDict[valueType];
            }
        }
        var otherPlayers = value as List<Character[]>;
        var otherTotal = new int[otherPlayers.Count];
        for (int i = 0; i < otherPlayers.Count; i++)
        {
            foreach (Character character in otherPlayers[i])
            {
                foreach (CharacterValueType valueType in topic.characterValue)
                {
                    otherTotal[i] += character.CharactersValueDict[valueType];
                }
            }
        }
        foreach (int total in otherTotal)
        {
            if (total > playerTotal)
            {
                return false;
            }
        }
        return true;
    }

    static bool IsOnlyGoverner(DebateTopic topic, Character[] playerCharacters, object value)
    {
        foreach (Character character in playerCharacters)
        {
            //if (character.tagList.Contains(Tag.))
            //{
            //    return true;
            //}
        }
        return false;
    }
    static bool IsStatHighest(DebateTopic topic, Character[] playerCharacters, object value)
    {
        //TODO: Fix value
        var input = value as ArrayList;
        var type = (CharacterValueType)input[0];
        var otherPlayersValue = input[1] as int[] ?? new int[1] { 0 };
        int playerHighestValue = 0;
        foreach (Character character in playerCharacters)
        {
            if (character.CharactersValueDict[type] > playerHighestValue)
            {
                playerHighestValue = character.CharactersValueDict[type];
            }
        }
        bool output = otherPlayersValue.Append(playerHighestValue).Max() == playerHighestValue;
        return output;
    }
    static bool IsStatBelowN(DebateTopic topic, Character[] playerCharacters, object value)
    {
        var type = (CharacterValueType)value;
        int playerHighestValue = 0;
        foreach (Character character in playerCharacters)
        {
            if (character.CharactersValueDict[type] < playerHighestValue)
            {
                playerHighestValue = character.CharactersValueDict[type];
            }
        }
        bool output = playerHighestValue < (int)Rarerity.N;
        return output;
    }
    static bool IsCarryWeapon(DebateTopic topic, Character[] playerCharacters, object value)
    {
        bool output = false;
        return output;
    }
    static bool IsOtherCarryWeapon(DebateTopic topic, Character[] playerCharacters, object value)
    {
        //var otherPlayers = value as List<Character[]>;
        //foreach (Character[] otherPlayer in otherPlayers)
        //{
        //    foreach (Character character in otherPlayer)
        //    {
        //        if (character.tagList.Contains())
        //        {
        //            return true;
        //        }
        //    }
        //}
        bool output = false;
        return output;
    }
    static bool IsSolo(DebateTopic topic, Character[] playerCharacters, object value)
    {
        bool output = playerCharacters.Length == 1;
        return output;
    }
    static bool IsRarityFit(DebateTopic topic, Character[] playerCharacters, object value)
    {
        var rarity = topic.raririty;

        foreach (Character character in playerCharacters)
        {
            var characterRarities = new int[]
            {
                (int)character.characterValueRareDict[CharacterValueType.智],
                (int)character.characterValueRareDict[CharacterValueType.才],
                (int)character.characterValueRareDict[CharacterValueType.谋]
            };
            if (characterRarities.Max() == (int)rarity)
            {
                return true;
            }
        }
        return false;
    }
    static bool IsAnyUR(DebateTopic topic, Character[] playerCharacters, object value)
    {
        CharacterValueType valueType = (CharacterValueType)value;
        foreach (Character character in playerCharacters)
        {
            if (character.characterValueRareDict[valueType] == Rarerity.UR)
            {
                return true;
            }
        }
        return false;
    }
    static bool IsStrategyLowest(DebateTopic topic, Character[] playerCharacters, object value)
    {
        int playerHighestStradegy = 0;
        foreach (Character character in playerCharacters)
        {
            playerHighestStradegy = new int[] { playerHighestStradegy, character.CharactersValueDict[CharacterValueType.谋] }.Max();
        }
        var otherPlayers = value as List<Character[]>;
        foreach (Character[] otherPlayer in otherPlayers)
        {
            foreach (Character character in otherPlayer)
            {
                if (character.CharactersValueDict[CharacterValueType.谋] < playerHighestStradegy)
                {
                    return false;
                }
            }
        }
        return true;
    }
    static bool IsStrategyLowerThanAny(DebateTopic topic, Character[] playerCharacters, object value)
    {
        int playerHighestStradegy = 0;
        foreach (Character character in playerCharacters)
        {
            playerHighestStradegy = new int[] { playerHighestStradegy, character.CharactersValueDict[CharacterValueType.谋] }.Max();
        }
        Character[] otherCharacters = value as Character[];
        int otherHighestStradegy = 0;
        foreach (Character character in otherCharacters)
        {
            otherHighestStradegy = new int[] { otherHighestStradegy, character.CharactersValueDict[CharacterValueType.谋] }.Max();
        }
        bool output = new int[] { playerHighestStradegy, otherHighestStradegy }.Min() == playerHighestStradegy;
        return output;
    }
    static bool IsStrategyNotRequiredAndGotHighest(DebateTopic topic, Character[] playerCharacters, object value)
    {
        int playerHighestStradegy = 0;
        foreach (Character character in playerCharacters)
        {
            playerHighestStradegy = new int[] { playerHighestStradegy, character.CharactersValueDict[CharacterValueType.谋] }.Max();
        }
        var otherPlayers = value as List<Character[]>;
        foreach (Character[] otherPlayer in otherPlayers)
        {
            foreach (Character character in otherPlayer)
            {
                if (character.CharactersValueDict[CharacterValueType.谋] > playerHighestStradegy)
                {
                    return false;
                }
            }
        }
        return true;
    }
    static bool IsStrategyRequiredAndGotHighest(DebateTopic topic, Character[] playerCharacters, object value)
    {
        if (topic.characterValue.Contains(CharacterValueType.谋))
        {
            return isStrategyNotRequiredAndGotHighest(topic, playerCharacters, value);
        }
        return false;
    }
    static bool IsAnyFemaleGotHigherStrategyThanMale(DebateTopic topic, Character[] playerCharacters, object value)
    {
        //TODO: female
        return false;
    }
    static bool IsAnyFemaleExist(DebateTopic topic, Character[] playerCharacters, object value)
    {
        var otherPlayers = value as List<Character[]>;
        foreach (Character[] otherPlayer in otherPlayers)
        {
            foreach (Character character in otherPlayer)
            {
                //if (femaleArtCode.contain( character.characterArtCode))
                //{
                //    return true;
                //}
            }
        }
        return false;
    }
    static bool IsAnyRequiredStatLowest(DebateTopic topic, Character[] playerCharacters, object value)
    {
        var requiredStats = topic.characterValue;
        int[] playerHighestValue = new int[requiredStats.Length];
        foreach (Character character in playerCharacters)
        {
            for (int i = 0; i < requiredStats.Length; i++)
            {
                playerHighestValue[i] = new int[] { playerHighestValue[i], character.CharactersValueDict[requiredStats[i]] }.Max();
            }
        }
        int[] resultValue = playerHighestValue.Select(x => x).ToArray();
        var otherPlayers = value as List<Character[]>;
        for (int i = 0; i < requiredStats.Length; i++)
        {
            foreach (Character[] otherPlayer in otherPlayers)
            {
                foreach (Character character in otherPlayer)
                {
                    resultValue[i] = new int[] { resultValue[i], character.CharactersValueDict[requiredStats[i]] }.Min();
                }
            }
            if (resultValue[i] == playerHighestValue[i])
            {
                return true;
            }
        }
        return false;
    }

    static bool IsFallingOnTopic(DebateTopic topic, Character[] playerCharacters, object value)
    {
        return false;
    }
    static bool IsGotHelp(DebateTopic topic, Character[] playerCharacters, object value)
    {
        bool output = playerCharacters.Length > 1;
        return output;
    }
    static bool IsRollingOnTopic(DebateTopic topic, Character[] playerCharacters, object value)
    {
        var otherPlayers = value as List<Character[]>;
        foreach (CharacterValueType characterValueType in topic.characterValue)
        {
            if (!IsStatHighest(topic, playerCharacters, new ArrayList() { characterValueType, otherPlayers }))
            {
                return false;
            }
        }
        if (!IsGetAllRightTags(topic, playerCharacters, value))
        {
            return false;
        }
        if (!IsRarityFit(topic, playerCharacters, value))
        {
            return false;
        }
        return true;
    }
    static bool IsLoyaltyHigh(DebateTopic topic, Character[] playerCharacters, object value)
    {
        foreach (Character character in playerCharacters)
        {
            if (character.loyalty >= 15)
            {
                return true;
            }
        }
        return false;
    }
    static bool IsLoyaltyLow(DebateTopic topic, Character[] playerCharacters, object value)
    {
        foreach (Character character in playerCharacters)
        {
            if (character.loyalty <= 5)
            {
                return true;
            }
        }
        return false;
    }
}
