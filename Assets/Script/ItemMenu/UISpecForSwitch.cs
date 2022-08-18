using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UISpecForSwitch : TagSpecUI
{
    public RectTransform originRect;
    public Tag switchTag;
    public RectTransform switchRect;
    public Image switchImage;
    public Text switchText;
    public float duration = 0.2f;

    public override void SetTagIcon(Tag tag, bool origin = true)
    {
        var target = origin ? tagIcon : switchImage;
        target.sprite = FindTagSprite(tag);
    }
    public override void SetTagInfo(Tag tag, bool origin = true)
    {
        var targetText = origin ? Info : switchText;
        string output = "";
        output =
            "ÖÇ" + PlusOrMinus(Player.TagInfDict[tag][0]) + " "
            + "²Å" + PlusOrMinus(Player.TagInfDict[tag][1]) + " "
            + "Ä±" + PlusOrMinus(Player.TagInfDict[tag][2]) + " "
            + "Îä" + PlusOrMinus(Player.TagInfDict[tag][3]) + " "
            + "´Ì" + PlusOrMinus(Player.TagInfDict[tag][4]) + " "
            + "ÊØ" + PlusOrMinus(Player.TagInfDict[tag][5]);
        targetText.text = output;
    }
    public void FlipTag()
    {
        var others = FindObjectsOfType<UISpecForSwitch>();
        foreach (var item in others)
        {
            if (item != this)
            {
                item.FlipBack();
            }
        }
        var OSA = FindObjectOfType<OnSwitchAssets>();
        OSA.MergTag = Tag.Null;
        OSA.OnChange = gameObject;
        OSA.replacementTag = OSA.replacementTagOrigin;
        SetUp(OSA.replacementTag, false);
        originRect.DOScaleY(0, duration).SetDelay(0.1f).OnComplete(() =>
        {
            FindObjectOfType<OnSwitchAssets>().selectedTag = originTag;
            FakeCharacterValues.SetFakeCharacterValues();
            switchRect.DOScaleY(1, duration);
        });
    }
    public void FlipBack()
    {
        switchRect.DOScaleY(0, duration).SetDelay(0.1f).OnComplete(() =>
        {
            originRect.DOScaleY(1, duration);
        });
    }
    public void FlipZero(Tag tag)
    {
        originRect.DOScaleY(0, duration).SetDelay(0.1f).OnComplete(() =>
        {
            originTag = tag;
            SetUp(tag);
            originRect.DOScaleY(1, duration);
        });
    }
    public void ConfirmChange()
    {
        var OSA = FindObjectOfType<OnSwitchAssets>();
        //Debug.Log("ConfirmChange: " + OSA.replacementTag);
        OSA.character.ExchangeTag(OSA.replacementTag, originTag);
        OSA.character.UpdateVariables();
        var itemInv = FindObjectOfType<ItemInventory>();
        itemInv.RemoveItem(OSA.item);
        SetUp(OSA.MergTag == Tag.Null ? OSA.replacementTag : OSA.MergTag, true);
        FlipBack();
        if (!itemInv.ItemDict.ContainsKey(OSA.item))
        {
            FindObjectOfType<ItemInventoryUI>().SetUp();
            FindObjectOfType<ItemInventoryUI>().GetComponentInChildren<ItemUI>().SetupInUseItem();
        }
    }
}
