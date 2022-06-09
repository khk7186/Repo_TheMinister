using System;
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
    public DebateUnit[] debateUnits;
    private void Start()
    {
        Reset();
    }
    public void Reset(List<DebateTopic> topicPool = null)
    {
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
            NextTopic();
        }
        this.topicPool = topicPool;
    }
    public void NextTopic()
    {
        currentTopic = topicPool[0];
        topicPool.RemoveAt(0);
        FindObjectOfType<TopicUI>().StartNewTopic(currentTopic);
    }
    public void StartDebate()
    {
        debateUnits = FindObjectsOfType<DebateUnit>();
        List<Character[]> characters = new List<Character[]>();
        CharacterArtCode[] idleImages = new CharacterArtCode[playerCount];
        for (int i = 0; i < debateUnits.Length; i++)
        {
            var unit = debateUnits[i];
            unit.CheckSelection();
            idleImages[i] = unit.IconArtCode;
            characters.Add(unit.selectCharacters.ToArray());
        }
        ScoreReviewEvent.NewReview(characters, currentTopic, idleImages);
    }
}


