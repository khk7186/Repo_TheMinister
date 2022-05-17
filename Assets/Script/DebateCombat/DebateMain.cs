using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebateMain : MonoBehaviour
{
    public int playerCount = 2;
    public readonly int playerIndex = 0;
    public List<DebateTopic> topicPool;
    public DebateTopic currentTopic;
}


