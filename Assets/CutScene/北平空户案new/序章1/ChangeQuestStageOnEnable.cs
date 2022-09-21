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
        public string questNode;
        public QuestNodeState questNodeState;
    }
    public List<ChangeQuestStruct> changeQuestStructs;

    public void Awake()
    {
        ChangeStage();
        Destroy(gameObject);
    }
    public void ChangeStage()
    {
        foreach (ChangeQuestStruct changeQuestStruct in changeQuestStructs)
        {
            QuestMachine.SetQuestNodeState(changeQuestStruct.QuestID, changeQuestStruct.questNode, changeQuestStruct.questNodeState);
            if (changeQuestStruct.questNode == "Ê§°Ü"|| changeQuestStruct.questNode == "³É¹¦")
            {
                var asset = QuestMachine.GetQuestInstance(changeQuestStruct.QuestID);
                Debug.Log(asset.id);
                QuestStateNotice.ShowQuestStage
                    (asset.id.ToString()
                    , asset.title.ToString()
                    , asset.GetState() == QuestState.Successful);
            }
        }
        
    }
}
