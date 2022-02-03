using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvenienceStore : MonoBehaviour, IShopUI
{
    public ItemType spawnType;
    public ItemUI itemPref;

    public List<ItemUI> itemUIs = new List<ItemUI>();
    public void Setup(List<ItemName> shopList)
    {
        int UIindex = 0;
        foreach (ItemName i in shopList)
        {
            itemUIs[UIindex].gameObject.SetActive(enabled);
            itemUIs[UIindex].SetUp(i, 1);
            UIindex++;
        }
        //Debug.Log(shopList.Count);
    }

}
