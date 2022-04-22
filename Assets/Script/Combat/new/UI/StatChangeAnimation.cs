using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StatChangeAnimation : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    private void Awake()
    {
        videoPlayer.playOnAwake = false;
    }
    
    public IEnumerator DestroyAfterPlay(string statName)
    {
        videoPlayer.clip = Resources.Load<VideoClip>($"Art/Îä¶·/buffÐ§¹û¶¯»­/webm files/{statName}");
        videoPlayer.Play();
        while (!videoPlayer.isPlaying)
        {
            yield return null;
        }
        while (videoPlayer.isPlaying)
        {
            yield return null;
        }
        Destroy(gameObject);
    }
}
