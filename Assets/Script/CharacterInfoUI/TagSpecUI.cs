using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TagSpecUI : MonoBehaviour
{
    public Image tagIcon;
    public Text Info;

    public void SetUp(Tag tag)
    {
        SetTagIcon(tag);
        SetTagInfo(tag);
    }

    private void SetTagIcon(Tag tag)
    {
        string FolderPathOfTags = ("Art/Tags/" + tag.ToString()).Replace(" ", string.Empty);
        tagIcon.sprite = Resources.Load<Sprite>(FolderPathOfTags);
    }

    private void SetTagInfo(Tag tag)
    {
        string output = "";
        output +=
            "ÖÇ" + PlusOrMinus(Player.TagInfDict[tag][0]) + " "
            + "²Å" + PlusOrMinus(Player.TagInfDict[tag][1]) + " "
            + "Ä±" + PlusOrMinus(Player.TagInfDict[tag][2]) + " "
            + "Îä" + PlusOrMinus(Player.TagInfDict[tag][3]) + " "
            + "´Ì" + PlusOrMinus(Player.TagInfDict[tag][4]) + " "
            + "ÊØ" + PlusOrMinus(Player.TagInfDict[tag][5]);
        Info.text = output;
    }


    private string PlusOrMinus(int input)
    {
        string output = "";
        string outputSign = "+";
        if (input < 0) outputSign = "-";
        for (int i =0; i < Mathf.Abs(input); i++)
        {
            output += outputSign;
        }
        return output;
    }
}
