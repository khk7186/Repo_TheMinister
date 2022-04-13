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
        AddItem(ItemName.山海经);
        AddItem(ItemName.冰霜宝剑);
        AddItem(ItemName.阴阳八卦盘);
        AddItem(ItemName.机关残卷);
        AddItem(ItemName.三味酒);
        AddItem(ItemName.三七);
        AddItem(ItemName.丝绸);
        AddItem(ItemName.红宝石);
        AddItem(ItemName.九阳真经);
        AddItem(ItemName.五香粉);
        AddItem(ItemName.人参);
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
        if (itemDict[InUseItem] <=0)
        {
            itemDict.Remove(InUseItem);
        }
    }
}
