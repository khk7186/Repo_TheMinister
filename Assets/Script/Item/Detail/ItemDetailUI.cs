using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetailUI : MonoBehaviour
{
    public ItemName itemName;
    private static Dictionary<ItemName, string> ItemDescription => SOItem.ItemDescription;
    public Text Name;
    public Text description;
    public Text stat;
    public Vector2 offset = new Vector2(15, -15);  // Offset from the mouse position
    private RectTransform imageRectTransform;
    private RectTransform canvasRectTransform;
    private void Awake()
    {
        imageRectTransform = GetComponent<RectTransform>();
        canvasRectTransform = transform.parent.GetComponent<RectTransform>();
    }
    public void SetItemDetail()
    {
        Name.text = itemName.ToString();
        description.text = ItemDescription[itemName];
        stat.text = ItemStatPrinter.PrintAllStats(itemName);
    }
    private void OnEnable()
    {
        if (Name.text != itemName.ToString()) SetItemDetail();
        LayoutRebuilder.ForceRebuildLayoutImmediate(gameObject.GetComponent<RectTransform>());
    }
    private void Update()
    {
        SetPositionNextToMouse();
    }
    public void SetPositionNextToMouse()
    {
        // Convert mouse position to canvas space
        Vector2 mousePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRectTransform,
            Input.mousePosition,
            null,
            out mousePos);

        // Add the offset to the mouse position
        mousePos += offset;

        // Set the anchored position based on mouse
        imageRectTransform.anchoredPosition = mousePos;

        // Clamp the position so the UI stays within the screen bounds
        Vector2 clampedPosition = imageRectTransform.anchoredPosition;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -canvasRectTransform.sizeDelta.x / 2 + imageRectTransform.sizeDelta.x / 2, canvasRectTransform.sizeDelta.x / 2 - imageRectTransform.sizeDelta.x / 2);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -canvasRectTransform.sizeDelta.y / 2 + imageRectTransform.sizeDelta.y / 2, canvasRectTransform.sizeDelta.y / 2 - imageRectTransform.sizeDelta.y / 2);
        imageRectTransform.anchoredPosition = clampedPosition;
    }
    public static void Show(string target)
    {
        var ui = GameObject.FindObjectOfType<ItemDetailUI>(true);
        ui.itemName = (ItemName)Enum.Parse(typeof(ItemName), target);
        ui.gameObject.SetActive(true);
    }
    public static void Hide()
    {
        GameObject.FindObjectOfType<ItemDetailUI>(true).gameObject.SetActive(false);
    }
}

public interface IDetailAble
{
    public void SetOnDetail(string target);
    public void SetOffDetail();
}