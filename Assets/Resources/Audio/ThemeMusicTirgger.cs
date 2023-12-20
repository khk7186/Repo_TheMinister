using PixelCrushers.QuestMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ThemeMusicTirgger : MonoBehaviour
{
    public AudioClip audioClip = null;
    public bool SetOnEnable = false;
    public string style = string.Empty;
    public AudioMixerGroup mixerGroup;
    public AudioSource audioSourceA = null;
    public AudioSource audioSourceB = null;
    public AudioSource currentPlaying = null;

    public void OnEnable()
    {
        audioSourceA.outputAudioMixerGroup = mixerGroup;
        audioSourceB.outputAudioMixerGroup = mixerGroup;
        if (SetOnEnable)
        {
            Trigger();
        }
    }
    public void Trigger()
    {
        var controller = FindObjectOfType<BackgoundMusicController>();
        if (controller == null) { Debug.LogError("BackgoundMusicController not fund on function"); return; }

        if (style == "Sad")
        {
            SadLoop();
        }
        else
            SetMusic();

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
        //TODO: waitUntil music stop playing
        controller.OnEnable();
        Destroy(gameObject);
    }
    public void SadLoop()
    {
        var AudioDB = AudioManager.instance.soAudio;
        audioSourceA.clip = AudioDB.GetAudio("SadA");
        audioSourceB.clip = AudioDB.GetAudio("SadB");
        var controller = FindObjectOfType<BackgoundMusicController>();
        if (controller == null) Debug.LogError("BackgoundMusicController not fund on function");
        controller.audioSource.Stop();
        StartCoroutine(SadRoutine());
    }
    public IEnumerator SadRoutine()
    {
        float endTime = audioSourceA.clip.length - 4f;
        currentPlaying = audioSourceA;
        audioSourceA.loop = false;
        audioSourceA.Play();
        while (endTime > 0)
        {
            endTime -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        endTime = audioSourceB.clip.length - 4f;
        audioSourceB.loop = false;
        audioSourceA.clip = audioSourceB.clip;
        while (true)
        {
            if (currentPlaying == audioSourceA) currentPlaying = audioSourceB;
            else if (currentPlaying == audioSourceB) currentPlaying = audioSourceA;
            currentPlaying.Play();
            endTime = audioSourceA.clip.length - 4f;
            while (endTime > 0)
            {
                endTime -= Time.deltaTime;
                yield return new WaitForFixedUpdate();
            }
            yield return new WaitForFixedUpdate();
        }
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
