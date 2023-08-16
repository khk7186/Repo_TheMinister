using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuDescriptionUITrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDetailAble
{
    public string targetName = string.Empty;
    public void OnPointerEnter(PointerEventData eventData)
    {
        SetOnDetail(targetName);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        SetOffDetail();
    }
    public void SetOffDetail()
    {
        MenuDescriptionUI.Hide();
    }
    public void SetOnDetail(string target)
    {
        MenuDescriptionUI.Show(target);
    }
}
