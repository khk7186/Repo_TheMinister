using System;
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
    public PoliticSlot slot;
    public Character character = null;
    public PoliticRequestPage page = null;
    public void Setup(ItemName itemName, PoliticRequestPage page)
    {
        this.page = page;
        this.slot = page.slot;
        itemUI.Setup(itemName);
        itemUI.CanClick = false;
        this.itemName = itemName;
        itemNameText.text = itemName.ToString();
        SetupPrice();
        character = slot.GateHolder;
        if (character == null)
        {
            character = slot.characterOnHold;
        }
    }
    public void Purchase()
    {

        if (character.loyalty < price)
        {
            ShowMessage("角色忠诚度不足");
            return;
        }
        character.loyalty -= price;
        slot.requestAmount += 1;
        ShowMessage($"获得 {itemNameText.text}*1");
        page.UpdateAfterPurchase();
    }
    public void ShowMessage(string messageString)
    {
        var sampleText = Resources.Load<Text>("Hiring/Message");
        var message = GameObject.Instantiate<Text>(sampleText, MainCanvas.FindMainCanvas());
        message.text = messageString;
    }

    internal void SetupPrice()
    {
        price = PoliticPurchaseItem.LoyaltyShopPrice[itemName] + slot.requestAmount;
        priceText.text = price.ToString();
    }
}
