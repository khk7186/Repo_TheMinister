using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReciveCurrencyNotify : MonoBehaviour
{
    public int Money;
    public int Pressure;
    public int Influence;


    public RectTransform MoneyHolderTransform;
    public RectTransform PrestigeHolderTransform;
    public RectTransform InfluenceHolderTransform;

    public Text MoneyText;
    public Text PrestigeText;
    public Text InfluenceText;
    private void OnEnable()
    {
        if (Money != 0)
        {
            MoneyHolderTransform.gameObject.SetActive(true);
            MoneyText.text = Money.ToString();
        }
        if (Pressure != 0)
        {
            PrestigeHolderTransform.gameObject.SetActive(true);
            PrestigeText.text = Pressure.ToString();
        }
        if (Influence != 0)
        {
            InfluenceHolderTransform.gameObject.SetActive(true);
            InfluenceText.text = Influence.ToString();
        }
    }
    private void OnDestroy()
    {
        var inv = FindObjectOfType<CurrencyInventory>();
        inv.MoneyAdd(Money);
        PressureEventHandler.OnPressureChange(Pressure);
        CurrencyInventory.SetCurrencyUI();
        LevelManager.Instance.ApplyExtraExp(Influence);
    }
}
