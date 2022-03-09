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

public enum SelectType
{
    Combat,
    Debate,
    Gobang
}
public class PlayerCharactersInventory : MonoBehaviour
{
    public CharacterSlotForQuest currentSlot;
    public bool selectMode => currentSlot;
    public List<CharacterUI> characterUIList = new List<CharacterUI>();
    public Transform Storage;

    public Dictionary<SelectType, List<Character>> SelectCharacters =
        new Dictionary<SelectType, List<Character>>()
        {
            {SelectType.Combat,new List<Character>()},
            {SelectType.Debate,new List<Character>()},
            {SelectType.Gobang,new List<Character>()}
        };

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
            if (character.OnCombatDuty || character.OnDebateDuty || character.OnGobangDuty)
            {
                character.characterCardInvUI = OndutySlot;
                if (character.OnCombatDuty) SelectCharacters[SelectType.Combat].Add(character);
                else if (character.OnDebateDuty) SelectCharacters[SelectType.Debate].Add(character);
                else if (character.OnGobangDuty) SelectCharacters[SelectType.Gobang].Add(character);
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
