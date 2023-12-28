using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TagWithDescribetion : MonoBehaviour, IDetailAble, IPointerEnterHandler, IPointerExitHandler
{
    public Image Image;
    private Tag Tag;
    public int timeLeft = 0;
    public bool TempTag = false;

    public void SetOffDetail()
    {
        TagDescriptionUI.Hide();
    }

    public void SetOnDetail(string target)
    {
        if (TempTag)
        {
            TagDescriptionUI.ShowTemp(Tag.ToString(), timeLeft);
            return;
        }
        TagDescriptionUI.Show(Tag.ToString());
    }

    public void Setup(Tag tag)
    {
        Image.sprite = Resources.Load<Sprite>(ReturnAssetPath.ReturnTagPath(tag));
        Tag = tag;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        SetOnDetail("");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetOffDetail();
    }
}
