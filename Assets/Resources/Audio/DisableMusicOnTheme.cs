using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMusicOnTheme : MonoBehaviour
{
    public AudioSource currentSource;
    private void Awake()
    {
        if (FindObjectOfType<ThemeMusicTirgger>() != null)
        {
            currentSource.gameObject.SetActive(false);
        }
    }
}
