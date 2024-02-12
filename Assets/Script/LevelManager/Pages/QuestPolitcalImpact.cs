using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPolitcalImpact : MonoBehaviour
{
    public static Dictionary<string, Dictionary<FactionType, string>> QuestInfluenceResult = new Dictionary<string, Dictionary<FactionType, string>>()
    {
        {"S-01-流氓的调戏-c", new Dictionary<FactionType, string>(){{FactionType.九千岁,"你刺杀了其下的一名官员，随然此官员无足轻重但仍旧落了他的面子。@-5"} }},
        {"S-01-赊账-b", new Dictionary<FactionType, string>(){{FactionType.于党,"你贿赂了其下的一名官员，随然此官员无足轻重但仍旧落了他的面子。@-3"} }},
        {"S-01-断梗浮萍-b", new Dictionary<FactionType, string>(){{FactionType.士族门阀,"你贿赂了其下的一名官员，随然此官员无足轻重但仍旧落了他的面子。@-3"} }},
        {"S-01-运输不易-b", new Dictionary<FactionType, string>(){{FactionType.士族门阀,"你贿赂了其下的一名官员，随然此官员无足轻重但仍旧落了他的面子。@-3"} }},
        {"S-01-大儒办学-b", new Dictionary<FactionType, string>(){{FactionType.九千岁,"你贿赂了其下的一名官员，减除了九千岁一片羽翼。@-5"} }},
    };

    public static string resultMessage(string QuestID,FactionType OwnerName)
    {
        if (QuestInfluenceResult.ContainsKey(QuestID))
        {
            return QuestInfluenceResult[QuestID][OwnerName];
        }
        else
            return null;
    } 
}

