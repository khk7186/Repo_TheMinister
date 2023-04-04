using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using PixelCrushers.DialogueSystem;

public class StartQuest : MonoBehaviour
{
    public GameObject QuestObject;
    public string VariableName;

    public void OnEnable()
    {
        if (VariableName != null)
        {
            bool start = DialogueLua.GetVariable(VariableName).asBool;
            if (start)
            {
                QuestObject.gameObject.SetActive(true);
            }
        }
    }
}
