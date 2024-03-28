using PixelCrushers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
                WarAssets.SetActive(false);
                RegularAssets.SetActive(true);
                ChapterOneIcon.SetActive(true);
                ChapterTwoIcon.SetActive(false);
                ChapterThreeIcon.SetActive(false);
            }
            else if (count == 2)
            {
                WarAssets.SetActive(false);
                RegularAssets.SetActive(true);
                ChapterTwoIcon.SetActive(true);
                ChapterOneIcon.SetActive(false);
                ChapterThreeIcon.SetActive(false);
            }
            else if (count == 3)
            {
                ChapterOneIcon.SetActive(false);
                ChapterThreeIcon.SetActive(true);
                ChapterTwoIcon.SetActive(false);
                InGameCharacterStorage.Instance.ThemeMode(true);
                WarAssets.SetActive(true);
                RegularAssets.SetActive(false);
                GameObject.FindGameObjectsWithTag("DisableOnWar").ToList().ForEach(x => x.SetActive(false));
            }
            FindObjectOfType<PressureView>(true).SetAddPerDay();
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
            {
                var pointer = ai.GetComponentInParent<QuestGiverPointer>();
                if (pointer != null)
                {
                    Destroy(pointer.gameObject);
                }
                else
                {
                    Destroy(ai.gameObject);
                }
                    
               
                
            }
            
                
            
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
