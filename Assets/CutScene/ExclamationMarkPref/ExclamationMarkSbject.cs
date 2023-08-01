using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class ExclamationMarkSbject : MonoBehaviour
{
    public AnimationCurve showCurveX;
    public AnimationCurve showCurveY;
    public AnimationCurve hideCurveX;
    public AnimationCurve hideCurveY;
    public Transform Red;
    public Transform Yellow;
    public bool LoopAnimation = false;
    public Vector2 startSize = new Vector2(0f, 0f);
    public Vector2 targetSize = new Vector2(0.7f, 0.7f);
    public float duration = 0.5f;
    public float wait = 0.5f;
    public bool destroyOnHide = false;
    public void OnEnable()
    {
        Show();
    }
    public void ActiveRed()
    {
        Red.gameObject.SetActive(true);
        Yellow.gameObject.SetActive(false);
    }
    public void ActiveYellow()
    {
        Red.gameObject.SetActive(false);
        Yellow.gameObject.SetActive(true);
    }
    public void Show()
    {
        transform.localScale = startSize;
        transform.DOScaleX(targetSize.x, duration).SetEase(showCurveX);
        transform.DOScaleY(targetSize.y, duration).SetEase(showCurveY).OnComplete(() => StartCoroutine(WaitToHide()));
    }
    public void Hide()
    {
        transform.DOScaleX(startSize.x, duration).SetEase(hideCurveX);
        transform.DOScaleY(startSize.y, duration).SetEase(hideCurveY).OnComplete(
            () =>
            {
                if (destroyOnHide)
                {
                    Destroy(gameObject);
                }
                if (LoopAnimation)
                {
                    StartCoroutine(WaitToShow());
                }
            }
        );
    }
    public IEnumerator WaitToHide()
    {
        yield return new WaitForSeconds(wait);
        Hide();
    }
    public IEnumerator WaitToShow()
    {
        yield return new WaitForSeconds(wait);
        Show();
    }
}
