using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class UnlockSlot : MonoBehaviour
{
    public PoliticSlot slot;
    public string slotID;
    public PoliticSlotInteraction politicSlotInteraction;

    public void OnEnable()
    {
        unlockSlots(slotID) ;
    }

    public void unlockSlots(string slotID)
    {
        var slots = FindObjectsOfType<PoliticSlot>(true);
        var target = slots.FirstOrDefault(x => x.slotID == slotID);
        if (target!= null)
        target.GetComponent<PoliticSlotInteraction>().DisableAllInteractions = false;
    }
}
