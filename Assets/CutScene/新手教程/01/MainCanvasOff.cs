using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvasOff : MonoBehaviour
{
    private void Start()
    {
        GameObject.FindGameObjectWithTag("MainUICanvas")?.SetActive(false);
    }
}
