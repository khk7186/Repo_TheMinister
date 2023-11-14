using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterAwaitTribute : MonoBehaviour
{
    public Character character;
    public int WaitTime;
    public int AlreadyWait = 0;
    public UnityEvent @event;
    private bool destroyNext = false;

    public bool EndWait => AlreadyWait > WaitTime;

    public void TimePlus()
    {
        if (destroyNext) CharacterAwaitTributeManager.Instance.FinishTribute(this);
        AlreadyWait += 1;
        if (EndWait)
        {
            if (@event != null)
            {
                @event.Invoke();
                destroyNext = true;
            }
        }
    }
}
