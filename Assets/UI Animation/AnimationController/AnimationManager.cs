using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{

    public Animator transition;

    private void OnEnable()
    {
        //Debug.Log("Enable");
        Intro();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Outro();
        }
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
