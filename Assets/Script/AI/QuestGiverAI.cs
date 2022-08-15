using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.QuestMachine;
using PixelCrushers.DialogueSystem;


public class QuestGiverAI : DefaultInGameAI
{
    public string QuestID;
    protected override void StartConmunicate()
    {
        var DSC = FindObjectOfType<DialogueSystemController>();
        DSC.initialDatabase = Resources.Load<DialogueDatabase>($"Conversions/ÈÎÎñ");
        DSC.Awake();
        npcConversationTriggerGroup.StartGeneral();
    }
    public override void SetConversationDatabase()
    {
        var pref = Resources.Load<NPCConversationTriggerGroup>
            ($"{ReturnAssetPath.ReturnNPCConversationTriggerGroupPath(character.characterArtCode.ToString())}");
        npcConversationTriggerGroup = Instantiate<NPCConversationTriggerGroup>(pref, transform);
        GetComponentInChildren<EventAfterConversation>().EnemyUnitA = character;
    }
    public void Setup(string QuestID)
    {
        if (QuestID[-1] == 'f')
        {
            QuestID = QuestID.Remove(QuestID.Length - 1);
        }
    }
}
