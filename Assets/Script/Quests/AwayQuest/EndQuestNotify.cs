using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.QuestMachine;

public class EndQuestNotify : MonoBehaviour
{
    public bool success = true;
    public bool notifyOnEnable = true;
    public Quest questAsset;
    public void OnEnable()
    {
        if (notifyOnEnable)
        {
            Notify();
        }
    }
    public void Notify()
    {
        if (success)
        {
            QuestNotice.ShowQuestFinishConfirm(questAsset.id.ToString(), questAsset.title.ToString());
        }
        else
        {
            QuestNotice.ShowQuestFailConfirm(questAsset.id.ToString(), questAsset.title.ToString());
        }
        Destroy(gameObject);
    }
}
