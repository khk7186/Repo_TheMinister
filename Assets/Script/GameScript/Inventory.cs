using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<ItemName, int> itemDict = new Dictionary<ItemName, int>();
    private List<Character> characterList = new List<Character>();
    public Dictionary<ItemName, int> ItemDict => itemDict;
    public List<Character> CharacterList => characterList;

    private void Awake()
    {
        AddItem(ItemName.Null);
    }

    //add item into dic, if dont have one, add new key, else add count.
    private void AddItem(ItemName item)
    {
        if (itemDict.ContainsKey(item))
        {
            itemDict[item] += 1;
        }
        else itemDict.Add(item, 1);
    }

    private void AddCharacter(Character character)
    {
        characterList.Add(character);
    }


}
