using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TagFromWhere : MonoBehaviour
{
    public Tag tag;
    public Text Where;
    public Color NColor = Color.white;
    public Color RColor = Color.white;
    public Color SRColor = Color.white;
    public Color SSRColor = Color.white;
    public Color URColor = Color.white;
    public Dictionary<Rarerity, List<Tag>> GivenableTagRareDict => Player.GivenableTagRareDict;
    public Dictionary<Rarerity, List<Tag>> MergeableTagRareDict => Player.MergeableTagRareDict;
    public Dictionary<Rarerity, List<Tag>> ItemgiveTagRareDict => Player.ItemgiveTagRareDict;
    public Dictionary<ItemName, Tag> ItemToTag => Player.ItemToTag;
    public void Setup(Tag tag)
    {
        this.tag = tag;
        string output = string.Empty;
        if (TryGiven())
        {
            output += "出生获得\n";
        }
        if (TryItem())
        {
            output += "使用道具获得：\n";
            Color rareColor = NColor;
            var Rarity = Player.AllTagRareDict[tag] != Rarerity.B ? Player.AllTagRareDict[tag] : Rarerity.N;
            if (Rarity == Rarerity.R) rareColor = RColor;
            else if (Rarity == Rarerity.SR) rareColor = SRColor;
            else if (Rarity == Rarerity.SSR) rareColor = SSRColor;
            else if (Rarity == Rarerity.UR) rareColor = URColor;
            output += $"<color=#{ColorUtility.ToHtmlStringRGBA(rareColor)}>{WhatItem(tag).ToString()}</color>";
        }
        if (TryMerge())
        {
            output += "词条合成获得\n";
        }
        Where.text = output;
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }
    public bool TryMerge()
    {
        foreach (var list in MergeableTagRareDict.Values)
        {
            if (list.Contains(tag))
            {
                return true;
            }
        }
        return false;
    }
    public bool TryGiven()
    {
        foreach (var list in GivenableTagRareDict.Values)
        {
            if (list.Contains(tag))
            {
                return true;
            }
        }
        return false;
    }
    public bool TryItem()
    {
        foreach (var list in ItemgiveTagRareDict.Values)
        {
            if (list.Contains(tag))
            {
                return true;
            }
        }
        return false;
    }
    public ItemName WhatItem(Tag tag)
    {
        foreach (var item in ItemToTag)
        {
            if (item.Value.Equals(tag)) return item.Key;
        }
        return ItemName.Null;
    }
}
