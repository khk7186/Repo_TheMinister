using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BtnShineExp : MonoBehaviour
{
    public float offset;
    public float speed;
    public float Delay;


    private void Start()
    {
        Animate();
    }

    private void Animate()
    {
        transform.DOScale(offset, speed)
           .SetEase(Ease.Linear)
           .SetDelay(Delay)
           .OnComplete(() =>
           {
               
               transform.localScale = new Vector2(0f, 0f);
               
               //transform.DOScale(-offset, 0);
               Animate();
           });
    }

}
