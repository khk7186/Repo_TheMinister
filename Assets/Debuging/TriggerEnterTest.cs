using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnterTest : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TriggerEnterTest.OnTriggerEnter2D");
    }
}
