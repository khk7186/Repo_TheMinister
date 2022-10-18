using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OndutySelectButton : MonoBehaviour
{
    public OndutyType ondutyType = OndutyType.Combat;
    public bool OnSelect = false;
    Character character;
    public void Setup(Character character)
    {
        this.character = character;
        OnSelect = character.OnDutyState[ondutyType];
        if (OnSelect)
        {
            GetComponent<Image>().color = new Color(255, 255, 255);
        }
        else
        {
            GetComponent<Image>().color = new Color(0, 0, 0);
        }
    }
    public void Setup()
    {
        if (character != null)
        {
            Setup(character);
        }
    }
    public void OnClick()
    {
        if (!OnSelect)
        {
            switch (ondutyType)
            {
                case OndutyType.Combat:
                    if (character.CharactersValueDict[CharacterValueType.武] > 0 && character.CharactersValueDict[CharacterValueType.守] > 0)
                    {
                        SelectOnDuty.TrySelectOnDuty(character, ondutyType);
                        Setup();
                    }
                    else
                    {
                        var alert = Instantiate<Text>(Resources.Load<Text>("Hiring/Message"), MainCanvas.FindMainCanvas());
                        alert.text = "成为武侍需要武和守同时大于0";
                    }
                    break;
                case OndutyType.Debate:
                    if (character.CharactersValueDict[CharacterValueType.智] > 0 || character.CharactersValueDict[CharacterValueType.才] > 0|| character.CharactersValueDict[CharacterValueType.谋] > 0)
                    {
                        SelectOnDuty.TrySelectOnDuty(character, ondutyType);
                        Setup();
                    }
                    else
                    {
                        var alert = Instantiate<Text>(Resources.Load<Text>("Hiring/Message"), MainCanvas.FindMainCanvas());
                        alert.text = "成为文客需要智才谋至少一个大于0";
                    }
                    break;
                case OndutyType.Gobang:
                    SelectOnDuty.TrySelectOnDuty(character, ondutyType);
                    Setup();
                    break;
            }
        }
        else
        {
            character.OnDutyState[ondutyType] = false;
            Setup();
        }
    }
}
