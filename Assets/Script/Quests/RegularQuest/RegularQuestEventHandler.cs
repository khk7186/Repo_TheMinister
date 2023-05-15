using PixelCrushers.QuestMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RegularQuestEventHandler
{
    public static void ElimMessage()
    {
        PixelCrushers.MessageSystem.SendMessage(null, "ElimAdd", "1");
    }
}
