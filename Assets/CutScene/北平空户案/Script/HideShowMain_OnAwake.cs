using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShowMain_OnAwake : MonoBehaviour
{

    public HideAndShowMainUI hide;

    void Awake()
    {
        hide.HideMain();
    }


}
