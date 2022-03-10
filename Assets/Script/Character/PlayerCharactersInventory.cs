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
    OnCombatSwitchMode,
    OnDebateSwitchMode,
    OnGobangSwitchMode,
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
        Setup();
    }

    public void Setup()
    {
        List<Character> OndutyCards = new List<Character>();
        foreach (Character character in GameObject.FindGameObjectWithTag("PlayerCharacterInventory").GetComponentsInChildren<Character>())
        {
            if (character.OnDutyState[OndutyType.Combat] || character.OnDutyState[OndutyType.Debate] || character.OnDutyState[OndutyType.Gobang])
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

        LayoutRebuilder.ForceRebuildLayoutImmediate(OndutySlot.GetComponent<RectTransform>());
        LayoutRebuilder.ForceRebuildLayoutImmediate(Storage.GetComponent<RectTransform>());
    }

    public void Reset()
    {
        TransformEx.Clear(OndutySlot);
        TransformEx.Clear(Storage);
        Setup();
    }
    public void SetupMode(CardMode mode)
    {
        foreach (CharacterUI character in characterUIList)
        {
            character.cardMode = mode;
        }
    }
}
