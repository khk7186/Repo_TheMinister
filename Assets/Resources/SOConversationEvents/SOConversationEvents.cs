using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="_CE",menuName = "ScriptableObjects/SOConversationEvents", order = 1)]

public class SOConversationEvents : ScriptableObject
{
    public GeneralEventTrigger eventTrigger;

    public void Use()
    {
        eventTrigger.TriggerEvent();
    }

}
