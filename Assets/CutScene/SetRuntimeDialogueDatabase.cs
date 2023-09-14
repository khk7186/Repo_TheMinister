using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRuntimeDialogueDatabase : MonoBehaviour
{
    [SerializeField]
    public bool SetOnEnable = true;
    public PixelCrushers.DialogueSystem.DialogueDatabase dialogueDatabase = null;
    private void OnEnable()
    {
        if (SetOnEnable)
        {
            CorrectConversationBasedOnQuest();
        }
    }
    public void CorrectConversationBasedOnQuest()
    {
        var DSC = FindObjectOfType<DialogueSystemController>();
        DSC.initialDatabase = dialogueDatabase;
        DSC.Awake();
    }
}
