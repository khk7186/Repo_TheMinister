using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class EventAfterConversation : MonoBehaviour
{
    public List<Character> charactersForCombats = new List<Character>();
    public Character EnemyUnitA;
    public Character[] EnemyUnitACardList = new Character[] { };
    public Character EnemyUnitB;
    public Character[] EnemyUnitBCardList = new Character[] { };
    public Character EnemyUnitC;
    public Character[] EnemyUnitCCardList = new Character[] { };
    //public void OnConversationEnd()
    //{
    //    TryCombat();
    //}

    public void TryCombat()
    {
        //{character.characterArtCode}
        bool startCombat = DialogueLua.GetVariable("startCombat").asBool;
        //Debug.Log(startCombat);
        if (startCombat)
        {
            var Trigger = new GameObject().AddComponent<GeneralEventTrigger>();
            Trigger.battleType = BattleType.Combat;
            Trigger.enemyCharacters = charactersForCombats;
            Trigger.TriggerEvent();
            //Debug.Log(startCombat);
        }
    }

    public void TryDebate()
    {
        bool startDebate = DialogueLua.GetVariable("startDebate").asBool;
        if (startDebate)
        {
            var Trigger = new GameObject().AddComponent<GeneralEventTrigger>();
            Trigger.battleType = BattleType.Debate;
            Trigger.enemyCharacters = new List<Character>() { EnemyUnitA, EnemyUnitB, EnemyUnitC };
            Trigger.enemyCharactersCardsList = new List<Character[]>() { EnemyUnitACardList, EnemyUnitBCardList, EnemyUnitCCardList };
            Trigger.TriggerEvent();
        }
    }
}
