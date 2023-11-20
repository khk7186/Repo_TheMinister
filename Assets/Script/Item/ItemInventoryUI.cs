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
            if (itemInventory.ItemDict.Count <=0)
            {
                EmptyInvView();
                return;
            }
        }
        SetUp();
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
}
