using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    public bool TagListCheck = false;

    private void Start()
    {
        if (TagListCheck)
        {
            TagListDebugger();
        }
    }

    private void TagListDebugger()
    {
        foreach (Tag tag in (Tag[])Enum.GetValues(typeof(Tag)))
        {
            if (!Player.TagInfDict.ContainsKey(tag))
            {
                Debug.Log(tag + " is not in TagInfDict");
            }
        }
    }
}
