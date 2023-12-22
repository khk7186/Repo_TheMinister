using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBackground : MonoBehaviour
{
    public bool TurnItOn = false;
    public bool TriggerOnEnable = false;
    public bool ResumeOnDestroy = false;

    private void OnEnable()
    {
        if (TriggerOnEnable)
        {
            Turn();
        }
    }
    public void Turn()
    {
        if (!TurnItOn)
        {
            FindObjectOfType<BackgroundMusicController>().GetComponent<AudioSource>().Stop();
        }
        else
        {
            FindObjectOfType<BackgroundMusicController>().GetComponent<AudioSource>().Play();
        }
    }
    private void OnDestroy()
    {
        if (ResumeOnDestroy)
        {
            FindObjectOfType<BackgroundMusicController>().GetComponent<AudioSource>().Play();
        }
    }
}
