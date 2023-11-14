using Language.Lua;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnAfterAwayDB", menuName = "AwayQuest/SpawnAfterAwayDB", order = 0)]
public class SOSpawnAfterAwayDB : ScriptableObject
{
    public List<SpawnAfterAwayGuest> guests = new List<SpawnAfterAwayGuest>();

    public SpawnAfterAwayGuest Find(string guestName)
    {
        var guest = guests.FirstOrDefault(x => x.guestName == guestName);
        if (guest == null)
        {

            Debug.LogError("SpawnAfterAway not reg in database.");
            return null;
        }
        else return guest;
    }
}
