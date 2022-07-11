using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebateTopicPool : MonoBehaviour
{
    public List<DebateTopic> topics = new List<DebateTopic>();
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
