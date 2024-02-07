using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SOPoliticFactionDatabase", menuName = "ScriptableObjects/SOPoliticFaction", order = 11)]
[Serializable]
public class SOPoliticFaction : ScriptableObject
{

    public List<PoliticFaction> politicFactions = new List<PoliticFaction>();
    public List<PoliticFaction> politicFactionsOrigin = new List<PoliticFaction>();
    public GameObject PoliticNotify = null;
    [Serializable]
    public struct PersonalDetailString
    {
        public FactionType factionType;
        public string detail;
    }
    public List<PersonalDetailString> personalDetails = new List<PersonalDetailString>();

    public void ChangeFactionValue(FactionType factionType, int friendly, int level)
    {
        var target = politicFactions.FirstOrDefault<PoliticFaction>(x => x.factionType == factionType);
        target.friendly += friendly;
        target.level += level;
        if (friendly == 0 && level == 0)
        {
            return;
        }
        else
        {
            var clone = Instantiate(PoliticNotify);
            var notify = clone.GetComponentInChildren<PoliticFriendlyNotify>();
            notify.Setup(factionType, friendly, level);
            notify.Show();
        }
    }
}
