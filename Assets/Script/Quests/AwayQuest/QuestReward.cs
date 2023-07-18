using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestReward : MonoBehaviour
{
    public int Money;
    public int PressureReduce;
    public List<ItemName> Items;
    public void RewardPlayer()
    {
        var currencyInv = FindObjectOfType<CurrencyInventory>();
        currencyInv.MoneyAdd(Money);
        PressureEventHandler.OnPressureChange(-PressureReduce);
        var itemInv = FindObjectOfType<ItemInventory>();
        //ReciveItemNotify
        itemInv.AddItem(Items);
    }
}
