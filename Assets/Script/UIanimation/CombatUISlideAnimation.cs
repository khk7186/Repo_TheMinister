using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CombatUISlideAnimation : MonoBehaviour
{
    public RectTransform CardA, CardB, CardC;
    public float speed = 0.5f;

    private void Awake()
    {
        SlideOut();
    }

    public void SlideIn()
    {
        var endvalue = CardA.localPosition.x;
        GetComponent<RectTransform>()
            .DOLocalMoveX(0, speed)
            .SetEase(Ease.Linear)
            .SetDelay(1.5f);
        CardB.DOLocalMoveX(endvalue, speed)
            .SetEase(Ease.Linear)
            .SetDelay(1.5f);
        CardC.DOLocalMoveX(endvalue, speed)
            .SetEase(Ease.Linear)
            .SetDelay(1.5f);
    }
    public void SlideOut()
    {
        var endvalue = CardA.localPosition.x;
        GetComponent<RectTransform>()
            .DOLocalMoveX(-80,speed)
            .SetEase(Ease.Linear)
            .SetDelay(1.5f);
        CardB.DOLocalMoveX(endvalue+80, speed)
            .SetEase(Ease.Linear)
            .SetDelay(1.5f);
        CardC.DOLocalMoveX(endvalue + 160, speed)
            .SetEase(Ease.Linear)
            .SetDelay(1.5f);
    }

    public void SlideLeft()
    {
        GetComponent<RectTransform>()
            .DOLocalMoveX(-80, speed)
            .SetEase(Ease.Linear)
            .SetDelay(1.5f);
    }
}
