using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator transition;

    private void OnEnable()
    {
        Intro();
    }
    public void Intro()
    {
        if (transition != null)
        {
            transition.SetTrigger("Open");
        }
        //transition.enabled = true;
        //StartCoroutine(TurnOff());
    }
    public IEnumerator TurnOff()
    {
        System.Func<bool> finish = () => transition.GetCurrentAnimatorStateInfo(0).normalizedTime < 1 && !transition.IsInTransition(0);
        yield return new WaitUntil(finish);
        transition.enabled = false;
    }
    public void Outro()
    {
        //transition.enabled = true;
        if (transition != null)
            transition.SetTrigger("Close");
        //else
        //{
        //    gameObject.SetActive(false);
        //}
    }
}
