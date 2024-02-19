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

    public bool EndWait => AlreadyWait >= WaitTime;

    public void TimePlus()
    {
        AlreadyWait += 1;
        if (EndWait)
        {
            //if (@event != null)
            //{
            //    @event.Invoke();
            //}
            if (character != null)
            {
                character?.StartCoroutine(character.TryLeavePlayer());
                character?.NotifyReturn();
                if (character.OnAssassinEvent == true)
                {
                    string message = StepMessage.AssassinCompleteStepMessage();
                    var targetEvent = PoliticSystemManager.FindEventByAssassin(character);
                    targetEvent.GetResult();
                    if (targetEvent.result == false) message = StepMessage.AssassinFailStepMessage();
                    GeneralTrackingViewManager.Instance.PushTracker(character, character.AssasinTarget, message, 0, false);
                }
                else
                {

                }
                destroyNext = true;
            }
        }
        else
        {
            if (character.OnAssassinEvent == true)
            {
                GeneralTrackingViewManager.Instance.PushTracker(character, character.AssasinTarget, StepMessage.AssassinStepMessage(), WaitTime - AlreadyWait, false);
            }
            else
            {
                GeneralTrackingViewManager.Instance.PushTracker(character, character.CharacterName, "∂Ã–≈œµÕ≥", WaitTime - AlreadyWait, false);
            }
        }
    }
}
