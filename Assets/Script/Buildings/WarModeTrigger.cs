using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarModeTrigger : MonoBehaviour
{
    public bool SetOnEnable = false;
    public void OnEnable()
    {
        if (SetOnEnable)
        {
            SetWar();
        }
    }
    public void SetWar()
    {
        RoitManager.Instance.SetWar();
    }
}
