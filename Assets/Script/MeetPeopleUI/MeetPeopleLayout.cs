using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class MeetPeopleLayout : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject tagList;
    public GameObject IdleImage;

    public Character character;

    private void Awake()
    {
        tagList.gameObject.SetActive(false);
        GetComponent<RectTransform>().sizeDelta = new Vector2(37.5f, 237.5f);
        IdleImage.GetComponent<RectTransform>().sizeDelta = new Vector2(37.5f, 237.5f);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {

        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            GetComponentInParent<RightClickToClose>().RightClickEvent();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(37.5f, 237.5f);
        IdleImage.GetComponent<RectTransform>().sizeDelta = new Vector2(37.5f, 237.5f);
        tagList.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(37.5f * 2, 237.5f);
        IdleImage.GetComponent<RectTransform>().sizeDelta = new Vector2(37.5f * 2, 237.5f);

        tagList.gameObject.SetActive(true);
    }

}
