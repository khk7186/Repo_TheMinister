using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNoTouchMask : MonoBehaviour
{
    public bool Open = false;

    public void OnEnable()
    {
        FindObjectOfType<NoTouchMask>().gameObject.SetActive(Open);
    }
}
