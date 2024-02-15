using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestChainUpdate : MonoBehaviour
{
    public string questChainName;
    public void QuestChainContinue(string questChainName)
    {
        var target = QuestAIManager.Instance.subQuestDB.CURRENT.questChainStates;
        foreach (QuestChainState chainState in target)
        {
            if(chainState.QuestChainName == questChainName)
            {
                chainState.QuestChainOrder++;
            }
        }
        
    }

    public void OnEnable()
    {
        QuestChainContinue(questChainName);
 
    }




}
