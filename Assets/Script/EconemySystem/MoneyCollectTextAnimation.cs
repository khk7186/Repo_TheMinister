using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MoneyCollectTextAnimation : MonoBehaviour
{
    private float speed = 0.5f;
    private float range = 50f;
    public void Start()
    {
        StartAnimation();
    }
    public void StartAnimation()
    {
        GetComponent<RectTransform>()
            .DOLocalMoveY(80, speed)
            .SetEase(Ease.Linear)
            .SetDelay(0.1f);
        Color fadeColor = new Color(253, 197, 0, 0);
        GetComponent<Text>()
            .DOColor(fadeColor, speed)
            .SetEase(Ease.Linear)
            .SetDelay(0.1f)
            .OnComplete(() =>
                {
                    Destroy(gameObject);
                });
    }
}
