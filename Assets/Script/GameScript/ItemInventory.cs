using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventory : MonoBehaviour
{
    private Dictionary<ItemName, int> itemDict = new Dictionary<ItemName, int>();
    public Dictionary<ItemName, int> ItemDict => itemDict;

    private void Awake()
    {
        AddItem(ItemName.É½º£¾­);
        AddItem(ItemName.±ùËª±¦½£);
        AddItem(ItemName.ÒõÑô°ËØÔÅÌ);
        AddItem(ItemName.»ú¹Ø²Ð¾í);
    }

    //add item into dic, if dont have one, add new key, else add count.
    public void AddItem(ItemName item)
    {
        if (itemDict.ContainsKey(item))
        {
            itemDict[item] += 1;
        }
        else itemDict.Add(item, 1);
    }

    public void RemoveItem(ItemName item)
    {
        itemDict[item] -= 1;
        if (itemDict[item] <=0)
        {
            itemDict.Remove(item);
        }
    }
}
