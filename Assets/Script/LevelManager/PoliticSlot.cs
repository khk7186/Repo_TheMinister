using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoliticSlot : MonoBehaviour,ICharacterSelect
{
    public Image CharacterHead = null;
    public Character characterOnHold = null;
    public int exp;
    public List<Tag> requestTags;
    public List<PoliticSlot> preSlots = new List<PoliticSlot>();

    public void ChooseCharacter(Character character)
    {
        characterOnHold = character;
    }

    public void CloseInventory()
    {
        
    }

    public void CloseInventory(CharacterUI current)
    {
        
    }

    public void PutCharacterOn(Character character)
    {
        characterOnHold = character;
    }

    public void SetupSlotIcon()
    {
        
    }
}
