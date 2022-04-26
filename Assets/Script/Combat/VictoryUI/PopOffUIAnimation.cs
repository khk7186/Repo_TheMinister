using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class PopOffUIAnimation : MonoBehaviour,IPointerClickHandler
{
    public AnimationCurve OpenCurve;
    public AnimationCurve CloseCurve;
    public float AnimationDuration = 1f;
    public float OriginalScale;
    public RectTransform rectTransform;
    private void Awake()
    {
        if (rectTransform == null)
            rectTransform = GetComponent<RectTransform>();
        OriginalScale = rectTransform.localScale.x;
        rectTransform.localScale = Vector3.zero;
    }
    private void Start()
    {
        Open();
    }
    public void Open()
    {
        rectTransform.DOScale(OpenCurve.Evaluate(2) * OriginalScale, AnimationDuration).SetEase(OpenCurve);
    }
    public void Close()
    {
        //CloseCurve.MoveKey(0, new Keyframe(0, OriginalScale));
        //CloseCurve.MoveKey(1, new Keyframe(0, CloseCurve.Evaluate(1) * OriginalScale));
        rectTransform.DOScale(Vector3.zero, AnimationDuration).SetEase(CloseCurve)
            .OnComplete(()=>Destroy(this.gameObject));
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Close();
    }
}
