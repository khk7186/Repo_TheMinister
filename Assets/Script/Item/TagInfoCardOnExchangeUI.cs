using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TagInfoCardOnExchangeUI : MonoBehaviour
{
    public Tag thisTag;
    public Tag newTag;

    [SerializeField] private Text Wisdom;
    [SerializeField] private Text Writing;
    [SerializeField] private Text Strategy;
    [SerializeField] private Text Strength;
    [SerializeField] private Text Sneak;
    [SerializeField] private Text Defense;
    
    [SerializeField] private Transform WisdomNew;
    [SerializeField] private Transform WritingNew;
    [SerializeField] private Transform StrategyNew;
    [SerializeField] private Transform StrengthNew;
    [SerializeField] private Transform SneakNew;
    [SerializeField] private Transform DefenseNew;

    [SerializeField] private Image tagIcon;

    private Sprite Up;
    private Sprite Down;

    private void Awake()
    {
        Up = Resources.Load<Sprite>("Art/UpDown/Up");
        Down = Resources.Load<Sprite>("Art/UpDown/Down");
    }

    public void SetUp(Tag thisTag, Tag newTag)
    {
        this.thisTag = thisTag;
        SetVars();
        SetTag();
    }
    private void SetVars()
    {
        Wisdom.text = "ÖÇ" + TagSpecUI.PlusOrMinus(Player.TagInfDict[thisTag][0]);
        Writing.text = "²Å" + TagSpecUI.PlusOrMinus(Player.TagInfDict[thisTag][1]);
        Strategy.text = "Ä±" + TagSpecUI.PlusOrMinus(Player.TagInfDict[thisTag][2]);
        Strength.text = "Îä" + TagSpecUI.PlusOrMinus(Player.TagInfDict[thisTag][3]);
        Sneak.text = "´Ì" + TagSpecUI.PlusOrMinus(Player.TagInfDict[thisTag][4]);
        Defense.text = "ÊØ" + TagSpecUI.PlusOrMinus(Player.TagInfDict[thisTag][5]);
    }

    private void SetTag()
    {
        tagIcon.sprite = TagSpecUI.FindTagSprite(thisTag);
    }

    private void SetExchangeState()
    {
        List<int> vs = new List<int>();
        for (int i = 0; i < 6; i++)
        {
            vs.Add(Player.TagInfDict[newTag][i] - Player.TagInfDict[thisTag][i]);
        }


        for (int i = 0; i < Mathf.Abs(vs[0]); i++)
        {
            Sprite sprite = UpOrDown(vs[0]);
            Instantiate(sprite, WisdomNew);
        }
        for (int i = 0; i < Mathf.Abs(vs[1]); i++)
        {
            Sprite sprite = UpOrDown(vs[1]);
            Instantiate(sprite, WritingNew);
        }
        for (int i = 0; i < Mathf.Abs(vs[2]); i++)
        {
            Sprite sprite = UpOrDown(vs[2]);
            Instantiate(sprite, StrategyNew);
        }
        for (int i = 0; i < Mathf.Abs(vs[3]); i++)
        {
            Sprite sprite = UpOrDown(vs[3]);
            Instantiate(sprite, StrengthNew);
        }
        for (int i = 0; i < Mathf.Abs(vs[4]); i++)
        {
            Sprite sprite = UpOrDown(vs[4]);
            Instantiate(sprite, SneakNew);
        }
        for (int i = 0; i < Mathf.Abs(vs[5]); i++)
        {
            Sprite sprite = UpOrDown(vs[5]);
            Instantiate(sprite, DefenseNew);
        }

    }

    private Sprite UpOrDown(int input)
    {
        Sprite outputSign = Up;
        if (input < 0) outputSign = Down;
        return outputSign;
    }
}
