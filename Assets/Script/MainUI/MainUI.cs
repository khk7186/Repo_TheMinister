using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public GameObject Time;
    public Text Year;
    public Text Month;
    public Text Day;
    public Text Hour;

    public GameObject Currency;
    public Text Money;
    public Text Influence;
    public Text Prestige;

    private char[] strChinese = new char[] {
                 '〇','一','二','三','四','五','六','七','八','九','十'
             };
    private List<int> originTime = new List<int>() { 17, 3, 5 };
    private void OnEnable()
    {
        var reference = FindObjectOfType<CurrencyInventory>();
        SetupMoney(reference.Money);
        SetupInfluence(reference.Influence);
        SetupPrestige(reference.Prestige);
        SetupTime();
    }
    public void SetupTime()
    {
        Map map = FindObjectOfType<Map>();
        if (map == null)
        {
            Time.gameObject.SetActive(false);
            return;
        }
        Time.gameObject.SetActive(true);
        var totalDay = map.Day + originTime[2];
        int day = totalDay % 30;
        int totalMonth = totalDay / 30 + originTime[1];
        int month = totalMonth % 12;
        int year = totalMonth / 12 + originTime[0];
        Year.text = BuildDateUnit2Chinese(year)+"年";
        Month.text = BuildDateUnit2Chinese(month) +"月";
        Day.text = BuildDateUnit2Chinese(day) + "日";
    }
    public void SetupMoney(int Amount)
    {
        Money.text = Amount.ToString();
    }
    public void SetupInfluence(int Amount)
    {
        Influence.text = Amount.ToString();
    }
    public void SetupPrestige(int Amount)
    {
        Prestige.text = Amount.ToString();
    }
    public string BuildDateUnit2Chinese(int Count)
    {
        StringBuilder result = new StringBuilder();
        int unit = Count;
        int MN1 = unit / 10;
        int MN2 = unit % 10;

        if (MN1 > 1)
        {
            result.Append(strChinese[MN1]);
        }
        if (MN1 > 0)
        {
            result.Append(strChinese[10]);
        }
        if (MN2 != 0)
        {
            result.Append(strChinese[MN2]);
        }
        return result.ToString();

    }
}