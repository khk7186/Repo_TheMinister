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
    public static void ChapterShiftMessage(int currentChapter)
    {
        PixelCrushers.MessageSystem.SendMessage(null, "ChapterShift", currentChapter.ToString());
    }
    public static void DebateFinishMessage(bool result)
    {
        if (result == true)
        {
            PixelCrushers.MessageSystem.SendMessage(null, "DebateWin", "1");
        }
        else
        {
            PixelCrushers.MessageSystem.SendMessage(null, "DebateWin", "-1");
        }
    }
}
