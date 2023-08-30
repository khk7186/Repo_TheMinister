using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModelAnimationTrigger : MonoBehaviour
{
    public bool triggerOnEnable = false;
    public CharacterModelController characterModelController;
    public string animationName = string.Empty;

    public void OnEnable()
    {
        if (triggerOnEnable)
        {
            PlayAnimation();
        }
    }
    public void PlayAnimation()
    {
        characterModelController?.PlayAnimation(animationName);
    }
}