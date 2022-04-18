using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightClickToClose : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            RightClickEvent();
        }
    }
    public void RightClickEvent()
    {
        //var combatSceneController = FindObjectOfType<CombatSceneController>();
        //if (combatSceneController != null)
        //{
        //    FindObjectOfType<CombatSceneController>().OnAction = false;
        //}
        var iib = FindObjectOfType<ItemInvBackgroundAnimation>();
        if (iib != null)
        {
            iib.FrontDown(false);
        }
        if (!TryGetComponent<InvIntroAnimation>(out var IIA))
        {
            Destroy(gameObject);
        }
        else { IIA.Outro(); }

    }
}
