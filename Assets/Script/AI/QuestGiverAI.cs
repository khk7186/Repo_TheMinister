using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.QuestMachine;
using PixelCrushers.DialogueSystem;


public class QuestGiverAI : MonoBehaviour
{
    public string QuestID;
    public Character character;
    public NPCConversationTriggerGroup npcConversationTriggerGroup;
    public Grid movementGrid;
    public int blockStay;
    public bool inner = true;
    private void Awake()
    {
        movementGrid = FindObjectOfType<MovementGrid>().GetComponent<Grid>();
        inner = Random.Range(0, 2) == 0 ? false : true;
        //foreach (var subject in FindObjectsOfType<MonoBehaviour>().OfType<ISubject>())
        //{
        //    subject.RegisterObserver(this);
        //}
    }
    protected void StartConmunicate()
    {
        var DSC = FindObjectOfType<DialogueSystemController>();
        DSC.initialDatabase = Resources.Load<DialogueDatabase>($"Conversions/任务");
        DSC.Awake();
        npcConversationTriggerGroup.StartGeneral();
    }
    public void SetConversationDatabase()
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
    protected void OnMouseDown()
    {
        var DSC = FindObjectOfType<DialogueSystemController>();
        DSC.initialDatabase = Resources.Load<DialogueDatabase>($"Conversions/任务");
        DSC.Awake();
        GetComponentInChildren<QuestGiver>().StartDialogueWithPlayer();
    }
}
