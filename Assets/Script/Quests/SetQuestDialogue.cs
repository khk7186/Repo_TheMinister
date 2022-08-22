using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
public class SetQuestDialogue : MonoBehaviour
{
    private void OnEnable()
    {
        var DSC = FindObjectOfType<DialogueSystemController>();
        DSC.initialDatabase = Resources.Load<DialogueDatabase>($"Conversions/хннЯ");
        DSC.Awake();
        Debug.Log("SetQuestDialogue");
    }
}
