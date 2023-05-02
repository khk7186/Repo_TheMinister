using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToHire : MonoBehaviour
{
    bool active = false;
    public CharacterHiringEvent characterHiringEvent;
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
            if (characterHiringEvent != null)
                characterHiringEvent.StartHiring();
        }
    }
}
