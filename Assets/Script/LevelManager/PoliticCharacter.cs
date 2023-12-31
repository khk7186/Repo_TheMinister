using Spine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliticCharacter : Character
{
    public static int ImpeachPriceMultiplier = 2;
    public int difficulty = 10;
    public int BribePrice = 100;
    public int BribeAlreadySpent = 100;
    public int ImpeachTime = 0;
    public int ImpeachDifficulty = 0;
    public bool bribed = false;
    public PoliticSlot slot = null;
    public int pressurePunishment = 2;
    public Character Assassin = null;
    public override void AwakeAction()
    {

    }
    public override void StartAction()
    {

    }
}
