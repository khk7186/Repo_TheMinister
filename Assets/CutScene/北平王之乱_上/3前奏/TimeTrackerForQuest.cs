using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.QuestMachine;
using System.Linq;

public class TimeTrackerForQuest : MonoBehaviour, IObserver
{
    public string QuestID;
    public string CounterName;
    public int RequireTime = 1;
    public int CurrentTime = 0;
    public int CurrentFloat = 0;
    public GameObject ExtraToActive = null;

    public void OnNotify(object value, NotificationType notificationType)
    {
        if (notificationType == NotificationType.DiceRoll)
        {
            CurrentFloat += 1;
            if (CurrentFloat == 3) 
            {
                CurrentFloat = 0;
                CurrentTime += 1;
                SyncJurnal(CurrentTime);
            }
            if (CurrentTime == RequireTime)
            {
                ExtraToActive.SetActive(true);
                Destroy(gameObject,2f);
            }
        }
    }
    public void SyncJurnal(int current)
    {
        QuestMachineMessages.SetQuestCounter(null, new PixelCrushers.StringField(QuestID), new PixelCrushers.StringField(CounterName), current);
    }
    private void OnEnable()
    {
        ExtraToActive.SetActive(false);
        DontDestroyOnLoad(gameObject);
        foreach (var subject in FindObjectsOfType<MonoBehaviour>().OfType<ISubject>())
        {
            subject.RegisterObserver(this);
        }
    }

}
