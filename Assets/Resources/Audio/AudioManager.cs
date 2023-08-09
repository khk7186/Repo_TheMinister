using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public SOAudio soAudio;
    public AudioMixerGroup mixerGroup;
    public AudioSource[] CurrentPlay => transform.GetComponentsInChildren<AudioSource>();

    private void Awake()
    {
        instance = this;
    }
    private AudioSource SpawnAudioSource(AudioClip clip, bool loop = false)
    {
        var audioSource = new GameObject().AddComponent<AudioSource>();
        audioSource.transform.parent = this.transform;
        audioSource.playOnAwake = false;
        audioSource.clip = clip;
        audioSource.loop = loop;
        audioSource.outputAudioMixerGroup = mixerGroup;
        audioSource.Play();
        if (loop == false)
        {
            StartCoroutine(DestroyAfterPlay(audioSource));
        }
        return audioSource;
    }
    private IEnumerator DestroyAfterPlay(AudioSource audioSource)
    {
        yield return new WaitUntil(() => !audioSource.isPlaying);
        Destroy(audioSource.gameObject);
    }
    public static void Play(string Name, bool loop = false)
    {
        instance.PlayAudio(Name, loop);
    }
    public static void Stop(string Name)
    {
        instance.StopAudio(Name);
    }
    public void PlayAudio(string Name, bool loop = false)
    {
        AudioClip clip = soAudio.GetAudio(Name);
        SpawnAudioSource(clip, loop).name = Name;
    }
    public void StopAudio(string Name)
    {
        var target = CurrentPlay.First(x => x.name == Name);
        target.Stop();
        Destroy(target.gameObject);
    }

}
