using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingTargetUI : MonoBehaviour
{
    public Image itemIcon;
    public Text Name;

    public void SetUp(ItemName item)
    {
        string path = ("Art/ItemIcon/" + item.ToString()).Replace(" ", string.Empty);
        itemIcon.sprite = Resources.Load<Sprite>(path);
        Name.text = item.ToString();
    }
}
