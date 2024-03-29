using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CombatEndingAnimationController : MonoBehaviour
{
    public Image win;
    public Image lose;
    public AnimationCurve curve;
    public Vector2 endScale;
    public float duration = 2f;
    public RectTransform target;
    public UnityEvent @event;
    public int result = 0;
    public float delay = 1f;
    private Sequence sequence
    {
        get
        {
            if (target == null) return null;
            var output = DOTween.Sequence();
            output.Append
                (
                    target.DOScale(endScale, duration).SetEase(curve).OnComplete(() => StartCoroutine(DelayEvent()))
                );
            output.Append
                (
                    target.DOAnchorPos(Vector2.zero, duration).SetEase(curve)
                );
            return output;
        }
    }
    private void Awake()
    {
        win.gameObject.SetActive(false);
        lose.gameObject.SetActive(false);
        @event = new UnityEvent();
        @event.AddListener(ChangeScene);
    }
    public void ChangeScene()
    {
        var trigger = GeneralEventTrigger.CurrentGET;
        trigger.TriggerEnd(result);
    }
    public void Win()
    {
        result = 1;
        win.gameObject.SetActive(true);
        lose.gameObject.SetActive(false);
        target = win.rectTransform;
        var play = sequence;
        play.Play();
    }
    public void Lose()
    {
        result = -1;
        lose.gameObject.SetActive(true);
        win.gameObject.SetActive(false);
        target = lose.rectTransform;
        var play = sequence;
        play.Play();
    }
    IEnumerator DelayEvent()
    {
        yield return new WaitForSeconds(delay);
        @event.Invoke();
    }
}
