using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Animations;

public class HintUI : MonoBehaviour
{
    public AnimationCurve animationCurve;
    public float duration = 0.3f;
    public float distanceX = 225f;
    public bool show = false;
    private RectTransform rectTransform=> GetComponent<RectTransform>();
    private void Start()
    {
        ShowHint();
    }

    public void ButtonAction()
    {
        if (show)
        {
            HideHint();
        }
        else
        {
            ShowHint();
        }
    }

    private void HideHint()
    {
        rectTransform.DOAnchorPosX(distanceX, duration).SetEase(animationCurve);
        show = false;
    }

    public void ShowHint()
    {
        rectTransform.DOAnchorPosX(0, duration).SetEase(animationCurve);
        show = true;
    }


}
