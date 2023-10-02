using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveNextMainEvent : MonoBehaviour
{
    [SerializeField]
    public MainEventUnitProfile nextEvent;
    public int waitForTurns = 0;
    public bool ActiveOnEnable = true;
    public void OnEnable()
    {
        if (ActiveOnEnable)
        {
            Active();
        }
    }
    public void Active()
    {
        GameEventManager.Instance.ActiveNext(nextEvent,waitForTurns);
    }
}
