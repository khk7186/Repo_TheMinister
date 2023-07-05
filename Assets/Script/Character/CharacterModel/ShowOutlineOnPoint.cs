using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowOutlineOnPoint : MonoBehaviour
{
    public CharacterModelController controller;
    private void Start()
    {
        if (controller == null)
        {
            controller = GetComponent<CharacterModelController>();
        }
    }
    public void OnMouseEnter()
    {
        controller.DrawOutline();
    }
    public void OnMouseExit()
    {
        controller.UndrawOutline();
    }
}
