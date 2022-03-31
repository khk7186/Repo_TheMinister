using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventory : MonoBehaviour
{
    private static Dictionary<ItemName, int> itemDict = new Dictionary<ItemName, int>();
    public Dictionary<ItemName, int> ItemDict => itemDict;
    public ItemName InUseItem;

    private void Awake()
    {
        AddItem(ItemName.É½º£¾­);
        AddItem(ItemName.±ùËª±¦½£);
        AddItem(ItemName.ÒõÑô°ËØÔÅÌ);
        AddItem(ItemName.»ú¹Ø²Ð¾í);
    }
    public void AddItem(ItemName item)
    //add item into dic, if dont have one, add new key, else add count.
    {
        if (itemDict.ContainsKey(item))
        {
            itemDict[item] += 1;
        }
        else itemDict.Add(item, 1);
    }
    public void AddItem(List<ItemName> items)
    {
        foreach (ItemName itemName in items)
        {
            AddItem(itemName);
        }
    }

    public void RemoveItem(ItemName item)
    {
        if (itemDict.ContainsKey(item))
        {
            itemDict[item] -= 1;
        }
        else Debug.LogError("RemoveNullItemError");
    }
    public void RemoveItem()
    {
        itemDict[InUseItem] -= 1;
        if (itemDict[InUseItem] <=0)
        {
            itemDict.Remove(InUseItem);
        }
    }
}
