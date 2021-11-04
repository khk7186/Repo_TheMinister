using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemName
{
    Null
}

public enum ItemType
{
    Null
}
public class Item : MonoBehaviour, IIcon
{
    public ItemName ItemName;
    public SOItem sOItem;
    private Image icon;

    public Image Icon => icon;

    public void Awake()
    {

    }

    public Tag Use()
    {
        return sOItem.ItemMap[ItemName];
    }

    public Sprite GetSprite(ItemName itemName)
    {
        switch (itemName) {
            default:
            //for each new item, set its sprite here
            case ItemName.Null:
                return sOItem.NullSprite;
        }

    }
}
