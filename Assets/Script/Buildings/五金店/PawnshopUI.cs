using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PawnshopUI : MonoBehaviour
{
    public Transform content;
    public PawnShopItemUI itemTemp;
    public Dictionary<ItemName, int> SellDict;
    public Text Money;
    private void Awake()
    {
        itemTemp.gameObject.SetActive(false);

    }
    private void Start()
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
            ItemType itemType = SOItem.FindType(item.Key);
            Rarerity Rarity = Player.AllTagRareDict[SOItem.ItemMap[item.Key]] != Rarerity.B
                ? Player.AllTagRareDict[SOItem.ItemMap[item.Key]] : Rarerity.N;
            price += item.Value * SOItem.PawnshopPrice[itemType][(int)Rarity / 2 - 1];
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
        Setup();
    }
}
