using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RobbingTriggerGroup : MonoBehaviour
{
    public DialogueSystemTrigger beforeRobbing;
    public DialogueSystemTrigger afterRobbing;

    public UnityEvent robbingEvent = new UnityEvent();
    public RobbedUI robbedUI;
    public static int robbingAmount = -200;

    public void Rob()
    {
        robbingEvent?.Invoke();
        var ui = Instantiate(robbedUI);
        ui.Set(robbingAmount);
    }
}
