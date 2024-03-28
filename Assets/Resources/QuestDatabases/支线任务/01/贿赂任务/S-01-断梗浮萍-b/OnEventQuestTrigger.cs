using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class OnEventQuestTrigger : MonoBehaviour
{
    public bool TriggerOn = false;
    public string questID = string.Empty;
    public QuestAIManager questAIManager => QuestAIManager.Instance;
    public SOSubQuestDB subQuestDB;

    public void OnEnable()
    {
        Trigger();

    }

    public void Trigger()
    {
        var group = subQuestDB.QUEST_GIVER_BY_ORDER[ChapterCounter.Instance.Chapter].questGivers;
        if(TriggerOn == true)
        {
            var targetList = questAIManager.OnEventQuestGivers;
            targetList.Add(group.Find(x => x.QuestID == questID));
            
        }
        else
        {
           var target = questAIManager.OnEventQuestGivers.Find(x => x.QuestID == questID);
            if (target != null)
            {
                questAIManager.OnEventQuestGivers.Remove(target);
            }
        }
    }
}
