using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterOndutySwitchUI : MonoBehaviour
{
    public List<Character> CurrentOndutyList;
    public Transform ChooseCharacterSlot;
    public Transform TargetSlot;

    public void Setup(Character character, OndutyType ondutyType)
    {
        CurrentOndutyList = SelectOnDuty.GetOndutyAll(ondutyType);
        CardMode cardMode = CardMode.OnCombatSwitchMode;
        if (ondutyType == OndutyType.Debate) cardMode = CardMode.OnDebateSwitchMode;
        else if (ondutyType == OndutyType.Gobang) cardMode = CardMode.OnGobangSwitchMode;
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
            targetUI.cardMode = cardMode;
            targetUI.PannelTopTransform = transform;
            targetUI.TargetCharacter = character;
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(ChooseCharacterSlot.GetComponent<RectTransform>());
        LayoutRebuilder.ForceRebuildLayoutImmediate(TargetSlot.GetComponent<RectTransform>());
    }
    //private void Choose(Charact)
}
