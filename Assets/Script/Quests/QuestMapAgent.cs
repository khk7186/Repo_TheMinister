using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MainCharacterName
{
    »ÊµÛ,
    Ô×Ïà,
    Ì«¼à,
    ½«¾ü
}

public class QuestMapAgent : MonoBehaviour
{
    public static Dictionary<MainCharacterName, List<QuestLineAgent>> MainQuestMap
        = new Dictionary<MainCharacterName, List<QuestLineAgent>>()
        {
            { MainCharacterName.»ÊµÛ,
                new  List<QuestLineAgent>
                {
                    new QuestLineAgent(QuestType.MainQuest, QuestLine.Ì«²Öºþ)
                } 
            }
        };

    public static Dictionary<BuildingType, List<QuestLineAgent>> ShopQuestMap
        = new Dictionary<BuildingType, List<QuestLineAgent>>()
        {
            {
                BuildingType.Âí¾Ç,
                new List<QuestLineAgent>
                {
                    new QuestLineAgent(QuestType.MainQuest, QuestLine.Ì«²Öºþ)
                }
            }
        };


    public QuestLineAgent LoadShopQuest(BuildingType buildingType)
    {
        var AvailableQuestList = ShopQuestMap[buildingType];
        var outPutQuestLine = CatchNotInUseQuest(AvailableQuestList);
        outPutQuestLine.InUse = true;
        return outPutQuestLine;
    }

    
    public QuestLineAgent CatchNotInUseQuest(List<QuestLineAgent> questLineAgents)
    {
        int index = Random.Range(0, questLineAgents.Count);
        var outPutQuestLine = questLineAgents[index];
        if (outPutQuestLine.InUse)
        {
            var newQuestLineAgents = questLineAgents;
            newQuestLineAgents.RemoveAt(index);
            return CatchNotInUseQuest(newQuestLineAgents);
        }
        return outPutQuestLine;
    }

    
}
