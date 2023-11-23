using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeQuestCollectedDialogue : MonoBehaviour
{
    public QuestGiverAI questGiver;
    public DialogueSystemTrigger dialogueTarget;

    public void ChangeDialogue()
    {
        questGiver._dialogueTriggerCollected = dialogueTarget;
    }
}
