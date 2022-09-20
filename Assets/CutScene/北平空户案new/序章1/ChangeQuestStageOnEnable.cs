using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.QuestMachine;

public class ChangeQuestStageOnEnable : MonoBehaviour
{
    [System.Serializable]
    public struct ChangeQuestStruct
    {
        public string QuestID;
        public string QuestNode;
        public QuestNodeState questNodeState;
    }
    public List<ChangeQuestStruct> changeQuestStructs;

    public void Awake()
    {
        foreach (ChangeQuestStruct changeQuestStruct in changeQuestStructs)
        {
            QuestMachine.SetQuestNodeState(changeQuestStruct.QuestID, changeQuestStruct.QuestNode, changeQuestStruct.questNodeState);
        }
        Destroy(gameObject);
    }
}
