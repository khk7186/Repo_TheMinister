using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOAudio", menuName = "ScriptableObjects/SOAudio", order = 2)]
public class SOAudio : ScriptableObject
{
    [System.Serializable]
    public struct AuidioAndName
    {
        public string name;
        public AudioClip audioClip;
    }
    public float MasterVolume = 0.8f;
    public float MusicVolume = 0.8f;
    public float SFXVolume = 0.8f;

    public int resolutionIndex = 0;

    public List<AuidioAndName> audioAndNames = new List<AuidioAndName>();
    public AudioClip GetAudio(string name)
    {
        foreach (var item in audioAndNames)
        {
            if (item.name == name)
            {
                return item.audioClip;
            }
        }
        return null;
    }
}
