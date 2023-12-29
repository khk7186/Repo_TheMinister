using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PoliticSlotInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public PoliticSlot politicSlot;
    public PoliticPopup politicPopup;
    private void OnEnable()
    {
        politicPopup.gameObject.SetActive(false);
        SetFrame();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {

        }
        else if (eventData.button == PointerEventData.InputButton.Left)
        {
            OpenSelectMenu();
        }
    }

    private void OpenSelectMenu()
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        politicSlot.Frame.sprite = politicSlot.HighlightFrame;
        //politicPopup.Setup(politicSlot);
        politicPopup.ShowPopup();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetFrame();
        politicPopup.HidePopup();
    }
    public void SetFrame()
    {
        politicSlot.Frame.sprite = politicSlot.GateHolder != null ? politicSlot.NonPlayerFrame : politicSlot.PlayerFrame;
    }

    private void Awake()
    {
        politicSlot = GetComponent<PoliticSlot>();
    }
}
