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
    public void MoneyAdd(int add)
    {
        Money += add;
        FindObjectOfType<MainUI>().SetupMoney(Money);
    }
    public void MoneySpend(int spend)
    {
        Money -= spend;
        FindObjectOfType<MainUI>().SetupMoney(Money);
    }
}
