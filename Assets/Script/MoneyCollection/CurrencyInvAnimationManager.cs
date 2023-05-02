using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class CurrencyInvAnimationManager : MonoBehaviour
{
    public static CurrencyInvAnimationManager Instance;
    public Text MoneyAnimationText;
    public Text PrestigeAnimationText;
    public AnimationCurve animationCurve;
    public float YChange = 20f;
    public float duration = 0.5f;
    public float delay = 1f;
    public Vector3 MoneyAnimationTextOrigin;
    public Vector3 PrestigeAnimationTextOrigin;
    public bool forTutorial = false;

    public void Awake()
    {
        if (Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;
        MoneyAnimationTextOrigin = MoneyAnimationText.rectTransform.anchoredPosition;
        PrestigeAnimationTextOrigin = PrestigeAnimationText.rectTransform.anchoredPosition;
    }
    private void OnEnable()
    {
        MoneyAnimationText.gameObject.SetActive(false);
    }
    public void MoneyChange(int diff)
    {
        var diffsign = diff >= 0 ? "+" : "";
        MoneyAnimationText.text = $"{diffsign} {diff.ToString()}";
        var animation = new CurrencyInvAnimationHandler(MoneyAnimationText.GetComponent<RectTransform>());
        CurrencyInventory currencyInventory = FindObjectOfType<CurrencyInventory>();
        currencyInventory.Money += diff;
        CurrencyInvAnimationHandler.AfterAnimation afterAnimation = () =>
        {
            MoneyAnimationText.rectTransform.anchoredPosition = MoneyAnimationTextOrigin;
            MoneyAnimationText.gameObject.SetActive(false);
            CurrencyInventory.SetCurrencyUI();
        };
        animation.afterAnimation = afterAnimation;
        animation.Play();
    }
    public void PrestigeChange(int diff)
    {
        var diffsign = diff >= 0 ? "+" : "";
        PrestigeAnimationText.text = $"{diffsign} {diff.ToString()}";
        var animation = new CurrencyInvAnimationHandler(PrestigeAnimationText.GetComponent<RectTransform>());
        CurrencyInventory currencyInventory = FindObjectOfType<CurrencyInventory>();
        currencyInventory.Prestige = GameObject.FindGameObjectWithTag("PlayerCharacterInventory")
                                                                            .transform.GetComponentsInChildren<Character>()
                                                                            .Where(x => x.hireStage != HireStage.Away).ToArray().Length;
        CurrencyInvAnimationHandler.AfterAnimation afterAnimation = () =>
        {
            PrestigeAnimationText.rectTransform.anchoredPosition = PrestigeAnimationTextOrigin;
            PrestigeAnimationText.gameObject.SetActive(false);
            CurrencyInventory.SetCurrencyUI();
        };
        animation.afterAnimation = afterAnimation;
        animation.Play();
    }
}
