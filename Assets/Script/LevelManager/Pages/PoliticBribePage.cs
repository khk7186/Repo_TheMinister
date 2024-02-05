using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.QuestMachine;
using PixelCrushers;

public class PoliticBribePage : PoliticPage
{
    public PoliticSlot slot = null;
    public Text titleText = null;
    public Image gateHolderImage = null;
    public Text gateHolderNameText = null;
    public Text difficultyText = null;
    public GameObject difficultyGameobject = null;
    public Text alreadySpent = null;
    public Slider newOfferSlider = null;
    public Text newOfferText = null;
    public Text slotReward = null;
    public GameObject ConfirmButton = null;
    public GameObject OngoingView = null;
    public CurrencyInventory inventory = null;
    public void Setup(PoliticSlot slot)
    {
        if (inventory == null)
            inventory = FindObjectOfType<CurrencyInventory>();
        this.slot = slot;
        this.titleText.text = slot.slotName;
        var gateHolder = slot.GateHolder;
        var spritePath = ReturnAssetPath.ReturnCharacterSpritePath(gateHolder.characterArtCode, false);
        gateHolderImage.sprite = Resources.Load<Sprite>(spritePath);
        gateHolderNameText.text = gateHolder.CharacterName;
        if (gateHolder.bribed == false)
        {
            SetUnbrided();
            int bribePrice = gateHolder.BribePrice;
            if (gateHolder.ImpeachTime > 0)
            {
                bribePrice = bribePrice / gateHolder.ImpeachTime * PoliticCharacter.ImpeachPriceMultiplier;
            }
            SetDifficulty(bribePrice);
            ResetBribeMoney();
        }
        else
        {
            SetBribed();
        }
    }
    public void ResetBribeMoney()
    {
        alreadySpent.text = $"已经付出：{slot.GateHolder.BribeAlreadySpent}";
        newOfferSlider.maxValue = inventory.Money;
        newOfferSlider.value = 0;
        newOfferText.text = $" {newOfferSlider.value}/{newOfferSlider.maxValue}";
    }
    public void OnSliderValueChanged()
    {
        newOfferSlider.value = Mathf.RoundToInt(newOfferSlider.value);
        newOfferText.text = $" {newOfferSlider.value}/{inventory.Money}";
    }
    private void SetDifficulty(int bribePrice)
    {
        string output = "";
        if (bribePrice < 100)
        {
            output = "极其简单";
        }
        else if (bribePrice <= 500)
        {
            output = "简单";
        }
        else if (bribePrice <= 1000)
        {
            output = "一般";
        }
        else if (bribePrice <= 5000)
        {
            output = "小有难度";
        }
        else if (bribePrice <= 10000)
        {
            output = "困难";
        }
        else if (bribePrice <= 100000)
        {
            output = "极其困难";
        }
        else if (bribePrice <= 200000)
        {
            output = "几乎不可能";
        }
        else
        {
            output = "不可能";
        }
        difficultyText.text = $"贿赂难度\r\n<color=red><size=20>{output}</size></color>";
    }
    public void TryBribe()
    {
        int bribeMoney = Mathf.RoundToInt(newOfferSlider.value);
        if (bribeMoney <= 0) return;
        inventory.MoneySpend(bribeMoney);
        MessageSystem.SendMessage(null, "Bribe", slot.slotName, bribeMoney);
        slot.GateHolder.BribeAlreadySpent += bribeMoney;
        int bribePrice = slot.GateHolder.BribePrice;
        if (slot.GateHolder.ImpeachTime > 0)
        {
            bribePrice = bribePrice / slot.GateHolder.ImpeachTime * PoliticCharacter.ImpeachPriceMultiplier;
        }
        if (slot.GateHolder.BribeAlreadySpent >= bribePrice)
        {
            slot.GateHolder.bribed = true;
            LevelManager.UpdateLevel();
        }
        if (slot.GateHolder.bribed == true)
        {
            SetBribed();
            slot.GetComponent<PoliticSlotInteraction>().politicPopup.Setup(slot);
        }
        ResetBribeMoney();
    }

    private void SetBribed()
    {
        newOfferSlider.gameObject.SetActive(false);
        newOfferText.gameObject.SetActive(false);
        difficultyGameobject.gameObject.SetActive(false);
        alreadySpent.gameObject.SetActive(false);
        ConfirmButton.gameObject.SetActive(false);
        OngoingView.gameObject.SetActive(true);
    }
    private void SetUnbrided()
    {
        newOfferSlider.gameObject.SetActive(true);
        newOfferText.gameObject.SetActive(true);
        difficultyGameobject.gameObject.SetActive(true);
        alreadySpent.gameObject.SetActive(true);
        ConfirmButton.gameObject.SetActive(true);
        OngoingView.gameObject.SetActive(false);
    }
}
