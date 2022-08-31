using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShowMain_OnEnd : MonoBehaviour
{
    public HideAndShowMainUI hide;

    void Awake()
    {
        hide.ShowMain();
    }
}
