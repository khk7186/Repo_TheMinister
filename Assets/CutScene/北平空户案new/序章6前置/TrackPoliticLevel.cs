using System.Collections;
using System.Collections.Generic;
using PixelCrushers.QuestMachine;
using UnityEngine;
using System.Linq;

public class TrackPoliticLevel : MonoBehaviour
{
    public string QuestID;
    public int RequireAmount = 1;
    public string CounterName;
    public string Message = "PoliticLevelUp";
    private bool dead = false;
    public int currentValue = 0;
    public FactionType factionType;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void FixedUpdate()
    {
        if (dead == false)
        {
            currentValue = CheckCurrent();
            if (currentValue >= RequireAmount)
            {
                dead = true;
                StartCoroutine(DestroyOnDead());
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        SyncJournal(currentValue);
    }

    public void SyncJournal(int current)
    {
        PixelCrushers.MessageSystem.SendMessage(null, Message, QuestID, current);
    }

    IEnumerator DestroyOnDead()
    {
        yield return new WaitForFixedUpdate();
        Destroy(gameObject); yield return null;
    }

    private int CheckCurrent()
    {
        int level = 0;
        var target = PoliticSystemManager.Instance.SOPoliticFaction.politicFactions.FirstOrDefault<PoliticFaction>(x => x.factionType == factionType);
        if (target.factionType == FactionType.¿Óµ≥)
        {
            level = LevelManager.Instance.level;
        }
        else
        {
            level = target.level;
        }
        return level;
    }


}
