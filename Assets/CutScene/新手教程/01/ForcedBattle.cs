using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcedBattle : MonoBehaviour
{
    public GeneralEventTrigger generalEventTrigger;
    public List<GameObject> InactiveGameobjs;
    private void Start()
    {
        foreach (var item in InactiveGameobjs)
        {
            item.SetActive(false);
        }
        generalEventTrigger.TriggerEvent();
    }
}
