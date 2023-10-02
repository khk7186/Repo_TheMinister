using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using PixelCrushers.QuestMachine;

public class StartConversationAfterCloseQuestJurnal : MonoBehaviour
{
    public DialogueSystemTrigger dialogueSystemTrigger;
    private IEnumerator Start()
    {
        var target = FindObjectOfType<UnityUIQuestJournalUI>(true).gameObject;
        Debug.Log("Inactive");
        yield return new WaitUntil(() => target.activeSelf == false);
        Debug.Log("active");
        dialogueSystemTrigger.OnUse();
    }
}
