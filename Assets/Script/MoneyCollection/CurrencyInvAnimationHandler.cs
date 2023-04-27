using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using DG.Tweening;

public class CurrencyInvAnimationHandler
{
    public RectTransform rect;
    public float YChange = 20f;
    public Vector3 origin;
    public Vector3 end1 => new Vector3(origin.x, origin.y + YChange, origin.z);
    public Vector3 end2 => new Vector3(origin.x, origin.y + YChange + YChange, origin.z);
    public float duration;
    public float delay;
    public string message;
    public delegate void AfterAnimation();
    public AfterAnimation afterAnimation;
    public Sequence sequence
    {
        get
        {
            Sequence output = DOTween.Sequence();
            output.Append(rect.DOAnchorPosY(end1.y, duration).SetEase(MoneyCollectManager.Instance.curve).OnComplete(() =>
            {
                rect.DOAnchorPosY(end2.y, duration).SetEase(MoneyCollectManager.Instance.curve).SetDelay(delay);
            }));
            var canvasGroup = rect.GetComponent<CanvasGroup>();
            output.Append(canvasGroup.DOFade(1, duration).SetEase(MoneyCollectManager.Instance.curve).OnComplete(() =>
            {
                canvasGroup.DOFade(0, duration).SetDelay(delay).SetEase(MoneyCollectManager.Instance.curve).OnComplete(() =>
                {
                    if (afterAnimation != null)
                    {
                        afterAnimation.Invoke();
                    }
                    GameObject.Destroy(rect.gameObject);
                });
            }));
            return output;
        }

    }
    public CurrencyInvAnimationHandler(RectTransform rect)
    {
        this.rect = GameObject.Instantiate(rect,rect.parent);
        var manager = CurrencyInvAnimationManager.Instance;
        this.origin = manager.MoneyAnimationTextOrigin;
        this.duration = manager.duration;
        this.YChange = manager.YChange;
        this.delay = manager.delay;
    }

    public void Play()
    {
        rect.gameObject.SetActive(true);
        rect.GetComponent<CanvasGroup>().alpha = 0f;
        sequence.Play();
    }

}
