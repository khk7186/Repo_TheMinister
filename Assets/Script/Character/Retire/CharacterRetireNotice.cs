using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterRetireNotice : CharacterReciveNotice, IPointerClickHandler
{
    public Animator animator;
    public bool RemoveCharacterAfter = true;
    public override void Setup(Character character)
    {
        base.Setup(character);
        if (RemoveCharacterAfter)
            destroyEvents.AddListener(() => Destroy(character.gameObject));
    }
    public void Show()
    {
        animator.Play("Show");
    }
    public void Hide()
    {
        animator.Play("Hide");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Hide();
        }
    }
}
