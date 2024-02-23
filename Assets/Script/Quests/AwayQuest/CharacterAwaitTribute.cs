using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Events;

public class CharacterAwaitTribute : MonoBehaviour
{
    public Character character;
    public string QuestID = "";
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
                else if (character.awayMessage == "recovery")
                {
                    GeneralTrackingViewManager.Instance.PushTracker(character, character.CharacterName, "destroy", 0, true);
                }
                else
                {
                    if (@event != null)
                    {
                        @event.Invoke();
                    }
                    //else
                    //{
                    //    GeneralTrackingViewManager.Instance.PushTracker(character, character.CharacterName, "destroy", 0, true);
                    //}
                    GeneralTrackingViewManager.Instance.PushTracker(character, character.CharacterName, StepMessage.AppointMessage(QuestID, WaitTime - AlreadyWait), 0, false);
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
                GeneralTrackingViewManager.Instance.PushTracker(character, character.CharacterName, StepMessage.AppointMessage(QuestID, WaitTime - AlreadyWait), WaitTime - AlreadyWait, false);
            }
        }
    }
}
