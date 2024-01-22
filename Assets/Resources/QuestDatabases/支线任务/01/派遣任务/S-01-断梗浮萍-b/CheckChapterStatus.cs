using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.QuestMachine;

public class CheckChapterStatus : MonoBehaviour
{

    // Start is called before the first frame update

    public string QuestID;
    public string questNode;
    public QuestNodeState questNodeState;
    public int chapter;



    // Update is called once per frame
    public void OnEnable()
    {
        Debug.Log(ChapterCounter.Instance.Chapter);
        CheckAndChangeQuestStage();
        Destroy(gameObject);

    }

    public void CheckAndChangeQuestStage()
    {
        if (ChapterCounter.Instance.Chapter >= chapter) 
        {
            Quest quest = QuestMachine.GetQuestInstance(QuestID);

            // Check if the quest exists
            if (quest != null)
            {
                // Change the quest stage to failure
                QuestMachine.SetQuestNodeState(QuestID, questNode, questNodeState);
                QuestAIManager.Instance?.QuestCountMinus();
            }
        }
    }
}
  


