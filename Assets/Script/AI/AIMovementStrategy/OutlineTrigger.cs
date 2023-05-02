using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OutlineTrigger : MonoBehaviour
{
    public CharacterModelController controller;
    public UnityEvent @event;

    private void OnMouseEnter()
    {
        controller.DrawOutline();
    }
    private void OnMouseExit()
    {
        controller.UndrawOutline();
    }
}
