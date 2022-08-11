using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public enum SceneType
{
    MainGame = 1,
    Combat = 2,
    Debate = 3
}
public class SceneTrans : MonoBehaviour
{
    public string clip = "";
    public VideoPlayer videoPlayer;
    public SceneType sceneType;
    bool sceneLoaded => (SceneManager.GetActiveScene().buildIndex == (int)sceneType);
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
        //while (!sceneLoaded)
        //{
        //    yield return null;
        //}
        videoPlayer.clip = Resources.Load<VideoClip>($"{clip}_end");
        Debug.Log(sceneLoaded);
        videoPlayer.Play();
        yield return new WaitUntil(() => videoPlayer.isPlaying == false);
        Debug.Log(videoPlayer.isPlaying);
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
