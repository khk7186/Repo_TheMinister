using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public enum SceneType
{
    MainGame = 0,
    Combat = 1,
    Debate = 2
}
public class SceneTrans : MonoBehaviour
{
    public string clip = "";
    public VideoPlayer videoPlayer;
    public SceneType sceneType;
    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        DontDestroyOnLoad(gameObject);
    }
    public IEnumerator StartChange(SceneType sceneType)
    {
        this.sceneType = sceneType;
        clip = $"Video/SceneTransVideos/{sceneType}";
        videoPlayer.clip = Resources.Load<VideoClip>(clip);
        videoPlayer.Play();
        yield return WaitUntilClipEnd();
    }

    public IEnumerator EndChange()
    {
        while (SceneManager.GetActiveScene().buildIndex != (int)sceneType)
        {
            yield return null;
        }
        videoPlayer.clip = Resources.Load<VideoClip>($"{clip}_end");
        videoPlayer.Play();
        yield return WaitUntilClipEnd();
        Destroy(gameObject);
        yield return null;
    }
    public IEnumerator WaitUntilClipEnd()
    {
        while (!videoPlayer.isPlaying)
        {
            yield return null;
        }
        while (videoPlayer.isPlaying)
        {
            yield return null;
        }
    }
}
