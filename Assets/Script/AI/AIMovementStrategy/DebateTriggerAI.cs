using PixelCrushers.DialogueSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebateTriggerAI : QuestGiverAI
{
    protected override void StartConmunicate()
    {
        var DSC = FindObjectOfType<DialogueSystemController>();
        DSC.initialDatabase = Resources.Load<DialogueDatabase>(CorrectConversationBasedOnQuest());
        DSC.Awake();
        if (DialogueLua.GetVariable("WinDebate").asBool == false)
        {
            _dialogueTriggerUncollected.OnUse();
            StartCoroutine(DisappearAfterQuestSign());
        }
        else
        {
            _dialogueTriggerCollected.OnUse();
        }
    }
    public override IEnumerator DisappearAfterQuestSign()
    {
        Func<bool> _counterFinish = () => _counter >= DISSAPEAR_TIME;
        Dice.Instance.RegisterObserver(this);
        yield return new WaitUntil(_counterFinish);
        if (DialogueLua.GetVariable("Assign").asBool == false)
        {
        }
        else if (Chapter() < ChapterCounter.Instance.Chapter)
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
