using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInitialization : MonoBehaviour
{
    public static GameInitialization instance;
    public InGameCharacterStorage characterStorage;
    public int StartNPC;
    public SOAudio sOAudio;
    public bool ReloadGame = false;

    public bool InProgress = false;
    private void Awake()
    {

        var target = FindObjectOfType<SceneTransController>();
        if (target != null)
        {
            ReloadGame = true;
        }
    }

    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }
    public void OnDisable()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
    public void Start()
    {
        StartCoroutine(StartProgress());
    }

    private void InitialInGameAI(int startNPC)
    {
        if (ReloadGame == false)
        {
            if (characterStorage != null)
                characterStorage.SpawnNewCharacter(startNPC);
        }
    }
    public void ModifySettings()
    {
        var setting = FindObjectOfType<SettingsController>(true);
        setting.SetMasterVolume(sOAudio.MasterVolume);
        setting.SetMusicVolume(sOAudio.MusicVolume);
        setting.SetSFXVolume(sOAudio.SFXVolume);
    }
    public IEnumerator StartProgress()
    {
        InProgress = true;

        InitialInGameAI(StartNPC);
        yield return null;
        InProgress = false;
    }
    public IEnumerator CheckProgress()
    {
        yield return null;
        InProgress = false;
    }
}
