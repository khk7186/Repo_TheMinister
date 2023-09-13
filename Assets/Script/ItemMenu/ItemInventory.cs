using System;
using System.Linq;
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
        ////foreach (ItemName item in Enum.GetValues(typeof(ItemName)))
        ////{
        ////    if (item == ItemName.Null)
        ////        continue;
        ////    AddItem(item);
        ////    AddItem(item);
        ////    AddItem(item);
        ////    AddItem(item);
        ////    AddItem(item);
        ////}
        //for (int i = 0; i < 1; i++)
        //{
        //    AddItem(ItemName.Îä¹Ù×´);
        //}

        ////    AddItem(item);
        ////    AddItem(item);
        ////    AddItem(item);
        ////    AddItem(item);
    }
    public void Reset()
    {
        itemDict = new Dictionary<ItemName, int>();
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
    public bool CheckItem(ItemName item)
    {
        if (ItemDict.ContainsKey(item))
        {
            if (ItemDict[item] > 0)
            {
                return true;
            }
        }
        return false;
    }
    public void RemoveItem(ItemName item)
    {
        if (itemDict.ContainsKey(item))
        {
            itemDict[item] -= 1;
            if (itemDict[item] <= 0)
            {
                itemDict.Remove(item);
            }
        }
        else Debug.LogError("RemoveNullItemError");
    }
    public void RemoveItem()
    {
        itemDict[InUseItem] -= 1;
        if (itemDict[InUseItem] <= 0)
        {
            itemDict.Remove(InUseItem);
        }
    }
}
