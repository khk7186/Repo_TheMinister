using Language.Lua;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyInventory : MonoBehaviour
{
    public int Money = 250;
    public int Influence = 200;
    public int Prestige = 200;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public static void SetCurrencyUI()
    {
        var only = FindObjectOfType<CurrencyInventory>();
        var mainUI = FindObjectOfType<MainUI>();
        if (mainUI != null)
        {
            mainUI.SetupMoney(only.Money);
            mainUI.SetupInfluence(only.Influence);
            mainUI.SetupPrestige(only.Prestige);
        }
    }
    public void MoneyAdd(int add)
    {
        Money += add;
        FindObjectOfType<MainUI>()?.SetupMoney(Money);
    }
    public void InfluenceAdd(int add)
    {
        Influence += add;
        FindObjectOfType<MainUI>()?.SetupInfluence(Influence);
    }
    public void PrestigeAdd(int add)
    {
        Prestige += add;
        FindObjectOfType<MainUI>(true)?.SetupPrestige(Prestige);
    }
    public void MoneySpend(int spend)
    {
        Money -= spend;
        FindObjectOfType<MainUI>().SetupMoney(Money);
    }
}
