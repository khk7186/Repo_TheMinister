using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerCharactersInventory : MonoBehaviour, IPointerClickHandler
{
    public CharacterSlotForQuest currentSlot;

    public bool selectMode => currentSlot;
    public List<CharacterUI> characterUIList = new List<CharacterUI>();

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            switch (selectMode)
            {
                case true:
                    RightClickSelectMode();
                    break;
                case false:
                    break;
            }
            gameObject.SetActive(false);
        }
    }

    public void RightClickSelectMode()
    {
        currentSlot.UndisableField();
        var allCharacters = GetComponentsInChildren<CharacterUI>();
        foreach (CharacterUI c in allCharacters) c.CurrentSlot = null;
    }
    private void Start()
    {  
        gameObject.SetActive(false);
    }





}
