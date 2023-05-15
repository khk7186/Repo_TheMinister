using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class NPCConversationTriggerGroup : MonoBehaviour
{
    public DialogueSystemTrigger[] dialogueSystemTriggers;
    public DialogueSystemTrigger General;

    public void Setup(string DBID)
    {
        foreach (DialogueSystemTrigger dst in dialogueSystemTriggers)
        {
            dst.selectedDatabase = Resources.Load<DialogueDatabase>($"Conversions/{DBID}");
        }
    }
    public void StartGeneral()
    {
        var EAC = GetComponent<EventAfterConversation>();
        EAC.ChangeConversation();
        General.OnUse();
    }

    public void OnConversationEnd(Transform actor)
    {
        var EAC = GetComponent<EventAfterConversation>();
        EAC.ChangeConversation();
        EAC.TryCombat();
        EAC.TryDebate();
        EAC.TryHire();
    }
}
