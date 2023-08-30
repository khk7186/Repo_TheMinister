using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TagMergeDictManager : MonoBehaviour
{
    public TagMergeUnitUI pref;
    public Transform parentB;
    public Transform parentN;
    public Transform parentR;
    public Transform parentSR;
    public Transform parentSSR;
    public Transform parentUR;
    private static Dictionary<Tag, List<Tag>> MergeTagDict => Player.MergeTagDict;
    private static Dictionary<Tag, Rarerity> AllTagRareDict => Player.AllTagRareDict;
    public void Start()
    {
        bool exist = false;
        foreach (Tag key in MergeTagDict.Keys)
        {
            var parent = SelectParent(AllTagRareDict[key]);
            if (parent != null)
            {
                var taget = Instantiate(pref, parent);
                taget.Setup(key);
                if (!exist)
                    exist = true;
            }
        }
        if (exist)
            pref.gameObject.SetActive(false);
    }

    public Transform SelectParent(Rarerity rarerity)
    {
        switch (rarerity)
        {
            case Rarerity.B:
                return parentB;
            case Rarerity.N:
                return parentN;
            case Rarerity.R:
                return parentR;
            case Rarerity.SR:
                return parentSR;
            case Rarerity.SSR:
                return parentSSR;
            case Rarerity.UR:
                return parentUR;
            default: return null;
        }
    }

}
