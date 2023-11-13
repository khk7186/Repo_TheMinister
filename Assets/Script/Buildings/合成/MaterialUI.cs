using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MaterialUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IDetailAble
{
    public Image ItemImage;
    public Image Frame;
    public Text NeedAmount;
    public Text HaveAmount;

    public int IntNeedAmount = 1;
    public int IntHaveAmount;

    private ItemName ItemName;
    public void OnPointerClick(PointerEventData eventData)
    {
    }

    public void SetUp(ItemName item, int haveAmount)
    {
        IntHaveAmount = haveAmount;
        ItemImage.sprite = Resources.Load<Sprite>(ReturnAssetPath.ReturnItemPath(item));
        var framRarity = Player.AllTagRareDict[SOItem.ItemMap[item]] != Rarerity.B ? Player.AllTagRareDict[SOItem.ItemMap[item]] : Rarerity.N;
        string FramePath = $"Art/BuildingUI/杂货铺/初级五金铺/物品框/物品框-{framRarity}";
        Frame.sprite = Resources.Load<Sprite>(FramePath);
        NeedAmount.text = 1.ToString();
        HaveAmount.text = haveAmount.ToString();
        ItemName = item;
    }
    public void LessHaveAmount()
    {
        IntHaveAmount -= 1; 
        HaveAmount.text = IntHaveAmount.ToString();
    }
    public void SetOnDetail(string target)
    {
        ItemDetailUI.Show(ItemName.ToString());
    }

    public void SetOffDetail()
    {
        ItemDetailUI.Hide();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetOnDetail(ItemName.ToString());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetOffDetail();
    }
}
