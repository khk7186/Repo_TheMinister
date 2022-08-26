using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToHire : MonoBehaviour
{
    bool active = false;
    private void OnEnable()
    {
        active = true;
    }
    private void OnDisable()
    {
        active = false;
    }
    private void OnMouseDown()
    {
        if (active)
        {
            Debug.Log("ClickToHire");
            GetComponent<CharacterHiringEvent>().StartHiring();
        }
    }
}
