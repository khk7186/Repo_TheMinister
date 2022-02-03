using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CombatUICharacterRotateAnimation : MonoBehaviour
{
    public RectTransform Front, Next, Last, Free;
    public float speed = 0.5f;
    public float space = 50f;

    private bool Animating = false;
    public void ScrollUp()
    {
        StartCoroutine(ScrollUpAnimation());
    }

    private IEnumerator ScrollUpAnimation()
    {
        if (!Animating)
        {
            Animating = true;
            var endvalue = Front.localPosition.x;
            Front.DOAnchorPosX(space, speed)
                .SetEase(Ease.Linear)
                .SetDelay(speed);
            Front.DOScale(1f, speed)
                .SetEase(Ease.Linear)
                .SetDelay(speed);
            Front.GetComponent<BattleCharacterHeadUI>()
                .OffSelect();
            Last.DOAnchorPosX(endvalue, speed)
                .SetEase(Ease.Linear)
                .SetDelay(speed);
            Last.DOScale(1.5f, speed)
                .SetEase(Ease.Linear)
                .SetDelay(speed);
            Last.GetComponent<BattleCharacterHeadUI>()
                .OnSelect();
            Next.DOAnchorPosX(-space, speed)
                .SetEase(Ease.Linear)
                .SetDelay(speed)
                .OnComplete(() =>
                {
                    Animating = false;
                });
            yield return new WaitForEndOfFrame();
            Free = Front;
            Front = Last;
            Last = Next;
            Next = Free;
            SetupLayer();
            Front.GetComponent<UIGroupLayerSorting>().Setup(3);
            Next.GetComponent<UIGroupLayerSorting>().Setup(2);
            Last.GetComponent<UIGroupLayerSorting>().Setup(1);
            FindObjectOfType<BattleSystem>().SetCurrentAction(Action.NoSelect);
        }
    }

    public void ScrollDown()
    {
        StartCoroutine(ScrollDownAnimation());
    }
    private IEnumerator ScrollDownAnimation()
    {
        if (!Animating)
        {
            Animating = true;
            var endvalue = Front.localPosition.x;
            Front.DOAnchorPosX(-space, speed)
                .SetEase(Ease.Linear)
                .SetDelay(speed);
            Front.DOScale(1f, speed)
                .SetEase(Ease.Linear)
                .SetDelay(speed);
            Front.GetComponent<BattleCharacterHeadUI>()
                .OffSelect();
            Next.DOAnchorPosX(endvalue, speed)
                .SetEase(Ease.Linear)
                .SetDelay(speed);
            Next.DOScale(1.5f, speed)
                .SetEase(Ease.Linear)
                .SetDelay(speed);
            Next.GetComponent<BattleCharacterHeadUI>()
                .OnSelect();
            Last.DOAnchorPosX(space, speed)
                .SetEase(Ease.Linear)
                .SetDelay(speed).OnComplete(() =>
                {
                    Animating = false;
                });
            yield return new WaitForEndOfFrame();
            Free = Front;
            Front = Next;
            Next = Last;
            Last = Free;
            Front.GetComponent<UIGroupLayerSorting>().Setup(3);
            Next.GetComponent<UIGroupLayerSorting>().Setup(1);
            Last.GetComponent<UIGroupLayerSorting>().Setup(2);
            FindObjectOfType<BattleSystem>().SetCurrentAction(Action.NoSelect);
        }
    }

    public void SetupLayer()
    {
        
    }
}
