using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SubQuestDatabase", menuName = "ScriptableObjects/SubQuestDB", order = 5)]
[Serializable]
public class SOSubQuestDB : ScriptableObject
{
    public List<QUEST_GIVER_BY_ORDER> QUEST_GIVER_BY_ORDER;
    public QuestChainStateWrap ORIGIN;
    public QuestChainStateWrap CURRENT;
    public string CurrentSave = string.Empty;


    public void NewCurrent(string currentSaveName)
    {
        NewCurrent();
        CurrentSave = currentSaveName;
    }
    public void NewCurrent()
    {
        CURRENT = new QuestChainStateWrap() ;
        foreach (QuestChainState chainState in ORIGIN.questChainStates)
        {
            QuestChainState newChainState = new QuestChainState();
            newChainState.QuestChainName = chainState.QuestChainName;
            newChainState.QuestChainOrder = chainState.QuestChainOrder;
            CURRENT.questChainStates.Add(newChainState);
        }
    }

    public int CurrentQuestChainOrder(string questChainName)
    {
        foreach (QuestChainState chainState in CURRENT.questChainStates)
        {
            if (chainState.QuestChainName == questChainName)
            {
                return chainState.QuestChainOrder;
            }
        }
        return 0;
    }
}
[Serializable]
public class QuestChainStateWrap : ICloneable
{
    public List<QuestChainState> questChainStates;

    public object Clone()
    {
        return this.MemberwiseClone();
    }
}
[Serializable]
public class QuestChainState
{
    public string QuestChainName = string.Empty;
    public int QuestChainOrder = 0;
}
[Serializable]
public class QUEST_GIVER_BY_ORDER
{
    public List<QuestGiverAI> questGivers;
}
