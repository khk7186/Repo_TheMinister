using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebateMainEventManager : MonoBehaviour
{
    public int playerCount = 2;
    public readonly int playerIndex = 0;
    public List<DebateTopic> topicPool = new List<DebateTopic>() { };
    public DebateTopic currentTopic;
    public List<DebateUnit> InGameDebateUnits;
    private void Start()
    {
        Reset();
    }
    public void Reset()
    {
        var pool = FindObjectOfType<DebateTopicPool>();
        var topicPoolList = pool ? pool.topics : null;

        if (topicPool == null)
        {
            var v = Enum.GetValues(typeof(DebateTopicCode));
            for (int i = 0; i < 5; i++)
            {
                System.Random _R = new System.Random();
                var topic = new DebateTopic();
                topic.Setup((DebateTopicCode)v.GetValue(_R.Next(v.Length)));
                this.topicPool.Add(topic);
            }
        }
        else
        {
            topicPool = topicPoolList;
        }
        NextTopic();
        SetGameUnits();
    }
    public void NextTopic()
    {
        currentTopic = topicPool[0];
        //Debug.Log(currentTopic);
        topicPool.RemoveAt(0);
        FindObjectOfType<TopicUI>().StartNewTopic(currentTopic);
        foreach (DebateCharacterCard card in InGameDebateUnits[0].characterCards)
        {
            if (card.CardUI.OnSelect)
            {
                card.CardUI.UnSelectCharacter();
            }
        }
    }
    public void SetGameUnits()
    {
        var GET = FindObjectOfType<GeneralEventTrigger>();
        InGameDebateUnits[0].Setup(GET.playerCharacters, "李袁陌", CharacterArtCode.官员, true);
        InGameDebateUnits[0].SetUnitUI(InGameDebateUnits[0].GetComponent<DebateUnitUI>());
        for (int i = 0; (i) < GET.enemyCharactersCardsList.Count; i++)
        {
            var thisCharacterList = GET.enemyCharactersCardsList[i];
            InGameDebateUnits[i + 1].Setup(thisCharacterList.ToList(), thisCharacterList[0].CharacterName, thisCharacterList[0].characterArtCode);
            var thisUI = InGameDebateUnits[i + 1].GetComponent<DebateUnitUI>();
            InGameDebateUnits[i + 1].SetUnitUI(thisUI);
        }
        for (int i = GET.enemyCharactersCardsList.Count + 1; i < 4; i++)
        {
            InGameDebateUnits[i].Setup(null, null, CharacterArtCode.女诗人, false);
        }
    }
    public void StartDebate()
    {
        List<Character[]> characters = new List<Character[]>();
        List<CharacterArtCode> idleImages = new List<CharacterArtCode>();
        idleImages.Add(CharacterArtCode.李袁陌);
        InGameDebateUnits[0].CheckSelection();
        characters.Add(InGameDebateUnits[0].selectCharacters.ToArray());
        for (int i = 1; i < InGameDebateUnits.Count; i++)
        {
            if (InGameDebateUnits[i].gameObject.activeSelf == false)
            {
                break;
            }
            if (InGameDebateUnits[i].Points <= 0)
            {
                characters.Add(new Character[] { });
                continue;
            }
            var unit = InGameDebateUnits[i];
            idleImages.Add(unit.IconArtCode);
            var selectedCharacterCards = DebateAI.MakeDecision(unit, currentTopic);
            var selectedCharacter = new Character[selectedCharacterCards.Count];
            int count = 0;
            foreach (var card in selectedCharacterCards)
            {
                selectedCharacter[count] = card.character;
                count++;
            }
            characters.Add(selectedCharacter);
        }
        //Debug.Log("total ch:" + characters.Count);
        ScoreReviewEvent.NewReview(characters, currentTopic, idleImages);
    }

}


