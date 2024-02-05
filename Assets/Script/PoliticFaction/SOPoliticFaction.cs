using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SOPoliticFactionDatabase", menuName = "ScriptableObjects/SOPoliticFaction", order = 11)]
[Serializable]
public class SOPoliticFaction : ScriptableObject
{
    public List<PoliticFaction> politicFactions = new List<PoliticFaction>();
    public List<PoliticFaction> politicFactionsOrigin = new List<PoliticFaction>();
    [Serializable]
    public struct PersonalDetailString
    {
        public FactionType factionType;
        public string detail;
    }
    public List<PersonalDetailString> personalDetails = new List<PersonalDetailString>();
}
