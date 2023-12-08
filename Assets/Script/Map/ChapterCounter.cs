using PixelCrushers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterCounter : MonoBehaviour
{
    public static ChapterCounter Instance;
    public GameObject WarAssets;
    public GameObject RegularAssets;
    public GameObject ChapterOneIcon;
    public GameObject ChapterTwoIcon;
    public GameObject ChapterThreeIcon;
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
            if (count == 1)
            {
                ChapterOneIcon.SetActive(true);
            }
            else if (count == 2)
            {
                ChapterTwoIcon.SetActive(true);
                ChapterOneIcon.SetActive(false);
            }
            else if (count == 3)
            {
                RegularAssets.SetActive(false);
                WarAssets.SetActive(true);
                ChapterThreeIcon.SetActive(true);
                ChapterTwoIcon.SetActive(false);
            }
            LastChapterAIExitGame();
            QuestAIManager.Instance.CloneList();
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
                Destroy(ai.GetComponentInParent<QuestGiverPointer>().gameObject);
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
