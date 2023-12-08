using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using System;
using PixelCrushers.QuestMachine;
using UnityEngine.Events;
using PixelCrushers.DialogueSystem;

public class ItemRequstAction : MonoBehaviour
{
    public string itemName;
    private ItemName item;
    public int requestCount = 1;
    public UnityEvent questActive;
    public DialogueSystemTrigger haveItem;
    public DialogueSystemTrigger noItem;
    public void HandInAction()
    {
        Enum.TryParse(itemName, out item);
        ItemInventory inventory = FindObjectOfType<ItemInventory>();
        bool carryItem = inventory.CheckItem(item);
        bool enoughItem = inventory.ItemDict[item] >= requestCount;
        if (carryItem && enoughItem)
        {
            inventory.RemoveItem(item);
            questActive.Invoke();
            haveItem.OnUse();
        }
        else
        {
            noItem.OnUse();
        }
    }
}
