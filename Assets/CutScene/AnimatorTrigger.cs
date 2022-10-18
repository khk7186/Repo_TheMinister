using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTrigger : MonoBehaviour
{
    public bool TriggerOnEnable = false;
    public Animator animator;
    public string triggerName;
    public void OnEnable()
    {
        if (TriggerOnEnable)
        {
            Trigger();
        }
    }
    public void Trigger()
    {
        animator.SetTrigger(triggerName);
        
    }
}
