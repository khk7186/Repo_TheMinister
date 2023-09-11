using DG.Tweening;
using Language.Lua;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayTimeIconAnimController : MonoBehaviour
{
    public Image Day;
    public Image Noon;
    public Image Night;
    public Image Current;
    public Image Next;
    public AnimationCurve FadeCurve;
    public float FadeTime = 0.5f;


    public Sequence FadeSequence(Image current, Image next)
    {

        var output = DOTween.Sequence();
        output.Append(
            current.DOFade(0, FadeTime).SetEase(FadeCurve).OnComplete(() =>
                    {
                        next.DOFade(1f, FadeTime).SetEase(FadeCurve);
                    }
                )
            );
        return output;
    }
    private void Awake()
    {
        Day.color = new Color(Day.color.r, Day.color.g, Day.color.b, 0f);
        Noon.color = new Color(Noon.color.r, Noon.color.g, Noon.color.b, 0f);
        Night.color = new Color(Night.color.r, Night.color.g, Night.color.b, 0f);
    }
    private void OnEnable()
    {
        EnableEvent();

    }
    public void EnableEvent()
    {
        switch (Map.Instance.DayTime)
        {
            case (0):
                Current = Night;
                Next = Day;
                break;
            case (1):
                Current = Day;
                Next = Noon;
                break;
            case (2):
                Current = Noon;
                Next = Night;
                break;
        }
        GoNext();
    }
    public void GoNext()
    {
        if (Map.Instance == null) return;
        var seq = FadeSequence(Current, Next);
        seq.Play();
        //Debug.Log("play");
        SetNext(Map.Instance.DayTime);
    }
    public void SetNext(int daytime)
    {
        switch (daytime)
        {
            case (0):
                Current = Day;
                Next = Noon;
                break;
            case (1):
                Current = Noon;
                Next = Night;
                break;
            case (2):
                Current = Night;
                Next = Day;
                break;
        }
    }
}
