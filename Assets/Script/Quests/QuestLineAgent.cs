using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public enum QuestType
{
    MainQuest,
    ShopQuest,
    SideQuest,
    StreetQuest
}

public enum QuestLine
{
    //Main
    Ì«²Öºþ,

    //Shop


    //Side


    //Street

}

public class QuestLineAgent : MonoBehaviour
{
    private string rootPath = "AllQuests/";
    public QuestType questType;
    public int currentQuestOrder = 0;
    public QuestLine questLine;

    private string destinationPath;
    public Quest currenQuestOnLine
    {
        get
        {
            SetUp();
            string QuestFinalPath = 
                (
                destinationPath 
                + currentQuestOrder 
                + "Q" + questLine.ToString() 
                + currentQuestOrder
                )
                .Replace(" ", string.Empty);
            string FieldFinalPath =
                (
                destinationPath
                + currentQuestOrder
                + "F" + questLine.ToString()
                + currentQuestOrder
                )
                .Replace(" ", string.Empty);
            Quest thisQuest = Resources.Load<Quest>(QuestFinalPath);
            QuestField thisQuestField = Resources.Load<QuestField>(FieldFinalPath);
            thisQuest.questField = thisQuestField;
            return thisQuest;
        }
    }

    private void SetUp()
    {
        destinationPath = rootPath + questType.ToString() + "/"+ questLine.ToString() + "/";
    }

    public void Next()
    {
        currentQuestOrder++;
    }

}
