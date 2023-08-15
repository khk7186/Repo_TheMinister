using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CraftingMenuUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDetailAble
{
    public ItemName ItemName;
    public Image ItemIcon;
    public Text ItemNameText;
    public CraftingUI parentUI;


    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(SetupParent);
    }
    public void SetupParent()
    {
        parentUI.Setup(ItemName);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetOnDetail(ItemName);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ItemNameText.color = Color.white;
        SetOffDetail();
    }

    public void SetUp(ItemName item)
    {
        ItemName = item;
        string path = ("Art/ItemIcon/" + item.ToString()).Replace(" ", string.Empty);
        ItemIcon.sprite = Resources.Load<Sprite>(path);
        ItemNameText.text = item.ToString();
    }

    public void SetOnDetail(ItemName itemName)
    {
        ItemDetailUI.Show(itemName);
    }

    public void SetOffDetail()
    {
        ItemDetailUI.Hide();
    }
}
