using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBackground : MonoBehaviour
{
    public bool TurnItOn = false;
    public bool TriggerOnEnable = false;

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
            FindObjectOfType<BackgoundMusicController>().GetComponent<AudioSource>().Stop();
        }
        else
        {
            FindObjectOfType<BackgoundMusicController>().GetComponent<AudioSource>().Play();
        }
    }
}
