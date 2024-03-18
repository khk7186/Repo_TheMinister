using Spine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PoliticSlotInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public PoliticSlot politicSlot;
    public PoliticPopup politicPopup;
    public bool DisableAllInteractions = false;
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
            var interactable = InteractableCheck();
            if (interactable)
            {
                OpenSelectMenu();
            }
        }
    }
    public bool InteractableCheck()
    {
        if (politicSlot.NotInteractable) return false;
        foreach (var preSlot in politicSlot.preSlots)
        {
            if (preSlot.unlocked == false) return false;
        }
        return true;
    }
    private void OpenSelectMenu()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PoliticSlotPopDescription.Show(politicSlot);
        if (DisableAllInteractions)
        {
            return;
        }
        var interactable = InteractableCheck();
        if (interactable == false)
        {
            politicPopup.ShowAssassinOnly();
            return;
        }
        politicPopup.Setup(politicSlot);
        politicSlot.Frame.sprite = politicSlot.HighlightFrame;

        politicPopup.ShowPopup();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        var interactable = InteractableCheck();
        PoliticSlotPopDescription.Hide();

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
    private void Start()
    {
        politicPopup.Setup(politicSlot);
    }
}
