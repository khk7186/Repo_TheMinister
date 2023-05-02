using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    public bool ChangeOnEnable = false;
    public Animator Animator;
    public string TriggerString;

    private void OnEnable()
    {
        if (ChangeOnEnable)
        {
            Trigger();
        }
    }
    private void Trigger()
    {
        Animator.SetBool(TriggerString, true);
    }
}
