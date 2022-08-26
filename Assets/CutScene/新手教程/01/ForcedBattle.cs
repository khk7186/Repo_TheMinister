using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcedBattle : MonoBehaviour
{
    public GeneralEventTrigger generalEventTrigger;
    public List<GameObject> InactiveGameobjs;
    public List<GameObject> ActiveGameobjs;
    private void Start()
    {
        foreach (var item in InactiveGameobjs)
        {
            item.SetActive(false);
        }
        foreach (var item in ActiveGameobjs)
        {
            item.SetActive(true);
        }
        generalEventTrigger.TriggerEvent();
    }
}
