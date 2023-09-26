using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class RobbedUI : MonoBehaviour
{
    public int Amount = -100;
    [SerializeField]
    public Text moneyAmount;
    public void Set(int amount)
    {
        Amount = amount;
        moneyAmount.text = amount.ToString();
        gameObject.SetActive(true);
    }

    public void OnDestroy()
    {
        CurrencyInvAnimationManager.Instance.MoneyChange(Amount);
    }
}
