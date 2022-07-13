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
            },
            {DebateTopicCode.四书五经,new ArrayList(){Rarerity.SR,new List < Tag > (){Tag.书通二酉, Tag.阳明学派, Tag.书痴},new CharacterValueType[] {CharacterValueType.智},new Rarerity[] {Rarerity.SR}}},
            {DebateTopicCode.经史百子,new ArrayList(){Rarerity.SSR,new List < Tag > (){Tag.状元, Tag.欢喜佛, Tag.儒生},new CharacterValueType[] {CharacterValueType.智},new Rarerity[] {Rarerity.SSR}}},
            {DebateTopicCode.仁义礼智,new ArrayList(){Rarerity.SR,new List < Tag > (){Tag.仁人君子, Tag.外交官},new CharacterValueType[] {CharacterValueType.智},new Rarerity[] {Rarerity.SR}}},
            {DebateTopicCode.克己复礼,new ArrayList(){Rarerity.SR,new List < Tag > (){Tag.古神转世, Tag.把素持斋, Tag.僧人},new CharacterValueType[] {CharacterValueType.智},new Rarerity[] {Rarerity.SR}}},
            {DebateTopicCode.存心养性,new ArrayList(){Rarerity.SR,new List < Tag > (){Tag.黄帝内经, Tag.道士},new CharacterValueType[] {CharacterValueType.智},new Rarerity[] {Rarerity.SR}}},
            {DebateTopicCode.立木为信,new ArrayList(){Rarerity.SR,new List < Tag > (){Tag.长袖善舞, Tag.货郎},new CharacterValueType[] {CharacterValueType.谋},new Rarerity[] {Rarerity.SR}}},
            {DebateTopicCode.田忌赛马,new ArrayList(){Rarerity.R,new List < Tag > (){Tag.小有谋略, Tag.演员},new CharacterValueType[] {CharacterValueType.谋},new Rarerity[] {Rarerity.R}}},
            {DebateTopicCode.萧规曹随,new ArrayList(){Rarerity.SSR,new List < Tag > (){Tag.墨守成规, Tag.纵横家},new CharacterValueType[] {CharacterValueType.谋},new Rarerity[] {Rarerity.SSR}}},
            {DebateTopicCode.约法三章,new ArrayList(){Rarerity.SR,new List < Tag > (){Tag.朝奉, Tag.讼师, Tag.货郎},new CharacterValueType[] {CharacterValueType.谋},new Rarerity[] {Rarerity.SR}}},
            {DebateTopicCode.合浦珠还,new ArrayList(){Rarerity.R,new List < Tag > (){Tag.棋道, Tag.老戏骨},new CharacterValueType[] {CharacterValueType.谋},new Rarerity[] {Rarerity.R}}},
            {DebateTopicCode.指鹿为马,new ArrayList(){Rarerity.R,new List < Tag > (){Tag.离经叛道, Tag.法外狂徒},new CharacterValueType[] {CharacterValueType.谋},new Rarerity[] {Rarerity.R}}},
            {DebateTopicCode.咏史怀古,new ArrayList(){Rarerity.SR,new List < Tag > (){Tag.仁人君子, Tag.儒生},new CharacterValueType[] {CharacterValueType.才},new Rarerity[] {Rarerity.SR}}},
            {DebateTopicCode.山水田园,new ArrayList(){Rarerity.SR,new List < Tag > (){Tag.长袖善舞, Tag.无伤大雅},new CharacterValueType[] {CharacterValueType.才},new Rarerity[] {Rarerity.SR}}},
            {DebateTopicCode.羁旅行役,new ArrayList(){Rarerity.SR,new List < Tag > (){Tag.奇门遁甲, Tag.外乡人, Tag.西洋语},new CharacterValueType[] {CharacterValueType.才},new Rarerity[] {Rarerity.SR}}},
            {DebateTopicCode.咏物抒怀,new ArrayList(){Rarerity.SR,new List < Tag > (){Tag.才华横溢, Tag.略有才名},new CharacterValueType[] {CharacterValueType.才},new Rarerity[] {Rarerity.SR}}},
            {DebateTopicCode.爱情闺怨,new ArrayList(){Rarerity.SR,new List < Tag > (){Tag.诗兴大发, Tag.家室美满, Tag.绣花枕头},new CharacterValueType[] {CharacterValueType.才},new Rarerity[] {Rarerity.SR}}},
            {DebateTopicCode.边塞军旅,new ArrayList(){Rarerity.SR,new List < Tag > (){Tag.智勇双全, Tag.奇门遁甲, Tag.宝马良驹},new CharacterValueType[] {CharacterValueType.才},new Rarerity[] {Rarerity.SR}}},
            {DebateTopicCode.借古讽今,new ArrayList(){Rarerity.SR,new List < Tag > (){Tag.忠贞之志, Tag.老戏骨},new CharacterValueType[] {CharacterValueType.谋},new Rarerity[] {Rarerity.SR}}}

        };
    public DebateTopicCode debateTopicCode;
    public Rarerity rarerity;
    public List<Tag> tagRequest = new List<Tag>();
    public CharacterValueType[] characterValue = new CharacterValueType[] { };
    public bool IsClose = false;

    public void Setup(DebateTopicCode code)
    {
        debateTopicCode = code;
        rarerity = (Rarerity)TopicCodeDict[debateTopicCode][0];
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
