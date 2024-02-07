using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliticChangeTrigger : MonoBehaviour
{
    public int Friendly;
    public int Level;
    public FactionType factionType;
    public void OnEnable()
    {
        PoliticSystemManager.Instance.SOPoliticFaction.ChangeFactionValue(factionType, Friendly, Level);
    }

 
}
