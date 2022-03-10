using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum OndutyType
{
    Combat,
    Debate,
    Gobang
}

public static class SelectOnDuty
{
    public static Dictionary<OndutyType, int> OndutyLimit =
        new Dictionary<OndutyType, int>()
        {
            { OndutyType.Combat, 3},
            { OndutyType.Debate, 2},
            { OndutyType.Gobang, 1}
        };
    public static void TrySelectOnDuty(Character character, OndutyType ondutyType)
    {
        bool CheckResult = GetOndutyAll(ondutyType).Count < SelectOnDuty.OndutyLimit[ondutyType];
        if (CheckResult == true)
        {
            character.OnDutyState[ondutyType] = true;
            Debug.Log(1);
        }
        else
        {
            Debug.Log(2);
            SwitchCurrentOndutyImage(character,ondutyType);
        }
    }
    public static List<Character> GetOndutyAll(OndutyType ondutyType)
    {
        Transform PlayerCharacterInventory = FindInventory();
        List<Character> characterList = PlayerCharacterInventory.GetComponentsInChildren<Character>().ToList();
        List<Character> targetList = new List<Character>();
        foreach (Character character in characterList)
        {
            if (character.OnDutyState[ondutyType] == true)
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

    private static void SwitchCurrentOndutyImage(Character character, OndutyType ondutyType)
    {
        string prefPath = ("CharacterInvUI/OndutySwitchUI").Replace(" ", string.Empty);
        var pref = Resources.Load<CharacterOndutySwitchUI>(prefPath);
        var target = GameObject.Instantiate<CharacterOndutySwitchUI>(pref, MainCanvas.FindMainCanvas());
        target.Setup(character, ondutyType);
    }
}
