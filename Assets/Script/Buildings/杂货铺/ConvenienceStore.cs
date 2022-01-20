using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvenienceStore : MonoBehaviour, IShopUI
{
    public ItemType spawnType;
    public ItemUI itemPref;

    public void Setup(List<ItemName> shopList)
    {
        foreach (ItemName i in shopList)
        {
            var target = Instantiate(itemPref, transform);
            target.SetUp(i, 1);
        }
        //Debug.Log(shopList.Count);
    }

}
