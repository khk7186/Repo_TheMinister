using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MoneyCollectionStationType
{
    RoadBlock,
    StartPoint
}
public class MoneyCollectionComponent : MonoBehaviour
{
    public int MoneyAmount = 10;
    public MoneyCollectionStationType stationType = MoneyCollectionStationType.RoadBlock;
    private int salaryAmount = 500;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            CurrencyInventory targetInventory = FindObjectOfType<CurrencyInventory>();
            targetInventory.Money += MoneyAmount;
            string path = "PopText/金钱收集效果";
            var target = Instantiate(Resources.Load<Text>(path),MainCanvas.FindMainCanvas());
            string outputText = "";
            switch (stationType)
            {
                default:
                    break;
                case MoneyCollectionStationType.RoadBlock:
                    outputText= "税收\n+" + MoneyAmount;
                    break;
                case MoneyCollectionStationType.StartPoint:
                    int salaryFinal = (int)(targetInventory.GovernorSupport + 1) * salaryAmount;
                    outputText= "俸禄:\n+" + salaryFinal+"/n税收:\n+" + MoneyAmount;
                    targetInventory.Money += salaryFinal;
                    break;
            }
            target.text = outputText;
        }
    }
}
