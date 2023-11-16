using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.QuestMachine;

public class TrackCounterForQuest : MonoBehaviour
{
    public string QuestID;
    public int RequireAmount = 1;
    public string CounterName;
    public string Message = "CharacterAdd";
    private Transform inventory;
    public CharacterValueType valueType = CharacterValueType.²Å;
    public Rarerity rarerity = Rarerity.SR;
    private bool dead = false;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("PlayerCharacterInventory").transform;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(DestroyOnDead());
    }

    private void FixedUpdate()
    {
        if (dead == false)
        {
            var current = CheckCurrent();
            SyncJurnal(current);
            if (current >= RequireAmount)
            {
                Debug.Log("Match Goal" + current);
                dead = true;
            }
        }
    }
    IEnumerator DestroyOnDead()
    {
        yield return new WaitUntil(() => dead);
        Destroy(gameObject); yield return null;
    }

    public void SyncJurnal(int current)
    {
        PixelCrushers.MessageSystem.SendMessage(null, Message, QuestID, current);
    }

    private int CheckCurrent()
    {
        var characters = inventory.GetComponentsInChildren<Character>();
        int count = 0;
        foreach (Character character in characters)
        {
            if (character.characterValueRareDict[valueType] >= rarerity)
            {
                count++;
            }
        }
        return count;
    }
}
