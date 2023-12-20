using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeMusicTirgger : MonoBehaviour
{
    public AudioClip audioClip = null;
    public bool TriggerOn = true;
    public bool SetOnEnable = false;


    public void Trigger()
    {
        var controller = FindObjectOfType<BackgoundMusicController>();
        if (controller == null) { Debug.LogError("BackgoundMusicController not fund on function"); return; }
        if (TriggerOn)
        {
            SetMusic();
        }
        else
        {

        }
    }
    public void SetMusic()
    {
        var controller = FindObjectOfType<BackgoundMusicController>();
        if (controller == null) Debug.LogError("BackgoundMusicController not fund on function");
        else
        {
            if (audioClip == null)
            {
                Debug.LogError("No audioClip binded");
                return;
            }
            controller.audioSource.clip = audioClip;
            controller.audioSource.Play();
        }
    }
    public void SetBack()
    {
        var controller = FindObjectOfType<BackgoundMusicController>();
        if (controller == null) Debug.LogError("BackgoundMusicController not fund on function");
        controller.OnEnable();
    }
}
