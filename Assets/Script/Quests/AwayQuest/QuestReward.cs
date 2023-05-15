using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestReward : MonoBehaviour
{
    public int Money;
    public List<ItemName> Items;
    public void RewardPlayer()
    {
        var currencyInv = FindObjectOfType<CurrencyInventory>();
        currencyInv.MoneyAdd(Money);

        var itemInv = FindObjectOfType<ItemInventory>();
        //ReciveItemNotify
        itemInv.AddItem(Items);
    }
}
