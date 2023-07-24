using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

[CreateAssetMenu(fileName = "SubQuestDatabase", menuName = "ScriptableObjects/SubQuestDB", order = 5)]
[Serializable]
public class SOSubQuestDB : ScriptableObject
{
    public List<QUEST_GIVER_BY_ORDER> QUEST_GIVER_BY_ORDER;
    public QuestChainStateWrap ORIGIN;
    public QuestChainStateWrap CURRENT;

    public void NewCurrent()
    {
        CURRENT = (QuestChainStateWrap)ORIGIN.Clone();
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
