using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PawnShopItemUI : ItemUI
{
    ItemName item;
    public GameObject sellAmountGO;
    public Text sellAmount;
    public PawnshopUI pawnshopUI;
    public Text Price;
    protected override void LeftClickAction()
    {
        return;
    }
    public override void SetupInUseItem()
    {
        return;
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            sellAmountGO.SetActive(true);
            if (int.Parse(sellAmount.text) < int.Parse(amount.text))
            {
                sellAmount.text = (int.Parse(sellAmount.text) + 1).ToString();
            }
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (int.Parse(sellAmount.text) > 0)
            {
                int current = (int.Parse(sellAmount.text) - 1);
                sellAmount.text = current.ToString();
                if (current <= 0 )
                {
                    sellAmountGO.SetActive(false);
                }
            }
        }
        pawnshopUI.SellDict[item] = int.Parse(amount.text);
    }
    public void SetupPawnItem(ItemName itemName, int amount)
    {
        Setup(itemName, amount);
        sellAmountGO.SetActive(false);
        item = itemName;
    }
}
