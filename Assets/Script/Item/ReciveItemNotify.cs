using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReciveItemNotify : MonoBehaviour
{
    public ItemUIwithNameCount itemUIwithNameCount;

    [System.Serializable]
    public struct Item
    {
        public ItemName itemName;
        [SerializeField]
        public int amount;
    }
    [SerializeField]
    public Item[] items;
    public RectTransform ItemHolderTransform;

    private void Awake()
    {
        if (itemUIwithNameCount == null)
        {
            itemUIwithNameCount = Resources.Load<ItemUIwithNameCount>("ItemInvUI/Item With Count And Name");
        }
    }
    private void OnEnable()
    {
        TransformEx.Clear(ItemHolderTransform);
        foreach (Item item in items)
        {
            ItemUIwithNameCount itemUIwithNameCount = Instantiate(this.itemUIwithNameCount, ItemHolderTransform);
            itemUIwithNameCount.Setup(item.itemName, item.amount);

        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(ItemHolderTransform);
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
