using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CraftingMenuUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public ItemName ItemName;
    public Image ItemIcon;
    public Text ItemNameText;
    public CraftingUI parentUI;

    public void OnPointerClick(PointerEventData eventData)
    {
        //TODO:Switch Parent's current crafting item.
        parentUI.SetUp(ItemName);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ItemIcon.gameObject.SetActive(false);
        ItemNameText.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ItemIcon.gameObject.SetActive(true);
        ItemNameText.gameObject.SetActive(false);
    }

    public void SetUp(ItemName item)
    {
        ItemName = item;
        string path = ("Art/ItemIcon/" + item.ToString()).Replace(" ", string.Empty);
        ItemIcon.sprite = Resources.Load<Sprite>(path);
        ItemNameText.text = item.ToString();
    }
}
