using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public static GameEventManager Instance;
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
    private void Start()
    {
        currentEvent = Instantiate(nextEvent, transform);
    }
    public void DestroyCurrent()
    {
        Destroy(currentEvent.gameObject);
    }
}
