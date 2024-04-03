using PixelCrushers.QuestMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateJournalUI : MonoBehaviour
{
    public UnityUIQuestJournalUI journalUI;
    public GameObject NoTemplete;
    public GameObject NoQuest;

    private void OnEnable()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
        UpdateJournal();
    }
    public void UpdateJournal()
    {
        QuestJournal questJournal = FindObjectOfType<QuestJournal>();
        if (journalUI.questSelectionContentContainer.childCount == 0 && questJournal.questList.Count > 0)
            journalUI.Repaint();
    }
}
