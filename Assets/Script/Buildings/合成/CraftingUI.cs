using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingUI : MonoBehaviour
{
    public Transform CraftingListTransform;
    public Transform CurrentCraftItemTransform;
    public Transform CraftingMaterialTransform;
    [SerializeField]private CraftingMenuUI CraftingMenuPref;

    public void SetUp(List<ItemName> CraftingList)
    {
        foreach (ItemName item in CraftingList)
        {
            var target = Instantiate(CraftingMenuPref, CraftingListTransform);
            target.parentUI = this;
            target.SetUp(item);
        }
    }

    public void SetUp(ItemName item)
    {
        var target_a = CurrentCraftItemTransform.GetComponent<CraftingTargetUI>();
        target_a.SetUp(item);

        TransformEx.Clear(CraftingMaterialTransform);
        var target_b = CraftingMaterialTransform.GetComponent<CraftingMaterialListUI>();
        var targetList = SOItem.MergeItemDict[item];
        target_b.SetUp(targetList);
    }

    public void SetUp()
    {
        
    }
}
