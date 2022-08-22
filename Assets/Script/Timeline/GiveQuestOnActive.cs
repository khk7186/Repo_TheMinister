using UnityEngine;
using PixelCrushers;
using PixelCrushers.QuestMachine;

public class GiveQuestOnActive : MonoBehaviour
{
    public Quest questAsset;
    public QuestJournal questJournal;
    void Start()
    {
        questJournal = FindObjectOfType<QuestJournal>();
        // Make a copy of the quest for the quester:
        var questInstance = questAsset.Clone();
        // Add the copy to the quester and activate it:
        var questerTextInfo = new QuestParticipantTextInfo(questJournal.id, questJournal.displayName, questJournal.image, null);
        questInstance.AssignQuester(questerTextInfo);
        questInstance.timesAccepted = 1;
        questJournal.deletedStaticQuests.Remove(StringField.GetStringValue(questInstance.id));
        questJournal.AddQuest(questInstance);
        questInstance.SetState(QuestState.Active);
        QuestMachineMessages.RefreshUIs(questInstance);
        QuestNotice.ShowQuestConfirm(questAsset.id.ToString(), questAsset.title.ToString());
    }
}