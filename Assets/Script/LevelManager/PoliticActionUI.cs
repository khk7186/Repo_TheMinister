using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PoliticActionUI : MonoBehaviour,IPointerClickHandler
{
    public Animator animator;
    public GateHolderAnimationPlayer animPlayer;
    public void Show()
    {
        AudioManager.Play("·­Ò³");
        animator.Play("Show");
    }
    public void Hide()
    {
        AudioManager.Play("·­Ò³");
        animator.Play("Hide");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Hide();
        }
    }
    public IEnumerator AssassinSuccess()
    {
        Show();
        yield return new WaitForSeconds(0.4f);
        animPlayer.StartSequence();
    }
    public void StartAssassinSuccessAnimation()
    {
        StartCoroutine(AssassinSuccess());
    }
}
