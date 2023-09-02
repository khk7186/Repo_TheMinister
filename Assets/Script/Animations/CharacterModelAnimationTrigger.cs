using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModelAnimationTrigger : MonoBehaviour
{
    public bool triggerOnEnable = false;
    public CharacterModelController characterModelController;
    public string triggerName = string.Empty;

    public void OnEnable()
    {
        if (triggerOnEnable)
        {
            TriggerAnimation();
        }
    }
    public void TriggerAnimation()
    {
        characterModelController?.SetTrigger(triggerName);
    }
}