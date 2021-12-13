using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;

public enum CardMode
{
    ViewMode,
    QuestSelectMode,
    ItemSelectMode,
    UpgradeSelectMode,
}
public class PlayerCharactersInventory : MonoBehaviour, IPointerClickHandler
{
    public CharacterSlotForQuest currentSlot;

    public bool selectMode => currentSlot;
    public List<CharacterUI> characterUIList = new List<CharacterUI>();
    public Transform characterUIParent;

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
    private void Awake()
    {
        foreach (Character character in GameObject.FindGameObjectWithTag("PlayerCharacterInventory").GetComponentsInChildren<Character>())
        {
            character.characterCardInvUI = transform.GetComponentInChildren<Transform>().GetComponentInChildren<GridLayoutGroup>().transform;
            character.BelongCheck();
        }
        characterUIList = characterUIParent.GetComponentsInChildren<CharacterUI>().ToList();
    }
    public void SetupMode(CardMode mode)
    {
        foreach (CharacterUI character in characterUIList)
        {
            character.cardMode = mode;
        }

    }





}
