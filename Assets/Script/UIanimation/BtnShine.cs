using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BtnShine : MonoBehaviour
{
    public float offset;
    public float speed;
    public float minDelay;
    public float maxDelay;


    private void Start()
    {
        Animate();
    }

    private void Animate()
    {
        transform.DOLocalMoveX(offset, speed)
           .SetEase(Ease.Linear)
           .SetDelay(UnityEngine
           .Random.Range(minDelay, maxDelay))
           .OnComplete(() =>
           {
               transform.DOLocalMoveX(-offset, 0);
               Animate();
           });
    }
}
