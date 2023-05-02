using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitialization : MonoBehaviour
{
    public static GameInitialization instance;
    public InGameCharacterStorage characterStorage;
    public int StartNPC;

    public bool InProgress = false;

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
        if (characterStorage != null)
            characterStorage.SpawnNewCharacter(startNPC);
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
