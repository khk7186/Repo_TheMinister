using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestStateNotice : MonoBehaviour
{
    public Text text; 
    public static void ShowQuestStage(string QuestID, string QuestName, bool success)
    {
        QuestNotice target = FindObjectOfType<QuestNotice>(true);
        target.gameObject.SetActive(true);
        string type = QuestID[0] == 'M' ? "主线" : "支线";
        string state = success ? "已完成" : "已失败";
        string color = success ? "60FF45":"FF0000";
        target.text.text = $"{type}任务:{QuestName}<color=#{color}>{state}</color>";
    }
}
