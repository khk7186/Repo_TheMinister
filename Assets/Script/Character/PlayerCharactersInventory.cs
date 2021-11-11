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
                    GetComponent<RightClickToClose>().RightClickEvent();
                    break;
                case false:
                    break;
            }
            gameObject.SetActive(false);
        }
    }

    public void RightClickSelectMode()
    {
        GetComponent<RightClickToClose>().RightClickEvent();
    }
    private void Start()
    {  
    }





}
