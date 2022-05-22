using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DebateTopicCode
{
    以文乱法,
    四书五经,
    经史百子,
    仁义礼智,
    克己复礼,
    存心养性,
    立木为信,
    田忌赛马,
    萧规曹随,
    约法三章,
    合浦珠还,
    指鹿为马,
    咏史怀古,
    山水田园,
    羁旅行役,
    咏物抒怀,
    爱情闺怨,
    边塞军旅,
    借古讽今
}
public class DebateTopic
{
    public static Dictionary<DebateTopicCode, ArrayList> TopicCodeDict =
        new Dictionary<DebateTopicCode, ArrayList>
        {
            {
                DebateTopicCode.以文乱法,
                new ArrayList()
                {
                    Rarerity.N,
                    new List<Tag>(){Tag.讼师, Tag.文正},
                    new CharacterValueType[] { CharacterValueType.才 },
                    new Rarerity[] { Rarerity.N}
                }
            }
        };
    public DebateTopicCode debateTopicCode;
    public Rarerity raririty;
    public List<Tag> tagRequest = new List<Tag>();
    public CharacterValueType[] characterValue = new CharacterValueType[] { };
    public bool IsClose = false;

    public void Setup(DebateTopicCode code)
    {
        debateTopicCode = code;
        raririty = (Rarerity)TopicCodeDict[debateTopicCode][0];
        tagRequest = (List<Tag>)TopicCodeDict[debateTopicCode][1];
        characterValue = (CharacterValueType[])TopicCodeDict[debateTopicCode][2];
    }
    //public int CalculatePoints(Character character)
    //{
    //    int total = 0;
    //    total += (int)character.characterValueRareDict[characterValue];
    //    foreach (Tag tag in tagRequest)
    //    {
    //        if (character.tagList.Contains(tag))
    //        {
    //            total += (int)Player.AllTagRareDict[tag] / 2;
    //        }
    //    }
    //    return total;
    //}
}   
