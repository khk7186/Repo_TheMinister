using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    //cc Ð¡³Â
    public Animator transition;

    private void OnEnable()
    {
        Intro();
    }

    public void Intro()
    {
        transition.SetTrigger("Open");
    }

    public void Outro()
    {
        transition.SetTrigger("Close");
    }


}
