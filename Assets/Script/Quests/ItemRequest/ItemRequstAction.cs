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
        bool enoughItem = carryItem ? inventory.ItemDict[item] >= requestCount : false;
        var DSC = FindObjectOfType<DialogueSystemController>();
        DSC.initialDatabase = haveItem.selectedDatabase;
        DSC.Awake();
        if (carryItem && enoughItem)
        {
            inventory.RemoveItem(item);
            questActive.Invoke();
            haveItem.OnUse();
            HideJournal();
        }
        else
        {
            noItem.OnUse();
            HideJournal();
        }
    }

    public void HideJournal()
    {
        var journalUI = FindObjectOfType<UnityUIQuestJournalUI>();
            if (journalUI != null)
        {
            journalUI.Hide();
        }
    }
}
