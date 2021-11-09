using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMapAgent : MonoBehaviour
{
    public static Dictionary<QuestLine, QuestLineAgent> QuestMap
        = new Dictionary<QuestLine, QuestLineAgent>()
        {
            { QuestLine.Ì«²Öºþ, new QuestLineAgent(QuestType.MainQuest, QuestLine.Ì«²Öºþ)}
        };
}
