using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using System.ComponentModel;

public class LoyaltyGiveUnit : MonoBehaviour
{
    public ItemUI itemUI;
    public ItemName itemName;
    public Text itemNameText;
    public int price;
    public Text priceText;
    public PoliticSlot slot;
    public Character character = null;
    public PoliticGivePage page = null;
    public void Setup(ItemName itemName, PoliticGivePage page)
    {
        this.page = page;
        this.slot = page.slot;
        this.itemName = itemName;
        SetupAmount();
        itemUI.CanClick = false;
        itemNameText.text = itemName.ToString();
        SetupPrice();
        character = slot.GateHolder;
        if (character == null)
        {
            character = slot.characterOnHold;
        }
    }
    public void GiveItem()
    {
        var itemInv = FindObjectOfType<ItemInventory>();
        if (itemInv.CheckItem(itemName) != false)
        {
            character.loyalty += price;
            if (character.loyalty > 20)
            {
                character.loyalty = 20;
            }
            ShowMessage($"{character.CharacterName}增加{price}点忠诚");
            itemInv.RemoveItem(itemName);
            page.UpdateAfterPurchase();
        }
        else
        {
            ShowMessage($"你没有{itemName}");
        }
    }
    public void ShowMessage(string messageString)
    {
        var sampleText = Resources.Load<Text>("Hiring/Message");
        var message = GameObject.Instantiate<Text>(sampleText, MainCanvas.FindMainCanvas());
        message.text = messageString;
    }

    internal void SetupPrice()
    {
        price = PoliticPurchaseItem.GovLoyaltyRecovery[itemName];
        priceText.text = $"{price}忠诚";
    }
    public void SetupAmount()
    {
        var itemInv = FindObjectOfType<ItemInventory>();
        int itemAmount = 0;
        if (itemInv.CheckItem(itemName) == true)
        {
            itemAmount = itemInv.ItemDict[itemName];
        }
        itemUI.Setup(itemName, itemAmount);
        Debug.Log(itemAmount);
    }
}
