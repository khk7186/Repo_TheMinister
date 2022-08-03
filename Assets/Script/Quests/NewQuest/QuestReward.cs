using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestReward : MonoBehaviour
{
    public int Money;
    public int Influence;
    public int Prestige;
    public List<ItemName> Items;
    public void RewardPlayer()
    {
        var currencyInv = FindObjectOfType<CurrencyInventory>();
        currencyInv.MoneyAdd(Money);
        currencyInv.InfluenceAdd(Influence);
        currencyInv.PrestigeAdd(Prestige);
        var itemInv = FindObjectOfType<ItemInventory>();
        itemInv.AddItem(Items);
    }
}
