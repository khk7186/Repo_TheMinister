using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

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
    public List<GameObject> FrameAssets = new List<GameObject>();

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
        FilterByItemType("All");
        FilterByRarerity("All");
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
        foreach (Transform child in rareButtons)
        {
            if (child.name != rare)
            {
                HorizontalDeselectAnimation(child.gameObject.GetComponent<RectTransform>());
            }
            else
            {
                HorizontalSelectAnimation(child.gameObject.GetComponent<RectTransform>());
            }
        }
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
        foreach (Transform child in typeButtons)
        {
            if (child.name != type)
            {
                VerticalDeselectAnimation(child.gameObject.GetComponent<RectTransform>());
            }
            else
            {
                VerticalSelectAnimation(child.gameObject.GetComponent<RectTransform>());
            }
        }
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
        foreach (var go in FrameAssets)
        {
            go.SetActive(false);
        }
    }
    public void FilterSetup()
    {
        foreach (var go in FrameAssets)
        {
            go.SetActive(true);
        }
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
        StartCoroutine(UpdateButtons());
    }
    public void VerticalSelectAnimation(RectTransform target)
    {
        target.DOAnchorPosY(-40, 0.1f);
    }
    public void VerticalDeselectAnimation(RectTransform target)
    {
        target.DOAnchorPosY(-30, 0.1f);
    }
    public void HorizontalSelectAnimation(RectTransform target)
    {
        target.DOAnchorPosX(40, 0.1f);
    }
    public void HorizontalDeselectAnimation(RectTransform target)
    {
        target.DOAnchorPosX(30, 0.1f);
    }
    IEnumerator UpdateButtons()
    {
        rareButtons.GetComponent<VerticalLayoutGroup>().enabled = true;
        typeButtons.GetComponent<HorizontalLayoutGroup>().enabled = true;

        yield return new WaitForEndOfFrame();
        LayoutRebuilder.ForceRebuildLayoutImmediate(rareButtons.GetComponent<RectTransform>());
        LayoutRebuilder.ForceRebuildLayoutImmediate(typeButtons.GetComponent<RectTransform>());

        yield return new WaitForEndOfFrame();
        rareButtons.GetComponent<VerticalLayoutGroup>().enabled = false;
        typeButtons.GetComponent<HorizontalLayoutGroup>().enabled = false;
    }
}
