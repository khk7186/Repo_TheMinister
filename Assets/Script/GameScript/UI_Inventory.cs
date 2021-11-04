using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    [SerializeField] private Inventory inventory;

    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    [SerializeField] private GameObject ItemInventoryUI;
    [SerializeField] private GameObject OpenButton;
    [SerializeField] private GameObject CloseButton;

    [Header("UIItemElement")]
    [SerializeField] private GameObject nullPrefab;

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }

    public void Awake()
    {
        ItemInventoryUI.SetActive(false);
        CloseButton.SetActive(false);
    }

    public void OpenItemInventory()
    {
        OpenButton.SetActive(false);
        CloseButton.SetActive(true);
        ItemInventoryUI.SetActive(true);
        RefreshInventoryItems();
        
    }


    public void CloseInventory()
    {
        GameObject inventoryUI = ItemInventoryUI.gameObject;
        foreach(Transform child in inventoryUI.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        OpenButton.SetActive(true);
        CloseButton.SetActive(false);
        ItemInventoryUI.SetActive(false);
        ItemInventoryUI.transform.parent = transform;
        
    }

    private void RefreshInventoryItems()
    {
        foreach (ItemName item in inventory.ItemDict.Keys)
        {
            //have all ui prefab under here to instantiate elements
            switch (item)
            {
                default:
                case ItemName.Null:
                    var prefab = Instantiate(nullPrefab, ItemInventoryUI.transform);
                    break;
                    
            }
            
        }
        UpdateCanvas();
    }

    private void UpdateCanvas()
    {
        Canvas.ForceUpdateCanvases();
    }


}
