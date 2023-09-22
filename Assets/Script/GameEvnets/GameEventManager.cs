using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public static GameEventManager Instance;
    public bool SaveReady = true;
    public GameObject nextEvent;
    public GameObject currentEvent;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    public bool CheckForSave()
    {
        return SaveReady;
    }
    public void Reset()
    {
        DestroyCurrent();
    }
    private void Start()
    {
        currentEvent = Instantiate(nextEvent, transform);
    }
    public void DestroyCurrent()
    {
        Destroy(currentEvent.gameObject);
    }
}
