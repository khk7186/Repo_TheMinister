using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingMaterialListUI : MonoBehaviour
{
    [SerializeField] private MaterialUI material;
    public void SetUp(List<ItemName> items)
    {
        foreach (ItemName i in items)
        {
            var target = Instantiate(material, transform);
            var PlayerItemDic = GameObject.FindGameObjectWithTag("PlayerItemInventory").GetComponent<ItemInventory>().ItemDict;

            int HaveAmount = 0;
            if (PlayerItemDic.ContainsKey(i))
            {
                HaveAmount = PlayerItemDic[i];
            }

            target.SetUp(i, HaveAmount);
        }
    }
}
