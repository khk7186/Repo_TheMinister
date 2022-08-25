using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapOff : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<Map>().gameObject.SetActive(false);
    }
}
