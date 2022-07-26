using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuestFieldUI : MonoBehaviour, IPointerClickHandler
{
    public GameObject nodeRoot;
    public Button submitButton;

    public void Awake()
    {
        submitButton.gameObject.SetActive(false);
    }

    public void ShowSubmit()
    {
        submitButton.gameObject.SetActive(true);
    }
    public void HideSubmit()
    {
        submitButton.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            GetComponent<RightClickToClose>().RightClickEvent();
        }
    }
}
