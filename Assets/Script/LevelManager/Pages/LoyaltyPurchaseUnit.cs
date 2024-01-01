using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoyaltyPurchaseUnit : MonoBehaviour
{
    public ItemUI itemUI;
    public ItemName itemName;
    public Text itemNameText;
    public int price;
    public Text priceText;
    public CurrencyInventory currencyInv;
    public void Setup(ItemName itemName)
    {

    }
    public void Purchase()
    {
        currencyInv.MoneySpend(price);
    }
}
