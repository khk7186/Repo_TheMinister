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
    public UnityEvent questActive;
    public void HandInAction()
    {
        Enum.TryParse(itemName, out item);
        ItemInventory inventory = FindObjectOfType<ItemInventory>();
        var carryItem = inventory.CheckItem(item);
        if (carryItem)
        {
            inventory.RemoveItem(item);
            questActive.Invoke();
        }
        else
        {
            DialogueLua.SetVariable("noItem", "true");
        }
    }
}
