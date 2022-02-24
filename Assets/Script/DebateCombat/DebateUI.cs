using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebateUI : MonoBehaviour
{
    public List<DebateCharacterUI> PlayerCharacterList = new List<DebateCharacterUI>();
    public DebateCharacterUI EnemyACharacterList;
    public DebateCharacterUI EnemyBCharacterList;
    public DebateTopicUI currentDebateTopicList;
    public DebateTopicUI nextDebateTopicList;

    public void Setup(List<DebateTopic> debateTopics, List<Character> playerCharacters, Character Acharacters, Character Bcharacters)
    {

    }
}
