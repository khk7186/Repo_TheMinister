using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MoneyCollectAnimationHandler
{
    private RectTransform rect;
    private float YChange = 1000f;
    private Vector3 origin;
    private Vector3 end => new Vector3(origin.x, origin.y + YChange, origin.z);
    private float duration;
    private float delay;
    private Sequence sequence
    {
        get
        {
            Sequence output = DOTween.Sequence();
            output.Append(rect.DOAnchorPosY(end.y, duration).SetEase(MoneyCollectManager.Instance.curve).OnComplete(() =>
            {
                rect.DOAnchorPosY(origin.y, duration).SetEase(MoneyCollectManager.Instance.curve).SetDelay(delay);
            }));
            var canvasGroup = rect.GetComponent<CanvasGroup>();
            output.Append(canvasGroup.DOFade(1, duration).OnComplete(() =>
            {
                canvasGroup.DOFade(0, duration).SetDelay(delay);
            }));
            return output;
        }
    }
    public MoneyCollectAnimationHandler(RectTransform rect, float yChange, float duration, float delay)
    {
        this.rect = rect;
        this.origin = rect.anchoredPosition;
        this.duration = duration;
        this.YChange = yChange;
        this.delay = delay;
    }
    public void Play()
    {
        sequence.Play();
    }
}
