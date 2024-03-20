using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ItemInvBackgroundAnimation : MonoBehaviour
{
    [SerializeField] private RectTransform _back;
    [SerializeField] private RectTransform _front;
    [SerializeField] private RectTransform _main;
    [SerializeField] private float _duration = 0.5f;
    [SerializeField] private float _frontRange = 100f;
    [SerializeField] private float _mainRange = 100f;
    [SerializeField] private float _backRange = 110f;
    GameObject confirmButton = null;
    private void Start()
    {
        if (confirmButton == null)
        {
            confirmButton = GameObject.FindGameObjectWithTag("ConfirmButton");
        }
    }
    public void BackGroundShift(bool toRight)
    {
        if (toRight)
        {
            confirmButton.SetActive(false);
        }
        else
        {
            confirmButton.SetActive(true);
            var inv = FindObjectOfType<ItemInventoryUI>();
            inv.SetUp(inv.itemInventory);
        }
        float backShift = toRight ? -_backRange : 0;
        float frontShift = toRight ? -_frontRange : 1170;
        float mainShift = toRight ? -_mainRange : 0;
        _back.DOAnchorPosX(backShift, _duration).Delay();
        _front.DOAnchorPosX(frontShift, _duration).Delay();
        _main.DOAnchorPosX(mainShift, _duration).Delay();
    }

    public void UseItemMenu()
    {
        BackGroundShift(true);
        var Animation = GetComponentInParent<InvIntroAnimation>();
        Animation.SetDisable(true);
        Debug.Log("setDisable");
        Animation.SetDiableDelegate(() =>
        {
            BackGroundShift(false);
            Animation.SetDisable(false);
            
        });
    }

    public void FrontDown(bool down)
    {
        int y = down ? -600 : -367;
        _front.DOAnchorPosY(y, 0.3f);
    }
}
