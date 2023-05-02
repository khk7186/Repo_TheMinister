using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCurrentEventObject : MonoBehaviour
{
    GameEventManager gameEventManager => GameEventManager.Instance;
    public GameObject nextEvent;
    public int delayDays = 5;

    private void OnEnable()
    {
        NormalizeGame();
    }
    public void NormalizeGame()
    {
        if (nextEvent != null)
        {
            gameEventManager.nextEvent = nextEvent;
        }
        if (Map.Instance != null)
        {
            Dice.Instance.RegisterObserver(Map.Instance);
            Map.Instance.Player.gameObject.GetComponent<Animator>().enabled = false;
        }
        
        gameEventManager.DestroyCurrent();
    }
}
