using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class CurrencyInvAnimationManager : MonoBehaviour
{
    public static CurrencyInvAnimationManager Instance;
    public Text MoneyAnimationText;
    public AnimationCurve animationCurve;
    public float YChange = 20f;
    public float duration = 0.5f;
    public float delay = 1f;
    public Vector3 origin;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        origin = MoneyAnimationText.rectTransform.anchoredPosition;
    }
    private void OnEnable()
    {
        MoneyAnimationText.gameObject.SetActive(false);
    }
    public void MoneyChange(int diff)
    {
        var diffsign = diff >= 0 ? "+" : "-";
        MoneyAnimationText.text = $"{diffsign} {diff.ToString()}";
        var animation = new CurrencyInvAnimationHandler(MoneyAnimationText.GetComponent<RectTransform>());
        CurrencyInvAnimationHandler.AfterAnimation afterAnimation = () =>
        {
            MoneyAnimationText.rectTransform.anchoredPosition = origin;
            MoneyAnimationText.gameObject.SetActive(false);
            CurrencyInventory currencyInventory = FindObjectOfType<CurrencyInventory>();
            currencyInventory.Money += diff;
            CurrencyInventory.SetCurrencyUI();
        };
        animation.afterAnimation = afterAnimation;
        animation.Play();
    }
}
