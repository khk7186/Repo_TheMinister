using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveReadyChanger : MonoBehaviour
{
    public bool changeStatInto = false;
    public bool changeOnEnable = true;

    public void OnEnable()
    {
        if (changeOnEnable)
        {
            SetSaveReadyStat();
        }
    }
    public void SetSaveReadyStat()
    {
        GameEventManager.Instance.SaveReady = changeStatInto;
    }
}
