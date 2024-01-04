using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestStepMessage : MonoBehaviour
{
    public string QuestID;
    public int Node;

    public static Dictionary<string, List<string>> NodeMessages = new Dictionary<string, List<string>>()
    {
        {"S-01-偷吃贡品-a", new List<string>()
            {
                "前往白云寺。",
                "前往白云寺。",
                "在佛堂中放置贡品。",
                "在暗处等待窃贼。",
                "在暗处等待窃贼。",
                "在抓捕窃贼。"

            }
        },
        {"S-01-医闹-a", new List<string>()
            {
                "观察病患舌苔。",
                "观察病患舌苔。",
                "观察病患面色。",
                "观察病患面色。",
                "给病患搭脉。",
                "给病患搭脉。",
                "书写治疗病患的药方。",
                "给病患抓药。",
                "给病患抓药。",

            }
        },
    };

    public string AppointMessage()
    {
        return NodeMessages[QuestID][Node];

    }

}
