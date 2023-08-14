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
        transform.position = Input.mousePosition;
    }
    public static void Show(ItemName itemName)
    {
        var ui = GameObject.FindObjectOfType<ItemDetailUI>(true);
        ui.itemName = itemName;
        ui.gameObject.SetActive(true);
    }
    public static void Hide()
    {
        GameObject.FindObjectOfType<ItemDetailUI>(true).gameObject.SetActive(false);
    }
}

public interface IDetailAble
{
    public void SetOnDetail(ItemName itemName);
    public void SetOffDetail();
}