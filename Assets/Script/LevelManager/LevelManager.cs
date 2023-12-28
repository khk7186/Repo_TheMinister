using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static readonly float TaxPerLevelMultiplier = 0.2f;
    public static LevelManager Instance;
    public static readonly List<int> expPerLevel = new List<int>();
    public int level = 1;
    public int exp;
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
    }
    public void ApplyExp(int increase)
    {
        exp += increase;
        var maxExp = expPerLevel[level - 1];
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
    }

}
