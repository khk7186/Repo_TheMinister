using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BtnShine : MonoBehaviour
{
    public Vector2 startPos = new Vector2(-45f, -55f);
    public Vector2 endPos = new Vector2(50f, 40f);
    public float speed;
    public float minDelay;
    public float maxDelay;
    public RectTransform animationImage;
    public Sequence sequence
    {
        get
        {
            var output = DOTween.Sequence();
            output.Append
                (
                  animationImage.DOAnchorPos(endPos, speed)
                           .SetEase(Ease.Linear)
                           .SetDelay(UnityEngine
                           .Random.Range(minDelay, maxDelay))
                           .OnComplete(() =>
                           {
                               output.Restart();
                           })
                        );
            return output;
        }
    }

    private void Start()
    {
        Animate();
    }

    private void Animate()
    {
        animationImage.anchoredPosition = startPos;
        sequence.Play();
    }
}
