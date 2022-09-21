using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestNotice : MonoBehaviour
{
    public Text text;
    public static void ShowQuestConfirm(string QuestID,string QuestName)
    {
        QuestNotice target = FindObjectOfType<QuestNotice>(true);
        target.gameObject.SetActive(true);
        string type = QuestID[0] == 'M'? "主线":"支线";
        target.text.text =$"{type}任务：<color=#FF0000>{QuestName}</color>" ;
        Debug.Log("ShowQuestConfirm");
    }
}
