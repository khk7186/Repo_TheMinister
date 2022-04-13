using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class InvIntroAnimation : MonoBehaviour, IPointerClickHandler
{
    private bool disable = false;
    public delegate void diableEvent();
    public diableEvent disableEvent;
    public void SetDisable(bool disable)
    {
        this.disable = disable;
    }
    private void Start()
    {
        Intro();
    }
    private void Intro()
    {
        var targetRT = GetComponent<RectTransform>();
        targetRT.anchoredPosition = new Vector2(800f, 0f);
        targetRT.DOAnchorPosX(0f, 0.3f).SetEase(Ease.InOutSine).Delay();
    }


    public void Outro()
    {
        var targetRT = GetComponent<RectTransform>();
        targetRT.DOAnchorPosX(800f, 0.3f).OnComplete(() => Destroy(gameObject));
    }

    public void SetDiableDelegate(diableEvent disableEvent)
    {
        this.disableEvent = disableEvent;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (!disable)
            {
                Outro();
            }
            else
            {
                disableEvent();
            }
        }
    }
}
