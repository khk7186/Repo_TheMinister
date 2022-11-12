using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingTargetUI : MonoBehaviour
{
    public Image itemIcon;
    public Image itemFrame;

    public void SetUp(ItemName item)
    {
        string path = ("Art/ItemIcon/" + item.ToString()).Replace(" ", string.Empty);
        itemIcon.sprite = Resources.Load<Sprite>(path);
        string FramePath = $"Art/BuildingUI/杂货铺/初级五金铺/物品框/物品框-{Player.AllTagRareDict[SOItem.ItemMap[item]]}";
        itemFrame.sprite = Resources.Load<Sprite>(FramePath);
    }
}
