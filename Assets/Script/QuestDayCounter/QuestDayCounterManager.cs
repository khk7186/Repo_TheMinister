using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.QuestMachine;
using PixelCrushers.QuestMachine.Wrappers;
using UnityEditor.VersionControl;

public class QuestDayCounterManager : MonoBehaviour
{
    public static QuestDayCounterManager Instance;
    public List<QuestDayCounter> QuestDayCounters = new List<QuestDayCounter>();
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void Reset()
    {
        QuestDayCounters.Clear();
    }
    public void AddDay()
    {
        foreach (QuestDayCounter counter in QuestDayCounters)
        {
            counter.DayCount++;
        }
        SendSetDaysMessages();
    }
    public void SendSetDaysMessages()
    {
        foreach (QuestDayCounter counter in QuestDayCounters)
        {
            PixelCrushers.MessageSystem.SendMessage(null, "SetDays", counter.QuestID, counter.DayCount);
        }
    }
    public void AddCounter(string questID)
    {
        QuestDayCounterManager.Instance.QuestDayCounters.Add(new QuestDayCounter { QuestID = questID, DayCount = 0 });
    }
    public void RemoveCounter(string questID)
    {
        foreach (QuestDayCounter counter in QuestDayCounters)
        {
            if (counter.QuestID == questID)
            {
                QuestDayCounters.Remove(counter);
                return;
            }
        }
    }
    public void Load()
    {
        SendSetDaysMessages();
    }
}
