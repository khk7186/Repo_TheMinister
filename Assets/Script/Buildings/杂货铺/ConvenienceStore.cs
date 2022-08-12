using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvenienceStore : MonoBehaviour, IShopUI
{
    public ItemType spawnType;
    public List<ItemUI> itemUIs = new List<ItemUI>();
    BuildingType buildingType;
    public void Setup(List<ItemName> shopList)
    {
        int UIindex = 0;
        foreach (ItemName i in shopList)
        {
            itemUIs[UIindex].gameObject.SetActive(enabled);
            var shopUI = GetComponent<ShopItemUI>();
            ItemType itemType = SOItem.FindType(i);
            Rarerity rarerity = Player.AllTagRareDict[SOItem.ItemMap[i]];
            int price = SOItem.ItempriceTag[buildingType][itemType][(int)rarerity / 2 - 1];
            shopUI.SetupShopItem(i, 1);
            UIindex++;
        }
    }


}
