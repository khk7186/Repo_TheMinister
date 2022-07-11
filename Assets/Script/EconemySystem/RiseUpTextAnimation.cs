using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RiseUpTextAnimation : MonoBehaviour
{
    public float speed = 0.5f;
    private float range = 50f;
    public float MoveToY = 80f;
    public Color FadeColor = new Color(253, 197, 0, 0);
    public AnimationCurve SpeedCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    public AnimationCurve FadeCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    public void Start()
    {
        StartAnimation();
    }
    public void StartAnimation()
    {
        GetComponent<RectTransform>()
            .DOLocalMoveY(MoveToY, speed)
            .SetEase(SpeedCurve)
            .SetDelay(0.1f);
        Color fadeColor = FadeColor;
        GetComponent<Text>()
            .DOColor(fadeColor, speed)
            .SetEase(FadeCurve)
            .SetDelay(0.1f)
            .OnComplete(() =>
                {
                    Destroy(gameObject);
                });
    }
}
