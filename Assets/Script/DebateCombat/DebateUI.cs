using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebateUI : MonoBehaviour
{
    public List<DebateUnitUI> PlayerCharacterList = new List<DebateUnitUI>();
    public DebateUnitUI EnemyLeftCharacterList;
    public DebateUnitUI EnemyRightCharacterList;
    public DebateUnitUI EnemyTopCharacterList;
    public DebateTopicUI currentDebateTopicList;
    public DebateTopicUI nextDebateTopicList;

    public void Setup(List<DebateTopic> debateTopics, List<Character> playerCharacters, Character Acharacters, Character Bcharacters)
    {

    }

}
