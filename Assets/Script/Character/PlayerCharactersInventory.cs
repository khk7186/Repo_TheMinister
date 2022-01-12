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
    OndutySwitchMode
}
public class PlayerCharactersInventory : MonoBehaviour
{
    public CharacterSlotForQuest currentSlot;
    public bool selectMode => currentSlot;
    public List<CharacterUI> characterUIList = new List<CharacterUI>();
    public Transform Storage;

    public Transform OndutySlot;
    public void RightClickSelectMode()
    {
        GetComponent<RightClickToClose>().RightClickEvent();
    }
    private void Awake()
    {
        List<Character> OndutyCards = new List<Character>();
        foreach (Character character in GameObject.FindGameObjectWithTag("PlayerCharacterInventory").GetComponentsInChildren<Character>())
        {
            if (character.OnDuty)
            {
                character.characterCardInvUI = OndutySlot;
            }
            else
            {
                character.characterCardInvUI = Storage;
            }
            character.BelongCheck();
        }
        characterUIList = Storage.GetComponentsInChildren<CharacterUI>().ToList();
        characterUIList.AddRange(OndutySlot.GetComponentsInChildren<CharacterUI>().ToList());
    }
    public void SetupMode(CardMode mode)
    {
        foreach (CharacterUI character in characterUIList)
        {
            character.cardMode = mode;
        }
    }





}
