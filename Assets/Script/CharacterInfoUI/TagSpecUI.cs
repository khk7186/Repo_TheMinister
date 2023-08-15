using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TagSpecUI : MonoBehaviour
{
    public Tag originTag;
    public Image tagIcon;
    public Text Info;

    public void SetUp(Tag tag, bool origin = true)
    {
        if (origin)
        {
            originTag = tag;
        }
        SetTagIcon(tag, origin);
        SetTagInfo(tag, origin);
    }

    public virtual void SetTagIcon(Tag tag, bool origin = true)
    {
        tagIcon.sprite = FindTagSprite(tag);
    }

    public static Sprite FindTagSprite(Tag tag)
    {
        string FolderPathOfTags = $"Art/Tags/{tag.ToString()}";
        return Resources.Load<Sprite>(FolderPathOfTags);
    }

    public virtual void SetTagInfo(Tag tag, bool origin = true)
    {
        string output = ItemStatPrinter.PrintAllStats(tag).Replace("\n", "");
        //for (int i = 0; i < Player.TagInfDict[tag].Count; i++)
        //{
        //    if (Player.TagInfDict[tag][i] == 0) continue;
        //    switch (i)
        //    {
        //        case 0:
        //            output += $"ÖÇ{PlusOrMinus(Player.TagInfDict[tag][0])} ";
        //            break;
        //        case 1:
        //            output += $"²Å{PlusOrMinus(Player.TagInfDict[tag][1])} ";
        //            break;
        //        case 2:
        //            output += $"Ä±{PlusOrMinus(Player.TagInfDict[tag][2])} ";
        //            break;
        //        case 3:
        //            output += $"Îä{PlusOrMinus(Player.TagInfDict[tag][3])} ";
        //            break;
        //        case 4:
        //            output += $"´Ì{PlusOrMinus(Player.TagInfDict[tag][4])} ";
        //            break;
        //        case 5:
        //            output += $"ÊØ{PlusOrMinus(Player.TagInfDict[tag][5])}";
        //            break;
        //    }
        //}
        Info.text = output;
    }
    public static string PlusOrMinus(int input)
    {
        string output = "";
        string outputSign = "+";
        if (input < 0) outputSign = "-";
        for (int i = 0; i < Mathf.Abs(input); i++)
        {
            output += outputSign;
        }
        return output;
    }
}
