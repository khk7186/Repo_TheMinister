using Spine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliticCharacter : Character
{
    public static int ImpeachPriceMultiplier = 2;
    public FactionType FactionType = FactionType.Œﬁµ≥≈…;
    public int BribePrice = 100;
    public int BribeAlreadySpent = 0;
    public int ImpeachTime = 0;
    public int ImpeachItemRequstNumber = 1;
    public int ImpeachDifficulty = 0;
    public bool bribed = false;
    public PoliticSlot slot = null;
    public int pressurePunishment = 2;
    public int AssassinDifficulty = 10;
    public Character Assassin = null;
    public List<string> TagsInString;
    public override void AwakeAction()
    {
        SetupTags();
        UpdateVariables();
    }
    public override void StartAction()
    {

    }
    public void SetupTags()
    {
        List<Tag> tags = new List<Tag>();
        foreach (var tagName in TagsInString)
        {
            tags.Add((Tag)Enum.Parse(typeof(Tag), tagName));
        }
        tagList = tags;
    }
}
