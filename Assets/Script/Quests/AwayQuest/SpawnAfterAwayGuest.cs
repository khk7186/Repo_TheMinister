using SaveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAfterAwayGuest : MonoBehaviour
{
    public string guestName = string.Empty;
    public void Start()
    {
        FindObjectOfType<SaveAndLoadManager>().gameGuests.Add(this);
    }
    public void OnDestroy()
    {
        FindObjectOfType<SaveAndLoadManager>().gameGuests.Remove(this);
    }
    public void OnDisable()
    {
        FindObjectOfType<SaveAndLoadManager>().gameGuests.Remove(this);
    }
}
