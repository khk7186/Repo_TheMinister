using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvenienceStore : MonoBehaviour, IShopUI
{
    public ItemType spawnType;
    public List<ShopItemUI> itemUIs = new List<ShopItemUI>();
    public BuildingType buildingType;
    public void Setup(List<ItemName> shopList)
    {
        foreach (ItemUI i in itemUIs)
        {
            i.gameObject.SetActive(false);
        }
        int UIindex = 0;
        foreach (ItemName i in shopList)
        {
            if (i == ItemName.Null) continue;
            itemUIs[UIindex].gameObject.SetActive(enabled);
            var shopUI = itemUIs[UIindex].GetComponent<ShopItemUI>();
            ItemType itemType = SOItem.FindType(i);
            Rarerity rarerity = Player.AllTagRareDict[SOItem.ItemMap[i]];
            //Debug.Log($"buildingType£º{buildingType}\n itemType:{itemType}");
            var priceList = SOItem.ItempriceTag[buildingType][itemType];
            int price = priceList[rarerity >= Rarerity.N ? (int)rarerity / 2 - 1 : 0];
            shopUI.SetupShopItem(i, price);
            UIindex++;
        }
    }
}
