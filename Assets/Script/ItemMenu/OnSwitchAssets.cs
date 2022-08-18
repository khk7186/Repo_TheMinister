using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSwitchAssets : MonoBehaviour
{
    public ItemName item;
    public Character character;
    public Tag replacementTagOrigin;
    public Tag replacementTag;
    public Tag MergTag = Tag.Null;
    public Tag selectedTag;
    public GameObject OnChange;
    
    private void Start()
    {
        var newItem = FindObjectOfType<ItemInventoryUI>().GetComponentInChildren<ItemUI>();
        newItem.SetupInUseItem();
    }
}
