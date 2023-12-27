using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndQuestDayCounter : MonoBehaviour
{
    public string QuestID;
    public void Start()
    {
        QuestDayCounterManager.Instance.RemoveCounter(QuestID);
    }
}