using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    [SerializeField] private Canvas canvas;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        if (canvasGroup == null)
        {
            Debug.Log("NoCanvasGroupError");
            return;
        }
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = .3f;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        float scale;
        if (!canvas)
        {
            scale = 1f;
            Debug.Log("canvas null error");
        }
        else
        {
            scale = canvas.scaleFactor;
        }
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {

        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("ON");
    }


}
