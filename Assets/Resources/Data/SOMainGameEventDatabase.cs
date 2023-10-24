using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[CreateAssetMenu(fileName = "MainGameEventDatabase", menuName = "ScriptableObjects/MainGameEventDatabase", order = 8)]
[Serializable]
public class SOMainGameEventDatabase : ScriptableObject
{
    public List<MainEventUnitProfile> gameEventProfils = new List<MainEventUnitProfile>();

    public MainEventUnitProfile Find(string Name)
    {
        return gameEventProfils.First(x => x.profileName == Name);
    }
}
