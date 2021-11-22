using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TagInfoCardOnExchangeUI : MonoBehaviour, IPointerClickHandler
{
    public Tag thisTag;
    public Tag newTag;
    public Character character;

    [SerializeField] private Text Wisdom;
    [SerializeField] private Text Writing;
    [SerializeField] private Text Strategy;
    [SerializeField] private Text Strength;
    [SerializeField] private Text Sneak;
    [SerializeField] private Text Defense;

    [SerializeField] private Image tagIcon;


    public void SetUp(Tag thisTag, Tag newTag, Character character)
    {
        this.thisTag = thisTag;
        this.newTag = newTag;
        this.character = character;
        SetVars();
        SetTag();
    }
    private void SetVars()
    {
        List<int> vs = new List<int>();
        for (int i = 0; i < 6; i++)
        {
            vs.Add(Player.TagInfDict[newTag][i] - Player.TagInfDict[thisTag][i]);
        }
        Wisdom.text = "ÖÇ" + TagSpecUI.PlusOrMinus(vs[0]);
        Writing.text = "²Å" + TagSpecUI.PlusOrMinus(vs[1]);
        Strategy.text = "Ä±" + TagSpecUI.PlusOrMinus(vs[2]);
        Strength.text = "Îä" + TagSpecUI.PlusOrMinus(vs[3]);
        Sneak.text = "´Ì" + TagSpecUI.PlusOrMinus(vs[4]);
        Defense.text = "ÊØ" + TagSpecUI.PlusOrMinus(vs[5]);
    }

    private void SetTag()
    {
        tagIcon.sprite = TagSpecUI.FindTagSprite(thisTag);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            character.tagList.Remove(thisTag);
            character.tagList.Add(newTag);
            character.UpdateVariables();
            GetComponentInParent<Transform>().GetComponentInParent<TagExchangeUI>().FinishTheState();
        }
    }
}
