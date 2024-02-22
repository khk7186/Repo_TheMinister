using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtraExpEvent
{
    public static void GainExp(int expAmount)
    {
        LevelManager.Instance.ExtraExp += expAmount;
        LevelManager.Instance.ApplyExp(expAmount);
    }
}
