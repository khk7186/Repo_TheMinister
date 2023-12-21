using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class IndicatorController : MonoBehaviour
{
    public Image attack;
    public Image debate;
    public Image hire;
    public Image Selected;
    public AnimationCurve curve;
    [Header("Movement")]
    public float movementDuration = 0.7f;
    public float delay = 0.3f;
    public float floatRange = 100f;
    [Header("Fade")]
    public float fadeStart = 1f;
    public float fadeEnd = 0.3f;
    public float fadeDuration => movementDuration + delay;
    public float startValue => Selected.rectTransform.anchoredPosition.y - floatRange;
    public float endValue => Selected.rectTransform.anchoredPosition.y + floatRange;
    public float currentStartValue;
    public float currentEndValue;
    public bool endP = false;
    public Sequence currentSequence = null;
    public Sequence sequence
    {
        get
        {
            var output = DOTween.Sequence();
            output.Append(Selected.rectTransform.DOAnchorPosY(currentEndValue, movementDuration)
                                                                            .SetEase(curve).OnComplete(() =>
                                                                            {

                                                                                Selected.rectTransform.DOAnchorPosY(currentStartValue, movementDuration)
                                                                                                                        .SetEase(Ease.InSine).SetDelay(delay).OnComplete(() => { currentSequence = null; });
                                                                            })
                );
            output.Append(Selected.DOFade(fadeEnd, fadeDuration)).SetEase(Ease.InSine).OnComplete(() =>
                                                                            {
                                                                                Selected.DOFade(fadeStart, fadeDuration).SetEase(curve);
                                                                            }
            );
            return output;
        }
    }

    public void OnEnable()
    {
        OnEnableActions();
    }
    public virtual void OnEnableActions()
    {
        if (Selected != null) StartCoroutine(SequenceRator(Selected));
    }
    public void OnDisable()
    {
        StopAllCoroutines();
    }
    private IEnumerator SequenceRator(Image target)
    {
        currentStartValue = startValue;
        currentEndValue = endValue;
        while (Selected != null)
        {
            currentSequence = sequence;
            currentSequence.Play();
            //Debug.Log(endP);
            yield return new WaitUntil(() => currentSequence == null);
        }
    }
    public void ChangeSelected(string type)
    {
        if (Selected != null)
        {
            StopCoroutine(SequenceRator(Selected));
            Selected.gameObject.SetActive(false);
        }
        switch (type)
        {
            case ("attack"):
                Selected = attack;
                break;
            case ("debate"):
                Selected = debate;
                break;
            case ("hire"):
                Selected = hire;
                break;
        }
        if (Selected != null)
        {
            Selected.gameObject.SetActive(true);
            StartCoroutine(SequenceRator(Selected));
        }
    }
    private void Awake()
    {
        if (attack != null) attack.gameObject.SetActive(false);
        if (debate != null) debate.gameObject.SetActive(false);
        if (hire != null) hire.gameObject.SetActive(false);
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
