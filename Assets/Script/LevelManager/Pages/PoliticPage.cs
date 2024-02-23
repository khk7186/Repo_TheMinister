using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PoliticPage : MonoBehaviour
{
    RectTransform rectTransform => GetComponent<RectTransform>();
    float originX = 31f;
    float zeroX = 210f;
    float duration = 0.2f;

    public void Show()
    {
        gameObject.SetActive(true);
        rectTransform.DOAnchorPosX(originX, duration);
        
    }
    public void Hide()
    {
        rectTransform.DOAnchorPosX(zeroX, duration).OnComplete(() => gameObject.SetActive(false));
    }
}
