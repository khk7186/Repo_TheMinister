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
    public bool destroyNext = false;

    public bool EndWait => AlreadyWait > WaitTime;

    public void TimePlus()
    {
        AlreadyWait += 1;
        if (EndWait)
        {
            if (@event != null)
            {
                character.TryRetire();
                if (character.hireStage == HireStage.Hired) character.TryDeath();
                @event.Invoke();
                destroyNext = true;
            }
        }
    }
}
