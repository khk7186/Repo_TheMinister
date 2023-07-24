using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCountHandler : MonoBehaviour
{
    public void QuestCountAdd()
    {
        QuestAIManager.Instance.QuestCountAdd();
    }
    public void QuestCountMinus()
    {
        QuestAIManager.Instance.QuestCountMinus();
    }
    public static void QuestCountZero()
    {
        QuestAIManager.Instance.QuestCountZero();
    }
}
