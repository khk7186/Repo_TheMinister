using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceTrigger : MonoBehaviour
{
    public KeyCode key;
    public GameObject targetUI;
    public void Update()
    {
        if (Input.GetKeyDown(key))
        {
            targetUI.SetActive(!targetUI.activeSelf);
        }
    }
}
