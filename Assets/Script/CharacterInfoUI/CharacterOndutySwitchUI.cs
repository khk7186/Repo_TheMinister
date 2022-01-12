using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterOndutySwitchUI : MonoBehaviour
{
    public List<Character> CurrentOndutyList;
    public Transform ChooseCharacterSlot;
    public Transform TargetSlot;

    private void Awake()
    {
        Setup(null);
    }
    private void Setup(Character character)
    {
        CurrentOndutyList = SelectOnDuty.GetOndutyAll();
        if (character!= null)
        {
            character.characterCardInvUI = TargetSlot;
            character.BelongCheck();
            character.thisCharacterCard.PannelTopTransform = transform;
        }
        foreach (Character ch in CurrentOndutyList)
        {
            ch.characterCardInvUI = ChooseCharacterSlot;
            ch.BelongCheck();
            var targetUI = ch.thisCharacterCard;
            targetUI.cardMode = CardMode.OndutySwitchMode;
            targetUI.PannelTopTransform = transform;
            targetUI.TargetCharacter = character;
        }
    }
    //private void Choose(Charact)
}
