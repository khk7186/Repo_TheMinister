using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventAfterCombatBasedOnResult : MonoBehaviour
{
    public GeneralEventTrigger trigger;
    public GameTracker Tracker => trigger.gameTracker;
    public UnityEvent WinEvent;
    public UnityEvent LostEvent;

    public void RunEventBasedOnResult()
    {
        if (Tracker.gameWin)
        {
            WinEvent.Invoke();
        }
        else
        {
            LostEvent.Invoke();
        }
    }
}
