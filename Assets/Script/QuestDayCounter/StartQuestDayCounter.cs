using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartQuestDayCounter : MonoBehaviour
{
    public string QuestID;
    public int maxDay;
    public void Start()
    {
        QuestDayCounterManager.Instance.AddCounter(QuestID, maxDay);
    }
}
