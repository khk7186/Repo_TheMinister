using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public bool TriggerOnEnable = false;
    public string AudioName;
    public bool Loop;
    private void OnEnable()
    {
        if (TriggerOnEnable)
        {
            AudioManager.Play(AudioName, Loop);
        }
    }
    public void PlayAudio()
    {
        AudioManager.Play(AudioName, Loop);
    }
}
