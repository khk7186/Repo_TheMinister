using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using System;
using System.Linq;
using PixelCrushers.DialogueSystem.Wrappers;

public class EventAfterConversation : MonoBehaviour
{
    public Character EnemyUnitA;
    public Character[] EnemyUnitACardList = new Character[] { };
    public Character EnemyUnitB;
    public Character[] EnemyUnitBCardList = new Character[] { };
    public Character EnemyUnitC;
    public Character[] EnemyUnitCCardList = new Character[] { };
    public DebateTopicCode[] debateTopics;

    public GeneralEventTrigger Trigger;
    public PixelCrushers.DialogueSystem.DialogueSystemTrigger roitHire;
    public void TryCombat()
    {
        //{character.characterArtCode}
        bool startCombat = EnemyUnitA.characterType == CharacterType.Roit || DialogueLua.GetVariable("startCombat").asBool;
        //Debug.Log(startCombat);
        if (startCombat)
        {
            Trigger = new GameObject().AddComponent<GeneralEventTrigger>();
            Trigger.battleType = BattleType.Combat;
            Trigger.enemyCharacters.Add(EnemyUnitA);
            if (EnemyUnitB != null)
            {
                Trigger.enemyCharacters.Add(EnemyUnitB);
            }
            if (EnemyUnitC != null)
            {
                Trigger.enemyCharacters.Add(EnemyUnitC);
            }
            Trigger.TriggerEvent();
            //Debug.Log(startCombat);
        }
        else
        {
            DialogueLua.SetVariable("tryCombat", false);
        }
    }

    public void TryDebate()
    {
        bool startDebate = DialogueLua.GetVariable("startDebate").asBool;
        //bool startDebate = true;
        if (startDebate)
        {
            DebateTopicPool topicPool = new GameObject().AddComponent<DebateTopicPool>();
            foreach (var topic in debateTopics)
            {
                var newTopic = new DebateTopic();
                newTopic.Setup(topic);
                topicPool.topics.Add(newTopic);
            }
            Trigger = new GameObject().AddComponent<GeneralEventTrigger>();
            Trigger.battleType = BattleType.Debate;
            var EnemyCharactersCardsList = new List<Character[]>();
            if (EnemyUnitA != null)
            {
                var EnemyADebateList = new List<Character>();
                EnemyADebateList.Add(EnemyUnitA);
                EnemyADebateList.AddRange(CharacterSpawnPool.CharacterSpawnPoolDict[EnemyUnitA.characterArtCode][Trigger.battleType]);
                EnemyCharactersCardsList.Add(EnemyADebateList.ToArray());
            }
            if (EnemyUnitB != null)
            {
                var EnemyBDebateList = new List<Character>();
                EnemyBDebateList.Add(EnemyUnitB);
                EnemyBDebateList.AddRange(CharacterSpawnPool.CharacterSpawnPoolDict[EnemyUnitB.characterArtCode][Trigger.battleType]);
                EnemyCharactersCardsList.Add(EnemyBDebateList.ToArray());
            }
            if (EnemyUnitC != null)
            {
                var EnemyCDebateList = new List<Character>();
                EnemyCDebateList.Add(EnemyUnitC);
                EnemyCDebateList.AddRange(CharacterSpawnPool.CharacterSpawnPoolDict[EnemyUnitC.characterArtCode][Trigger.battleType]);
                EnemyCharactersCardsList.Add(EnemyCDebateList.ToArray());
            }
            Trigger.enemyCharactersCardsList = EnemyCharactersCardsList;
            Trigger.TriggerEvent();
        }
        else
        {
            DialogueLua.SetVariable("tryDebate", false);
        }
    }

    public void TryHire()
    {
        bool startHire = DialogueLua.GetVariable("startHire").asBool;
        //bool startHire = true;
        if (startHire)
        {
            CharacterHiringEvent hireEvent = new GameObject().AddComponent<CharacterHiringEvent>();
            hireEvent.character = EnemyUnitA;
            hireEvent.StartHiring();
        }
        else
        {
            DialogueLua.SetVariable("tryHire", false);
        }
    }

    internal void ChangeConversation()
    {
        Debug.Log(EnemyUnitA.hireStage);
        bool result = EnemyUnitA.hireStage == HireStage.Defeated;
        if (EnemyUnitA.characterType == CharacterType.Roit)
        {
            if (result)
            {
                EnemyUnitA.InGameAI.GetComponent<IndicatorController>().ChangeSelected("hire");
                var target = GetComponent<NPCConversationTriggerGroup>();
                target.General = roitHire;
            }
        }
    }
}


