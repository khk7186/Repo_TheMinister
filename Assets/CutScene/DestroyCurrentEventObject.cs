using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class DestroyCurrentEventObject : MonoBehaviour
{
    GameEventManager gameEventManager => GameEventManager.Instance;
    public MainEventUnitProfile nextEvent;
    public int delayDays = 5;

    private void OnEnable()
    {
        StartCoroutine(StartAfterQuest());
    }
    public IEnumerator StartAfterQuest()
    {
        yield return new WaitForSeconds(1f);
        NormalizeGame();
    }
    public void NormalizeGame()
    {
        gameEventManager.nextEvent = nextEvent;

        if (Map.Instance != null)
        {
            Dice.Instance.RegisterObserver(Map.Instance);
            Map.Instance.Player.gameObject.GetComponent<Animator>().enabled = false;
        }
        gameEventManager.DestroyCurrent();
        Destroy(gameEventManager.currentEvent.gameObject);
    }
}
