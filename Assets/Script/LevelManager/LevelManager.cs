using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.QuestMachine;

public class LevelManager : MonoBehaviour
{
    public static readonly float TaxPerLevelMultiplier = 0.2f;
    public static LevelManager Instance;
    public List<int> expPerLevel = new List<int>();
    public int level = 1;
    public int exp = 0;
    internal int ExtraExp = 0;

    public float currentMultiplier => (level) * TaxPerLevelMultiplier + 1;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        UpdateLevel();
    }
    public static void UpdateLevel()
    {
        var politicSlots = FindObjectsOfType<PoliticSlot>(true);
        int unlockCount = 0;

        foreach (var slot in politicSlots)
        {
            if (slot.unlocked)
            {
                unlockCount++;
                Instance.ApplyExp(slot.exp);
            }
        }
        Instance.ApplyExp(Instance.ExtraExp);
        //if (Instance.level < Instance.expPerLevel.Count)
        //{
        //    FindObjectOfType<PoliticLevelView>().SetView(Instance.level, Instance.exp / Instance.expPerLevel[Instance.level + 1]);
        //}
        //else
        //{
        FindObjectOfType<PoliticLevelView>().SetView(Instance.level, (float)Instance.exp / Instance.expPerLevel[Instance.level]);
        //}
        
    }
    public void Update()
    {
        PixelCrushers.MessageSystem.SendMessage(null, "PoliticLevelUp", string.Empty, Instance.level);
    }
    public void ApplyExp(int increase)
    {
        exp += increase;
        var maxExp = expPerLevel[level];
        if (exp >= maxExp)
        {
            level++;
            int gap = exp - maxExp;
            exp = 0;
            ApplyExp(gap);
        }
        else if (exp < 0)
        {
            level--;
            int gap = exp;
            exp = expPerLevel[level - 1];
            ApplyExp(gap);
        }
        FindObjectOfType<PoliticLevelView>().SetView(Instance.level, (float)Instance.exp / Instance.expPerLevel[Instance.level]);
    }
}
