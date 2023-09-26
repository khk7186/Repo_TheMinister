using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[CreateAssetMenu(fileName = "MainGameEventDatabase", menuName = "ScriptableObjects/MainGameEventDatabase", order = 8)]
[Serializable]
public class SOMainGameEventDatabase : ScriptableObject
{
    public List<MainEventUnitProfile> gameEventProfils = new List<MainEventUnitProfile>();

    public void Find(string Name)
    {
        gameEventProfils.First(x => x.profileName == Name);
    }
}
