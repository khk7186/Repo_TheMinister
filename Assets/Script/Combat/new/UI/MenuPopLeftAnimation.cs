using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuPopLeftAnimation : MonoBehaviour
{
    public AnimationCurve curve;
    public float X = -60;
    public float Xadds = 0;
    public float Yadds = 0;
    public float YSpace = 5;
    public RectTransform mainRT;
    public List<RectTransform> Buttons = new List<RectTransform>();
    public float speed = 0.2f;
    public float delay = 0.04f;

    public void Awake()
    {
        foreach (var item in Buttons)
        {
            item.anchoredPosition = mainRT.anchoredPosition;
            item.localScale = Vector3.zero;
        }
        Show();
    }
    public void Show()
    {
        FindObjectOfType<CombatSceneController>().OnAction = true;
        float YTop = mainRT.anchoredPosition.y + ((Buttons.Count - 1) * YSpace + Buttons[0].rect.height * Buttons.Count) / 2 + Yadds;
        for (int i = 0; i < Buttons.Count; i++)
        {
            var target = Buttons[i];
            float YFinal = YTop - YSpace * i - target.rect.height * i;
            float XFinal = mainRT.anchoredPosition.x + X;
            target.DOScale(1, speed).SetEase(curve).SetDelay(delay * i);
            target.DOAnchorPos(new Vector2(XFinal, YFinal), speed).SetEase(curve).SetDelay(delay * i);
        }
    }

    public void Hide()
    {
        var csc = FindObjectOfType<CombatSceneController>();
        csc.OnAction = false;
        
        for (int i = 0; i < Buttons.Count; i++)
        {
            var target = Buttons[i];
            target.GetComponent<Button>().interactable = false;
            target.DOScale(0, speed).SetEase(curve);
            var tartgetPos = Vector2.zero;
            if (i == Buttons.Count - 1)
            {
                target.DOAnchorPos(tartgetPos, speed).SetEase(curve)
                    .OnComplete(() => { Destroy(gameObject); });
            }
            else target.DOAnchorPos(tartgetPos, speed).SetEase(curve);
        }
    }
}
