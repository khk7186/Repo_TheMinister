using PixelCrushers.QuestMachine;
using PixelCrushers.QuestMachine.Wrappers;
using SaveSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class QuestAIManager : MonoBehaviour, IDiceRollEvent
{
    public static QuestAIManager Instance;
    public ChapterCounter chapterCounter => ChapterCounter.Instance;
    public SOSubQuestDB subQuestDB;
    public string CurrentSave = string.Empty;
    public QUEST_GIVER_BY_ORDER CurrentQuestList => subQuestDB.QUEST_GIVER_BY_ORDER[chapterCounter.Chapter];
    public List<QuestGiverAI> InactiveQuestGivers = new List<QuestGiverAI>();
    public List<QuestGiverAI> ActiveQuestsGivers = new List<QuestGiverAI>();
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
        QuestGiverAI targetQuestGiver = null;
        if (spawnAI != null)
        {
            if (spawnAI.QuestSpawnPref != null)
            {
                var clone = Instantiate(spawnAI.QuestSpawnPref, transform);
                targetQuestGiver = clone.GetComponentInChildren<QuestGiverAI>();
            }
            else
            {
                targetQuestGiver = Instantiate(spawnAI, transform);
            }
            InactiveQuestGivers.Remove(spawnAI);
            ActiveQuestsGivers.Add(targetQuestGiver);
            QuestCountAdd();
        }
    }
    public void CloneList()
    {
        InactiveQuestGivers = new List<QuestGiverAI>(CurrentQuestList.questGivers);
    }
    public void Reset()
    {
        foreach (var aqg in ActiveQuestsGivers)
        {
            if (aqg != null)
                Destroy(aqg.transform.parent.gameObject);
        }
    }
    public void Save(GameSave gameSave)
    {
        //save quest chain states
        gameSave.questChainStateWrapper = subQuestDB.CURRENT.Clone() as QuestChainStateWrap;
        //gameSave.InactiveQuestGivers = InactiveQuestGivers;

        //save quest current states and showed quest gameobjects.
        foreach (var questGiver in ActiveQuestsGivers)
        {
            if (questGiver.triggered)
            {
                //gameSave.TriggeredQuestGivers.Add
                //    (CurrentQuestList.questGivers.Find(x => x.QuestID == questGiver.QuestID));
                gameSave.TriggeredQuestGiverID.Add(questGiver.QuestID);
            }
            else
            {
                //gameSave.UntriggeredQuestGivers.Add
                //    (CurrentQuestList.questGivers.Find(x => x.QuestID == questGiver.QuestID));
                gameSave.UntriggeredQuestGiverID.Add(questGiver.QuestID);
            }
        }
    }

    public void Load(GameSave gameSave)
    {
        subQuestDB.CURRENT = gameSave.questChainStateWrapper;
        var originInactive = subQuestDB.QUEST_GIVER_BY_ORDER[gameSave.chapter].questGivers.Where(x => gameSave.InactiveQuestGiverID.Contains(x.QuestID));
        InactiveQuestGivers = new List<QuestGiverAI>(originInactive);

        ActiveQuestsGivers = new List<QuestGiverAI>();

        var untriggereds = subQuestDB.QUEST_GIVER_BY_ORDER[gameSave.chapter].questGivers.Where(x => gameSave.UntriggeredQuestGiverID.Contains(x.QuestID));
        foreach (var untriggered in untriggereds)
        {
            var clone = Instantiate(untriggered.QuestSpawnPref, transform);
            ActiveQuestsGivers.Add(clone.GetComponent<QuestGiverPointer>().questGiverAI);
        }

        var triggereds = subQuestDB.QUEST_GIVER_BY_ORDER[gameSave.chapter].questGivers.Where(x => gameSave.TriggeredQuestGiverID.Contains(x.QuestID));
        foreach (var triggered in triggereds)
        {
            var clone = Instantiate(triggered.ReloadPref, transform);
            ActiveQuestsGivers.Add(clone.GetComponent<QuestGiverPointer>().questGiverAI);
        }
    }
    public void OnNotify(object value, NotificationType notificationType)
    {
        TryActiveNextQuest();
    }
}
