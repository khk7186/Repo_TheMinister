using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OndutyCheck : MonoBehaviour
{
    public OndutyType battleType = OndutyType.Combat;
    public GameObject readyEvent;
    public UnityEvent notReadyEvent;
    
    void OnEnable()
    {
        bool ready = SelectOnDuty.GetOndutyAll(battleType).Count > 0;
        if(ready)
        {
            readyEvent.gameObject.SetActive(true);
        }
        else
        {
            notReadyEvent.Invoke();
        }
    }

    // Update is called once per frame

}
