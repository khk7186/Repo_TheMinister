using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SaveSystem
{
    public class SerializedInventory
    {
        public static ItemInString SerializingItem(ItemName itemName, int amount)
        {
            var output = new ItemInString();
            output.itemName = itemName.ToString();
            output.amount = amount;
            return output;
        }
        public static ItemName DeserializingItem(ItemInString item)
        {
            return (ItemName)Enum.Parse(typeof(ItemName), item.itemName);
        }
    }
}