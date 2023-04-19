using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using UnityEngine.Experimental.GlobalIllumination;

public class RoitInGameAI : DefaultInGameAI
{
    public RoitSpawnRange spawnRange;
    public float moveSpeed = 1f;
    public float stayDuration = 1.5f;
    public PathPoint startPoint;
    public PathPoint endPoint;
    public bool OnStartPoint = true;

    public override void StartAction()
    {
        DontDestroyOnLoad(gameObject);
    }
    public override void Move()
    {

    }
    public override void SetLocation()
    {
        transform.position = startPoint.transform.position;
    }
    public IEnumerator OnStreetRator()
    {
        bool lost = character.hireStage == HireStage.Defeated;
        while (!lost)
        {
            yield return MakeAMoveRator();
            yield return new WaitForSeconds(stayDuration);
        }
    }
    public IEnumerator MakeAMoveRator()
    {
        PathPoint direction = OnStartPoint ? endPoint : startPoint;
        float time = 0;
        float distance = Vector3.Distance(startPoint.transform.position, endPoint.transform.position);
        float moveDuration = distance / moveSpeed;
        while (time < moveDuration)
        {
            time += Time.deltaTime;
            transform.position = Vector2.Lerp(transform.position, direction.transform.position, time / moveDuration);
            yield return null;
        }
        OnStartPoint = !OnStartPoint;
    }
    public void SetupRoitAI(Character character, RoitSpawnRange spawnRange)
    {
        this.character = character;
        this.spawnRange = spawnRange;
        var path = spawnRange.RequestPath();
        startPoint = path.Item1;
        endPoint = path.Item2;
        SetLocation();
        SetConversationDatabase();
        StartCoroutine(OnStreetRator());
    }
    protected override void StartConmunicate()
    {
        var DSC = FindObjectOfType<DialogueSystemController>();
        DSC.initialDatabase = Resources.Load<DialogueDatabase>($"Conversions/Õ½¶·");
        DSC.Awake();
        npcConversationTriggerGroup.StartGeneral();
    }
    public override void SetConversationDatabase()
    {
        NPCConversationTriggerGroup pref = null;
        switch (spawnRange.Area)
        {
            case 'A':
                pref = Resources.Load<NPCConversationTriggerGroup>("InGameNPC/DialogueTriggersGroup/½Ö°Ô");
                break;
            case 'B':
                pref = Resources.Load<NPCConversationTriggerGroup>("InGameNPC/DialogueTriggersGroup/·ËÍ½");
                break;
            case 'C':
                pref = Resources.Load<NPCConversationTriggerGroup>("InGameNPC/DialogueTriggersGroup/ÌÓÄÑÕß");
                break;
            case 'D':
                pref = Resources.Load<NPCConversationTriggerGroup>("InGameNPC/DialogueTriggersGroup/×íºº");
                break;
        }
        npcConversationTriggerGroup = Instantiate(pref, transform);
        GetComponentInChildren<EventAfterConversation>().EnemyUnitA = character;
    }
}
