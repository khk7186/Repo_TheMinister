using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour, IDiceRollEvent
{
    public static GameEventManager Instance;
    public bool SaveReady = true;
    public MainEventUnitProfile nextEvent;
    public MainEventUnitProfile currentEvent;
    public bool readyForNext = false;
    public int ActiveNextEventAfterDaysOf
    {
        get => timeRemain;
        set
        {
            timeRemain = value;
        }
    }
    public bool isTime => timeRemain == 0;
    public int timeRemain = 0;
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
        Dice.Instance.RegisterObserver(this);
    }
    public void DestroyCurrent()
    {
        Destroy(currentEvent.gameObject);
    }
    public void ActiveNext(MainEventUnitProfile nextEvent = null)
    {
        if (nextEvent != null) this.nextEvent = nextEvent;
        if (this.nextEvent != null)
        {
            StartCoroutine(ActiveNextRator());
        }
    }
    public IEnumerator ActiveNextRator()
    {
        readyForNext = true;
        yield return new WaitUntil(() => isTime == true);
        currentEvent = Instantiate(nextEvent, transform);
        readyForNext = false;
    }

    public void OnNotify(object value, NotificationType notificationType)
    {
        if (readyForNext)
        {
            timeRemain -= 1;
        }
    }
}
