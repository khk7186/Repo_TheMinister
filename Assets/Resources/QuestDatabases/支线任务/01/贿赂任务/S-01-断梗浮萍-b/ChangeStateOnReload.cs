using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.QuestMachine;

public class ChangeStateOnReload : MonoBehaviour
{
    public string questID = string.Empty;
    public List<GameObject> defaultObjects = null;
    public List<GameObject> triggeredObjects = null;
    public bool switchOnEnable = false;

    public void OnEnable()
    {
        if (switchOnEnable && questID != string.Empty)
        {
            SwitchState();
        }
    }

    public bool CheckIfCollected()
    {
        var journal = FindObjectOfType<QuestJournal>();
        var quest = journal.FindQuest(questID);
        if (quest == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void SwitchState()
    {
        var result = CheckIfCollected();
        Debug.Log(result);
        if (result == true)
        {
            foreach (var target in defaultObjects)
            {
                if (target != null)
                    target.SetActive(false);
            }
            foreach (var target in triggeredObjects)
            {
                if (target != null)
                    target.SetActive(true);
            }
        }
        else
        {
            foreach (var target in defaultObjects)
            {
                if (target != null)
                    target.SetActive(true);
            }
            foreach (var target in triggeredObjects)
            {
                if (target != null)
                    target.SetActive(false);
            }
        }

    }
}
