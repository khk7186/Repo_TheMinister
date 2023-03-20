using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ReciveItem : MonoBehaviour
{
    public ItemName item;
    public string itemName;
    public bool ReciveOnEnable;

    private void OnEnable()
    {
        if (ReciveOnEnable)
        {
            Recive();
        }
    }
    public void  Recive()
    {
        Enum.TryParse(itemName, out ItemName item);
        FindObjectOfType<ItemInventory>().AddItem(item);
    }
}
