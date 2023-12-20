using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeMusicTirgger : MonoBehaviour
{
    public AudioSource audioSource;
    public bool SetOnEnable = false;
    public void SetMusic()
    {
        var controller = FindObjectOfType<BackgoundMusicController>();
        if (controller == null) Debug.LogError("BackgoundMusicController not fund on function");

    }
}
