using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliticCharacterSelect : MonoBehaviour,ICharacterSelect
{
    public static Character SelectedCharacter = null;

    public void ChooseCharacter(Character character)
    {
        SelectedCharacter = character;
    }

    public void CloseInventory()
    {
        throw new System.NotImplementedException();
    }

    public void CloseInventory(CharacterUI current)
    {
        throw new System.NotImplementedException();
    }

    public void SetupSlotIcon()
    {
        throw new System.NotImplementedException();
    }
}
