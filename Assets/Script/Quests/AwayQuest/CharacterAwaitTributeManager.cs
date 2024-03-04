using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class CharacterAwaitTributeManager : MonoBehaviour, IDiceRollEvent
{
    public static CharacterAwaitTributeManager Instance;
    public List<CharacterAwaitTribute> UnfinishedTributes = new List<CharacterAwaitTribute>();
    public CharacterAwaitTribute awaitTributePrefab;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            awaitTributePrefab.gameObject.SetActive(false);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        Dice.Instance?.RegisterObserver(this);
    }
    public CharacterAwaitTribute AddTribute(Character character, int WaitTime, bool auto, string questID = "")
    {
        var tribute = Instantiate(awaitTributePrefab, transform);
        tribute.gameObject.SetActive(true);
        tribute.character = character;
        tribute.WaitTime = WaitTime;
        UnfinishedTributes.Add(tribute); 
        tribute.QuestID = questID;
        if (character.OnAssassinEvent == false)
        {
            if (questID != "")
            {
                GeneralTrackingViewManager.Instance.PushTracker(character, character.CharacterName, StepMessage.AppointMessage(questID, WaitTime), WaitTime, auto);
            }
            else
            {
                GeneralTrackingViewManager.Instance.PushTracker(character, character.CharacterName, "任务信息系统", WaitTime, auto);
            }
        }
        else
        {
            var view = GeneralTrackingViewManager.Instance.PushTracker(character, character.AssasinTarget, StepMessage.AssassinStepMessage(), WaitTime, false);
            view.assassinEvent = PoliticSystemManager.FindEventByAssassin(character);
        }
        return tribute;
    }
    public void OnNotify(object value, NotificationType notificationType)
    {
        List<CharacterAwaitTribute> toDestroy = new List<CharacterAwaitTribute>();
        for (int i = 0; i < UnfinishedTributes.Count; i++)
        {
            if (UnfinishedTributes[i] != null)
                UnfinishedTributes[i].TimePlus();
            if (UnfinishedTributes[i].destroyNext)
            {
                toDestroy.Add(UnfinishedTributes[i]);
            }
        }
        if (toDestroy.Count > 0) { DestroyAfterSec(toDestroy); }
    }
    public void DestroyAfterSec(List<CharacterAwaitTribute> toDestroy)
    {
        if (toDestroy.Where(x => x != null).Count() >= 0)
        {
            foreach (var tribute in toDestroy)
            {
                if (tribute != null)
                {
                    Destroy(tribute.gameObject);
                }
            }
            UnfinishedTributes.RemoveAll(x => x == null);
        }
    }
    public void Reset()
    {
        foreach (var tribute in UnfinishedTributes)
        {
            if (tribute != null)
                Destroy(tribute.gameObject);
        }
        UnfinishedTributes = new List<CharacterAwaitTribute>();
    }
}
