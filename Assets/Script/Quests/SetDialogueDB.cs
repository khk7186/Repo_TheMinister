using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDialogueDB : MonoBehaviour
{
    [SerializeField]
    public DialogueDatabase DialogueDatabase = null;
    private void OnEnable()
    {
        if (DialogueDatabase == null)
        {
            Debug.LogError("DialogueDatabase is null");
            return;
        }
        var DSC = FindObjectOfType<DialogueSystemController>();
        DSC.initialDatabase = DialogueDatabase;
        DSC.Awake();
    }
}
