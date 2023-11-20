using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestNotice : MonoBehaviour
{
    public Text text;
    private static string reciveQuestTitle = "<size=30>正在进行</size>\n";
    private static string finishQuestTitle = "<size=30>成功完成</size>\n";
    private static string failQuestTitle = "<size=30>未能完成</size>\n";
    public static void ShowQuestConfirm(string QuestID, string QuestName)
    {
        QuestNotice target = FindObjectOfType<QuestNotice>(true);
        target.gameObject.SetActive(true);
        string type = QuestID[0] == 'M' ? "主线" : "支线";
        target.text.text = $"{reciveQuestTitle}{type}任务：<color=#4F3C34>{QuestName}</color>";
    }
    public static void ShowQuestFinishConfirm(string QuestID, string QuestName)
    {
        QuestNotice target = FindObjectOfType<QuestNotice>(true);
        target.gameObject.SetActive(true);
        string type = QuestID[0] == 'M' ? "主线" : "支线";
        target.text.text = $"{finishQuestTitle}{type}任务：<color=#234619>{QuestName}</color>";
    }    
    public static void ShowQuestFailConfirm(string QuestID, string QuestName)
    {
        QuestNotice target = FindObjectOfType<QuestNotice>(true);
        target.gameObject.SetActive(true);
        string type = QuestID[0] == 'M' ? "主线" : "支线";
        target.text.text = $"{failQuestTitle}{type}任务：<color=#B01717>{QuestName}</color>";
    }
}
