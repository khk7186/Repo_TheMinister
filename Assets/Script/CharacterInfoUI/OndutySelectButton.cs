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
        if (character!= null)
        {
            Setup(character);
        }
    }
    public void OnClick()
    {
        if (!OnSelect)
        {
            SelectOnDuty.TrySelectOnDuty(character, ondutyType);
            Setup();
        }
        else
        {
            character.OnDutyState[ondutyType] = false;
            Setup();
        }
    }
}
