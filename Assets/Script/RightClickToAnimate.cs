using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightClickToAnimate : MonoBehaviour, IPointerClickHandler
{
    public Animator Animator;
    public string RightClickStateName = "Hide";
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            RightClickEvent();
        }
    }
    public void RightClickEvent()
    {
        Animator.Play(RightClickStateName);
    }
    public void Show()
    {
        Animator.Play("Show");
    }
}
