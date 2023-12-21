using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.QuestMachine;
using UnityEngine.PlayerLoop;

public class TrackCounterForQuest : MonoBehaviour, IDiceRollEvent
{
    public string QuestID;
    public int RequireAmount = 1;
    public string CounterName;
    public string Message = "CharacterAdd";
    private Transform inventory;
    public CharacterValueType valueType = CharacterValueType.²Å;
    public Rarerity rarerity = Rarerity.SR;
    private bool dead = false;
    public int currentValue = 0;

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
            currentValue = current;
            if (current >= RequireAmount)
            {
                Debug.Log("Match Goal" + current);
                dead = true;
            }
        }
    }
    private void Update()
    {
        SyncJurnal(currentValue);
    }
    IEnumerator DestroyOnDead()
    {
        yield return new WaitUntil(() => PixelCrushers.QuestMachine.QuestMachine.GetQuestNodeState(QuestID, "ÊÕ¼¯") == QuestNodeState.True);
        Destroy(gameObject); yield return null;
    }


    public void SyncJurnal(int current)
    {
        PixelCrushers.MessageSystem.SendMessage(null, Message, QuestID, current);
    }

    private int CheckCurrent()
    {
        var characters = SelectOnDuty.GetOndutyAll(OndutyType.Debate);
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

    //public void OnNotify(object value, NotificationType notificationType)
    //{
        
    //}
}
