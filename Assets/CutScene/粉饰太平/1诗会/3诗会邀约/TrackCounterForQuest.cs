using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.QuestMachine;

public class TrackCounterForQuest : MonoBehaviour
{
    public string QuestID;
    public int RequireAmount = 1;
    public string CounterName;
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
            if (current == RequireAmount)
            {
                dead = true;
            }
        }
    }
    IEnumerator DestroyOnDead()
    {
        yield return new WaitUntil(() => dead);
    }

    public void SyncJurnal(int current)
    {
        QuestMachineMessages.SetQuestCounter(null, new PixelCrushers.StringField(QuestID), new PixelCrushers.StringField(CounterName), current);
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
