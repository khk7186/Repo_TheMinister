using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TagMergeUnitUI : MonoBehaviour
{
    public TagWithDescribetion tagPref;

    public Transform reqireTagsParent;
    public Transform outputTagsParent;
    public Image bracket;
    public List<Sprite> bracketRefs = new List<Sprite>();
    private static Dictionary<Tag, List<Tag>> MergeTagDict => Player.MergeTagDict;

    public void Setup(Tag tag)
    {
        var reqireTags = MergeTagDict[tag];
        foreach (var reqireTag in reqireTags)
        {
            var reqire = Instantiate(tagPref, reqireTagsParent);
            reqire.Setup(reqireTag);
        }
        var output = Instantiate(tagPref, outputTagsParent);
        output.Setup(tag);
        bracket.sprite = bracketRefs[reqireTags.Count - 2];
    }

}
