using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using UnityEngine.Experimental.GlobalIllumination;
using System;
using System.Linq;
using UnityEngine.Events;

public class RoitInGameAI : DefaultInGameAI
{
    public RoitSpawnRange spawnRange;
    public float moveSpeed = 9f;
    public float stayDuration = 1.5f;
    public PathPoint startPoint;
    public PathPoint endPoint;
    public bool OnStartPoint = true;
    public bool robbed = false;
    public RobbingTriggerGroup robbingTriggerGroup;

    public override void StartAction()
    {
        GetComponent<CharacterMovement>().modelController.SetSkin("face-angry expression");
    }
    public override void Move()
    {

    }
    //private void OnEnable()
    //{
    //    if (character != null)
    //    {
    //        if (character.hireStage == HireStage.Defeated)
    //        {
    //            StopAllCoroutines();
    //            GetComponent<CharacterMovement>().ModelDieAnimation();
    //        }
    //    }
    //}
    public override void SetLocation()
    {
        try
        {

            transform.position = startPoint.transform.position;
        }
        catch (NullReferenceException)
        {
            Debug.Log(transform == null);
            Debug.Log(startPoint.transform.position);

        }
    }
    public IEnumerator OnStreetRator()
    {
        bool lost = character.hireStage == HireStage.Defeated;
        while (!lost)
        {
            yield return MakeAMoveRator();

            yield return StopAndLaugh();
        }
    }
    public IEnumerator StopAndLaugh()
    {
        CharacterModelController controller = GetComponent<CharacterModelController>();
        controller.SetTrigger("Attack");
        controller.SetSkin("face-angry expression");
        yield return new WaitForSeconds(stayDuration);
    }
    public IEnumerator MakeAMoveRator()
    {
        CharacterModelController controller = GetComponent<CharacterModelController>();
        controller.SetSkin("face-normal expression");
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
        if (spawnRange != null)
        {
            this.spawnRange = spawnRange;
            var path = spawnRange.RequestPath();
            startPoint = path.Item1;
            endPoint = path.Item2;
            SetLocation();
            SetConversationDatabase();
            StartCoroutine(OnStreetRator());
        }
        GetComponentInChildren<IndicatorController>().ChangeSelected("attack");
    }
    protected override void StartConmunicate()
    {
        var ready = AbleToCombat.CheckingForDuty(BattleType.Combat);
        var DSC = FindObjectOfType<DialogueSystemController>();
        DSC.initialDatabase = Resources.Load<DialogueDatabase>($"Conversions/Õ½¶·");
        DSC.Awake();
        if (ready == true)
        {
            npcConversationTriggerGroup.StartGeneral();
        }
        else
        {
            if (robbed == true)
            {
                robbingTriggerGroup?.afterRobbing.OnUse();
            }
            else
            {
                robbingTriggerGroup?.beforeRobbing.OnUse();
                robbed = true;
            }
        }
    }
    public override void SetConversationDatabase()
    {
        //NPCConversationTriggerGroup pref = null;
        //switch (spawnRange.Area)
        //{
        //    case 'A':
        //        pref = Resources.Load<NPCConversationTriggerGroup>("InGameNPC/DialogueTriggersGroup/½Ö°Ô");
        //        break;
        //    case 'B':
        //        pref = Resources.Load<NPCConversationTriggerGroup>("InGameNPC/DialogueTriggersGroup/Ç¿µÁ");
        //        break;
        //    case 'C':
        //        pref = Resources.Load<NPCConversationTriggerGroup>("InGameNPC/DialogueTriggersGroup/ÌÓÄÑÕß");
        //        break;
        //    case 'D':
        //        pref = Resources.Load<NPCConversationTriggerGroup>("InGameNPC/DialogueTriggersGroup/×íºº");
        //        break;
        //}
        //npcConversationTriggerGroup = Instantiate(pref, transform);
        GetComponentInChildren<EventAfterConversation>().EnemyUnitA = character;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    var ai = collision.gameObject.GetComponent<DefaultInGameAI>();
    //    if (ai == null) return;
    //    bool canBeKilled = ai.character.characterType == CharacterType.General;
    //    if (canBeKilled)
    //    {
    //        ai.PlayDeathAnimation();
    //    }
    //}
    public DefaultInGameAI DefaultAIAround()
    {
        var list = Physics2D.OverlapCircleAll(transform.position, 10);
        var target = list.FirstOrDefault(x =>
                                                            (x.gameObject.GetComponent<DefaultInGameAI>() != null)
                                                                && (x.GetComponent<RoitInGameAI>() == null));
        if (target == null) return null;
        return target.GetComponent<DefaultInGameAI>();
    }
    public void DeathAction()
    {
        StopAllCoroutines();
        GetComponentInChildren<IndicatorController>().ChangeSelected("hire");
        GetComponent<CharacterMovement>().modelController.SetSkin("face-crying expression");
        RegularQuestEventHandler.KillAddMessage();
    }
}
