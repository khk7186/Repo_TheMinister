using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterAwaitTributeManager : MonoBehaviour, IDiceRollEvent
{
    public static CharacterAwaitTributeManager Instance;
    public List<CharacterAwaitTribute> UnfinishedTributes = new List<CharacterAwaitTribute>();
    public CharacterAwaitTribute awaitTributePrefab;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            awaitTributePrefab.gameObject.SetActive(false);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        Dice.Instance.RegisterObserver(this);
    }
    public CharacterAwaitTribute AddTribute(Character character, int WaitTime, UnityEvent @event)
    {
        var tribute = Instantiate(awaitTributePrefab, transform);
        tribute.gameObject.SetActive(true);
        tribute.character = character;
        tribute.WaitTime = WaitTime;
        tribute.@event.AddListener(@event.Invoke);
        UnfinishedTributes.Add(tribute);
        return tribute;
    }
    public void OnNotify(object value, NotificationType notificationType)
    {
        List<GameObject> toDestroy = new List<GameObject>();
        foreach (var tribute in UnfinishedTributes)
        {
            if (tribute != null)
                tribute.TimePlus();
            if (tribute.destroyNext)
            {
                Debug.Log(tribute.gameObject == null);
                toDestroy.Add(tribute.gameObject);
            }
        }
        if (toDestroy.Count > 0) { StartCoroutine(DestroyAfterSec(toDestroy)); }
    }
    IEnumerator DestroyAfterSec(List<GameObject> toDestroy)
    {
        yield return new WaitForSeconds(1);
        foreach (var tribute in toDestroy) Destroy(tribute.gameObject);
        UnfinishedTributes.RemoveAll(x => x == null);
    }
    public void Reset()
    {
        foreach (var tribute in UnfinishedTributes)
        {
            Destroy(tribute.gameObject);
        }
        UnfinishedTributes = new List<CharacterAwaitTribute>();
    }
}
