using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class SelectOnDuty
{
    public static void TrySelectOnDuty(Character character)
    {
        bool CheckResult = GetOndutyAll().Count < 6;
        if (CheckResult == true)
        {
            character.OnDuty = true;
        }
        else
        {
            SwitchCurrentOnduty();
        }
    }
    public static List<Character> GetOndutyAll()
    {
        Transform PlayerCharacterInventory = FindInventory();
        List<Character> characterList = PlayerCharacterInventory.GetComponentsInChildren<Character>().ToList();
        List<Character> targetList = new List<Character>();
        foreach (Character character in characterList)
        {
            if (character.OnDuty == true)
            {
                targetList.Add(character);
            }
        }
        return targetList;
    }
    private static Transform FindInventory()
    {
        return UnityEngine.GameObject.FindGameObjectWithTag("PlayerCharacterInventory").transform;
    }

    private static void SwitchCurrentOnduty()
    {
        Resources.Load<CharacterOndutySwitchUI>("");
    }
}
