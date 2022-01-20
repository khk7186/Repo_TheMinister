using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BattleComfirmButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        FindObjectOfType<BattleSystem>().StateAction();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().color = Color.gray;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().color = Color.black;
    }

}
