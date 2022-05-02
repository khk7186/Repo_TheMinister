using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class EventAfterConversation : MonoBehaviour
{
    public List<Character> charactersForCombats = new List<Character>();

    public void OnConversationEnd()
    {
        TryCombat();
    }

    public void TryCombat()
    {
        //{character.characterArtCode}
        bool startCombat = DialogueLua.GetVariable("startCombat").asBool;
        Debug.Log(startCombat);
        if (startCombat)
        {
            var Trigger = new GameObject().AddComponent<GeneralEventTrigger>();
            Trigger.enemyCharacters = charactersForCombats;
            Trigger.TriggerEvent();
            Debug.Log(startCombat);
        }
    }
}
