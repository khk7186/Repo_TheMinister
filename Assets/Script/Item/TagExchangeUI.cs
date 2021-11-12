using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagExchangeUI : MonoBehaviour
{
    public Character character;
    public Tag newTag;
    public TagSpecUI tagSpecUI;

    public Transform tagCardGroup;
    public TagInfoCardOnExchangeUI tagCardPrf;

    public void SetUp()
    {
        foreach (Tag tag in character.tagList)
        {
            var current = Instantiate(tagCardPrf, tagCardGroup);
            current.SetUp(tag,newTag);
        }

        tagSpecUI.SetUp(newTag);
    }

}
