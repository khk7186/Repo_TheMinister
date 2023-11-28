using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ForcedBattle : MonoBehaviour
{
    public GeneralEventTrigger generalEventTrigger;
    public List<GameObject> InactiveGameobjs;
    public List<GameObject> ActiveGameobjs;
    public UnityEvent EventIfNoDuty = new UnityEvent();
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
        var ready = AbleToCombat.CheckingForDuty(generalEventTrigger.battleType);
        if (ready)
            generalEventTrigger.TriggerEvent();
        else
        {
            EventIfNoDuty.Invoke();
        }
    }
}
