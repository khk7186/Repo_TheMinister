using Spine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliticCharacter : Character
{
    public int difficulty = 10;
    public int BribePrice = 100;
    public bool bribed = false;
    public PoliticSlot slot = null;
    public override void AwakeAction()
    {

    }
    public override void StartAction()
    {

    }
}
