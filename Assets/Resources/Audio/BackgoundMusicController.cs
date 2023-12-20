using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgoundMusicController : MonoBehaviour
{
    public AudioSource audioSource;
    public List<string> soundTrackNames = new List<string>()
    {
            "SoundTrack_01",
            "SoundTrack_01",
            "SoundTrack_02",
            "SoundTrack_03"
    };
    public AudioManager audioManager;
    public int chapter => ChapterCounter.Instance.Chapter;
    public void OnEnable()
    {
        StartCoroutine(WaitForChapterLoaded());
    }
    private static void SwitchAudio()
    {
        FindObjectOfType<BackgoundMusicController>().SwitchAudioEvent();
    }
    public static void StopBackgroundMusic()
    {
        FindObjectOfType<BackgoundMusicController>().audioSource.Stop();
    }
    private void SwitchAudioEvent()
    {
        audioManager = FindObjectOfType<AudioManager>();
        audioSource.clip = audioManager.soAudio.GetAudio(soundTrackNames[chapter]);
        audioSource.Play();
    }

    public IEnumerator WaitForChapterLoaded()
    {
        yield return new WaitUntil(() => ChapterCounter.Instance != null);
        SwitchAudioEvent();
    }
}
