using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ReciveItemNotify;

public class ReciveItemNotify : MonoBehaviour
{
    public ItemUIwithNameCount itemUIwithNameCount;
    [System.Serializable]
    public struct ItemInString
    {
        [SerializeField]
        public string itemName;
        [SerializeField]
        public int amount;
    }
    [System.Serializable]
    public struct Item
    {
        public ItemName itemName;
        [SerializeField]
        public int amount;
    }
    [SerializeField]
    public Item[] items;
    public ItemInString[] itemsInString;
    public RectTransform ItemHolderTransform;
    public bool stringSetup = false;

    private void Awake()
    {
        if (itemUIwithNameCount == null)
        {
            itemUIwithNameCount = Resources.Load<ItemUIwithNameCount>("ItemInvUI/Item With Count And Name");
        }
    }
    private void OnEnable()
    {
        if (stringSetup)
        {
            SetupItemWithString();
        }
        TransformEx.Clear(ItemHolderTransform);
        foreach (Item item in items)
        {
            ItemUIwithNameCount itemUIwithNameCount = Instantiate(this.itemUIwithNameCount, ItemHolderTransform);
            itemUIwithNameCount.Setup(item.itemName, item.amount);

        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(ItemHolderTransform);
    }

    private void SetupItemWithString()
    {
        var list = new List<Item>();
        foreach (var item in itemsInString)
        {
            var import = new Item();
            import.amount = item.amount;
            import.itemName = (ItemName)Enum.Parse(typeof(ItemName), item.itemName);
            list.Add(import);
        }
    }

    private void OnDestroy()
    {
        //add item to inventory and they destroy gameobject.
        foreach (Item item in items)
        {
            for (int i = 0; i < item.amount; i++)
            {
                FindObjectOfType<ItemInventory>().AddItem(item.itemName);
            }
        }
    }


}
