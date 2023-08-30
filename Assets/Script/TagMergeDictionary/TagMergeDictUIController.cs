using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TagMergeDictUIController : MonoBehaviour
{
    public TagMergeDictManager tagMergeDictManager;
    public Button B;
    public Button N;
    public Button R;
    public Button SR;
    public Button SSR;
    public Button UR;
    public RectTransform content;
    public void Select(string rarerity)
    {
        //switch (rarerity)
        //{
        //    case Rarerity.B:
        //        break;
        //    case Rarerity.N:
        //        break;
        //    case Rarerity.R:
        //        break;
        //    case Rarerity.SR:
        //        break;
        //    case Rarerity.SSR:
        //        break;
        //    case Rarerity.UR:
        //        break;
        //    default: break;
        //}
        Goto((Rarerity)Enum.Parse(typeof(Rarerity), rarerity));
    }

    public void Goto(Rarerity rarerity)
    {
        var target = tagMergeDictManager.SelectParent(rarerity);
        var value = target.GetComponent<RectTransform>().anchoredPosition.x;
        content.anchoredPosition = new Vector2(-value, content.anchoredPosition.y);
    }

}
