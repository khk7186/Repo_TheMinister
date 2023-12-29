using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliticSystemManager : MonoBehaviour, IDiceRollEvent
{
    public static PoliticSystemManager Instance;
    public int AssassinDuration = 6;
    public List<PoliticAssassinEvent> OngoingAssassinEvents = new List<PoliticAssassinEvent>();
    private void Start()
    {
        Dice.Instance.RegisterObserver(this);
    }
    public void OnNotify(object value, NotificationType notificationType)
    {
        List<PoliticAssassinEvent> toRemove = new List<PoliticAssassinEvent>();
        foreach (var item in OngoingAssassinEvents)
        {
            item.duration -= 1;
            if (item.duration <= 0)
            {
                toRemove.Add(item);
            }
        }
        foreach (PoliticAssassinEvent item in toRemove)
        {
            PoliticAssassinEvent.EndAssassin(item);
            OngoingAssassinEvents.Remove(item);
        }
    }

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
}
