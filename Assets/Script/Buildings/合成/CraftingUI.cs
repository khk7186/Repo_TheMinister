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

    private List<ItemName> CraftingList;
    private ItemName CurrentItem;

    public void Setup(List<ItemName> CraftingList)
    {
        this.CraftingList = CraftingList;
        foreach (ItemName item in CraftingList)
        {
            var target = Instantiate(CraftingMenuPref, CraftingListTransform);
            target.parentUI = this;
            target.SetUp(item);
        }
    }

    public void Setup(ItemName item)
    {
        CurrentItem = item;
        var target_a = CurrentCraftItemTransform.GetComponent<CraftingTargetUI>();
        target_a.SetUp(item);
        TransformEx.Clear(CraftingMaterialTransform);
        var target_b = CraftingMaterialTransform.GetComponent<CraftingMaterialListUI>();
        var targetList = SOItem.MergeItemDict[item];
        target_b.SetUp(targetList);
    }

    public void TryCraft()
    {
        bool craftble = true;
        foreach (MaterialUI material in CraftingMaterialTransform.GetComponentsInChildren<MaterialUI>())
        {
            if (material.IntHaveAmount >= material.IntNeedAmount) craftble = false;
        }
        if (craftble)
        {
            string currentText = "确认制造"+CurrentItem.ToString() + "吗？";
            Confirmation.HoldingMethod holding = Craft;
            StartCoroutine(Confirmation.CreateNewComfirmation(holding, currentText).Confirm());
        }
    }

    public void Craft()
    {
        var PlayerItemDic =
                GameObject
                .FindGameObjectWithTag("PlayerItemInventory")
                .GetComponent<ItemInventory>();
        PlayerItemDic.AddItem(CurrentItem);
        var CurrentCraftMaterialList = SOItem.MergeItemDict[CurrentItem];
        foreach (ItemName item in CurrentCraftMaterialList)
        {
            PlayerItemDic.RemoveItem(item);
        }
    }
}
