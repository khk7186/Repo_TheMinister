using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;
using UnityEngine.UI;

public class PawnshopUI : MonoBehaviour
{
    public Transform content;
    public PawnShopItemUI itemTemp;
    public Dictionary<ItemName, int> SellDict;
    public Text Money;
    private void OnEnable()
    {
        Setup();
    }
    public void Setup()
    {
        TransformEx.Clear(content);
        var playerInv = FindObjectOfType<ItemInventory>().ItemDict;
        SellDict = new Dictionary<ItemName, int>();
        foreach (var item in playerInv)
        {
            var current = Instantiate(itemTemp, content);
            SellDict.Add(item.Key, 0);
            current.pawnshopUI = this;
            current.SetupPawnItem(item.Key, item.Value);
            current.gameObject.SetActive(true);
        }
        UpdatePrice();
    }
    public void UpdatePrice()
    {
        int price = 0;
        foreach (var item in SellDict)
        {
            Rarerity rarity = Player.AllTagRareDict[Use(item.Key)];
            price += SOItem.PawnshopPrice[SOItem.FindType(item.Key)][RarityInOrder(rarity)] * item.Value;
        }
        Money.text = price.ToString();
    }
    public void Pawn()
    {
        var playerInv = FindObjectOfType<ItemInventory>();
        foreach (var item in SellDict)
        {
            for (int i = 0; i < item.Value; i++)
            {
                playerInv.RemoveItem(item.Key);
            }
        }
        CurrencyInvAnimationManager.Instance.MoneyChange(int.Parse(Money.text));
        Setup();
    }

    public Tag Use(ItemName ItemName)
    {
        Tag output = Tag.Null;
        if (SOItem.ItemMap.ContainsKey(ItemName))
        {
            output = SOItem.ItemMap[ItemName];
            return output;
        }
        else
        {
            Debug.LogError(ItemName);
            return output;
        }
    }
    private int RarityInOrder(Rarerity rarerity)
    {
        switch (rarerity)
        {
            case Rarerity.B:
                return 0;
            case Rarerity.N:
                return 1;
            case Rarerity.R:
                return 2;
            case Rarerity.SR:
                return 3;
            case Rarerity.SSR:
                return 4;
            case Rarerity.UR:
                return 5;
        }
        return -1;
    }
}
