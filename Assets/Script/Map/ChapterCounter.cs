using PixelCrushers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterCounter : MonoBehaviour
{
    public static ChapterCounter Instance;
    public int Chapter
    {
        get
        {
            return count;
        }
        set
        {
            count = value;
            RegularQuestEventHandler.ChapterShiftMessage(value);
            PressureEventHandler.OnAddPerDayChange(value);
            LastChapterAIExitGame();
        }
    }
    public int count = 0;
    private List<QuestGiverAI> InGameQuestAI = new List<QuestGiverAI>();
    public static void QuestAISignIn(QuestGiverAI questGiverAI)
    {
        ChapterCounter.Instance.InGameQuestAI.Add(questGiverAI);
    }
    public static void LastChapterAIExitGame()
    {
        foreach (QuestGiverAI ai in Instance.InGameQuestAI)
        {
            if (ai != null)
                Destroy(ai.gameObject);
        }
    }
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
