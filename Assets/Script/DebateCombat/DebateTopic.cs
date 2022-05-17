using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DebateTopicCode
{
    none,
    墨义
}
public class DebateTopic
{
    public static Dictionary<DebateTopicCode, ArrayList> TopicCodeDict =
        new Dictionary<DebateTopicCode, ArrayList>
        {
            {
                DebateTopicCode.墨义,
                new ArrayList()
                {
                    new List<Tag>(){Tag.讼师, Tag.文正},
                    CharacterValueType.才,
                    1
                }
            }
        };
    public DebateTopicCode DebateTopicCode;
    public List<Tag> tagRequest = new List<Tag>();
    public Rarerity raririty;
    public CharacterValueType[] characterValue = new CharacterValueType[] { CharacterValueType.智 };
    public bool IsClose = false;

    public void Setup()
    {

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
