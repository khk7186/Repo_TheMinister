using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebateTopicPool : MonoBehaviour
{
    public static DebateTopicPool CurrentPool = null;
    public List<DebateTopic> topics = new List<DebateTopic>();
    public bool ManualSetup = false;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void OnEnable()
    {
        if (ManualSetup == false) return;
        foreach (DebateTopic topic in topics)
        {
            topic.Setup(topic.debateTopicCode);
        }
        ManualSetup = false;
    }
}
