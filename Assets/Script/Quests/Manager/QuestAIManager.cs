using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class QuestAIManager : MonoBehaviour, IDiceRollEvent
{
    public static QuestAIManager Instance;
    public ChapterCounter chapterCounter => ChapterCounter.Instance;
    public SOSubQuestDB subQuestDB;
    public string CurrentSave = string.Empty;
    public QUEST_GIVER_BY_ORDER CurrentQuestList => subQuestDB.QUEST_GIVER_BY_ORDER[chapterCounter.Chapter];
    public List<QuestGiverAI> InactiveQuestGivers;
    private int inGameQuestCount = 0;
    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            Dice.Instance.RegisterObserver(this);
        }
        else
        {
            Destroy(this);
        }
        if (subQuestDB != null)
        {
            if (subQuestDB.CurrentSave != CurrentSave) subQuestDB.NewCurrent(CurrentSave);
            CloneList();
        }
    }
    public void QuestCountAdd()
    {
        inGameQuestCount++;
    }
    public void QuestCountMinus()
    {
        inGameQuestCount--;
    }
    public void QuestCountZero()
    {
        inGameQuestCount = 0;
    }
    public void TryActiveNextQuest()
    {
        if (inGameQuestCount < 7)
            ActiveNextQuest();
    }

    public void ActiveNextQuest()
    {
        if (InactiveQuestGivers == null || InactiveQuestGivers.Count == 0) return;
        QuestGiverAI spawnAI = null;
        for (int i = 0; i < InactiveQuestGivers.Count; i++)
        {
            var target = InactiveQuestGivers[i];
            Func<bool> SingleQuest = () => target.QuestChainName == string.Empty;
            Func<bool> InOrderChainQuest = () => target.QuestChainOrder == subQuestDB.CurrentQuestChainOrder(target.QuestChainName);
            if (SingleQuest.Invoke())
            {
                spawnAI = target;
                break;
            }
            else if (InOrderChainQuest.Invoke())
            {
                spawnAI = target;
                break;
            }
        }
        if (spawnAI != null)
        {
            var spawnedClone = Instantiate(spawnAI);
            InactiveQuestGivers.Remove(spawnAI);
            QuestCountAdd();
        }
    }
    public void CloneList()
    {
        InactiveQuestGivers = CurrentQuestList.questGivers;
    }
    public void Save()
    {

    }
    public void OnNotify(object value, NotificationType notificationType)
    {
        TryActiveNextQuest();
    }
}
