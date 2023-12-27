using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemInventoryUI : MonoBehaviour, IPointerClickHandler
{
    public Image ItemPrefab;
    public ItemInventory itemInventory;
    public GameObject EmptyWarn;
    public GameObject[] OffForEmptyWarn;
    public Rarerity currentRareFilter = Rarerity.Null;
    public string currentTypeFilter = string.Empty;
    public Transform rareButtons;
    public Transform typeButtons;

    private void Awake()
    {
        ItemPrefab = Resources.Load<Image>("ItemInvUI/ItemUnitUI");
        ItemInventory itemInventory = GameObject.FindGameObjectWithTag("PlayerItemInventory").GetComponent<ItemInventory>();
        SetUp(itemInventory);
    }
    public void SetUp(ItemInventory itemInventory)
    {
        this.itemInventory = itemInventory;
        if (itemInventory != null)
        {
            if (itemInventory.ItemDict.Count <= 0)
            {
                EmptyInvView();
                CloseAllFilters();
                return;
            }
        }
        SetUp();
        FilterSetup();
    }
    public void EmptyInvView()
    {
        EmptyWarn.gameObject.SetActive(true);
        foreach (GameObject go in OffForEmptyWarn)
        {
            go.SetActive(false);
        }
    }
    public void SetUp()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        if (itemInventory == null)
        {
            itemInventory = FindObjectOfType<ItemInventory>();
        }
        foreach (ItemName key in itemInventory.ItemDict.Keys)
        {
            Image target = Instantiate(ItemPrefab, transform);
            //Debug.Log(key);
            target.GetComponent<ItemUI>().Setup(key, itemInventory.ItemDict[key]);
        }

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {

        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {

        }
    }

    public void FilterByRarerity(string rare)
    {
        if (rare == "All")
        {
            currentRareFilter = Rarerity.Null;
            foreach (Transform child in transform)
            {
                if (currentTypeFilter == "All")
                {

                    child.gameObject.SetActive(true);
                }
                else
                {
                    ItemType itemType = (ItemType)Enum.Parse(typeof(ItemType), currentTypeFilter);
                    if (SOItem.ItemTypeDict[itemType].Contains(child.GetComponent<ItemUI>().ItemName))
                    {
                        child.gameObject.SetActive(true);
                    }
                    else
                    {
                        child.gameObject.SetActive(false);
                    }
                }
            }
            return;
        }
        var rarerity = (Rarerity)Enum.Parse(typeof(Rarerity), rare);
        currentRareFilter = rarerity;
        foreach (Transform child in transform)
        {
            if (child.GetComponent<ItemUI>().framRarity == rarerity)
            {
                if (currentTypeFilter == "All")
                {

                    child.gameObject.SetActive(true);
                }
                else
                {
                    ItemType itemType = (ItemType)Enum.Parse(typeof(ItemType), currentTypeFilter);
                    if (SOItem.ItemTypeDict[itemType].Contains(child.GetComponent<ItemUI>().ItemName))
                    {
                        child.gameObject.SetActive(true);
                    }
                    else
                    {
                        child.gameObject.SetActive(false);
                    }
                }
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
    }
    public void FilterByItemType(string type)
    {
        currentTypeFilter = type;
        if (type == "All")
        {
            foreach (Transform child in transform)
            {
                if (currentRareFilter == Rarerity.Null || child.GetComponent<ItemUI>().framRarity == currentRareFilter)
                {

                    child.gameObject.SetActive(true);
                }
                else
                {
                    child.gameObject.SetActive(false);
                }
            }
            return;
        }
        ItemType itemType = (ItemType)Enum.Parse(typeof(ItemType), type);
        foreach (Transform child in transform)
        {
            if (SOItem.ItemTypeDict[itemType].Contains(child.GetComponent<ItemUI>().ItemName))
            {
                if (currentRareFilter == Rarerity.Null || child.GetComponent<ItemUI>().framRarity == currentRareFilter)
                {

                    child.gameObject.SetActive(true);
                }
                else
                {
                    child.gameObject.SetActive(false);
                }
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
    }
    public void CloseAllFilters()
    {
        foreach (Transform child in rareButtons)
        {
            child.gameObject.SetActive(false);
        }
        foreach (Transform child in typeButtons)
        {
            child.gameObject.SetActive(false);
        }
    }
    public void FilterSetup()
    {
        Debug.Log("filter");
        List<string> rareList = new List<string>();
        List<ItemType> typeList = new List<ItemType>();
        foreach (Transform child in transform)
        {
            var childRare = child.GetComponent<ItemUI>().framRarity.ToString();
            if (!rareList.Contains(childRare)) rareList.Add(childRare);
            foreach (var item in SOItem.ItemTypeDict)
            {
                if (item.Value.Contains(child.GetComponent<ItemUI>().ItemName))
                {
                    if (!typeList.Contains(item.Key)) typeList.Add(item.Key);
                    break;
                }
            }
        }
        Debug.Log(string.Join(",", typeList));
        Debug.Log(string.Join(",", rareList));
        foreach (Transform child in rareButtons)
        {
            if (child.name == "All")
            {
                gameObject.SetActive(true);
            }
            else if (rareList.Contains(child.gameObject.name))
            {
                child.gameObject.SetActive(true);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
        foreach (Transform child in typeButtons)
        {
            Debug.Log(child.gameObject.name);
            if (child.name == "All")
            {
                child.gameObject.SetActive(true);
            }
            else
            {
                ItemType itemType = (ItemType)Enum.Parse(typeof(ItemType), child.gameObject.name);
                if (typeList.Contains(itemType))
                {
                    child.gameObject.SetActive(true);
                }
                else
                {
                    child.gameObject.SetActive(false);
                }
            }
        }
    }
}
