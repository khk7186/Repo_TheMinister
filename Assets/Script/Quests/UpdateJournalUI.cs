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
        UpdateJournal();
        //LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }
    public void UpdateJournal()
    {
        QuestJournal questJournal = FindObjectOfType<QuestJournal>();
        if (questJournal == null)
        {
            NoQuest.GetComponent<Text>().text = "Journal Not Found";
        }
        NoQuest.GetComponent<Text>().text = $"{questJournal.questList.Count} Quest";
        if (journalUI.activeQuestNameTemplate == null)
        {
            NoTemplete.gameObject.SetActive(true);
        }
        if (journalUI.questSelectionContentContainer.childCount == 0 && questJournal.questList.Count > 0)
            journalUI.Repaint();
    }
}
