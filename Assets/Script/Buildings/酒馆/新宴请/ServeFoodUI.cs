using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class ServeFoodUI : MonoBehaviour, ICharacterSelect
{
    public Character targetCharacter;
    public HotelCharacterFrame slot;
    public int price = 300;
    public int hungryIncrase = 1;
    public int LoyaltyIncrase = 1;
    public Text priceText = null;
    public Text totalPriceText = null;
    public GameObject confirmButton;

    private void Awake()
    {
        if (priceText != null)
            priceText.text = price.ToString();
        if (slot != null)
            slot.SetupEmpty();

    }
    private void OnEnable()
    {
        if (totalPriceText != null)
        {
            int total = 0;

            var characterInv = GameObject.FindGameObjectWithTag("PlayerCharacterInventory").transform;
            if (characterInv == null) return;
            foreach (Transform character in characterInv)
            {
                total += price;
            }
            totalPriceText.text = total.ToString();
        }

    }
    public void OpenInventory()
    {
        var target = GetComponent<SpawnUI>();
        if (target.CurrentTarget == null)
        {
            target.SpawnHere();
            var invUI = target.CurrentTarget.GetComponent<PlayerCharactersInventory>();
            invUI.SetupMode(CardMode.UpgradeSelectMode);
            invUI.SetupSelection(gameObject);
        }
        target.CurrentTarget.gameObject.SetActive(true);
    }
    public void ChooseCharacter(Character character)
    {
        targetCharacter = character;
    }

    public void CloseInventory()
    {
        var target = GetComponent<SpawnUI>();
        target.CurrentTarget.gameObject.SetActive(false);
    }

    public void CloseInventory(CharacterUI current)
    {
        CloseInventory();
    }

    public void SetupSlotIcon()
    {
        slot.Setup(targetCharacter);
    }
    public void TryServe()
    {
        if (targetCharacter == null)
        {
            var message = Instantiate<Text>(Resources.Load<Text>("Hiring/Message"), MainCanvas.FindMainCanvas());
            message.text = "请选择一个宴请的人物";
            return;
        }
        var currencyInv = FindObjectOfType<CurrencyInventory>();
        if (currencyInv.Money >= price)
        {
            currencyInv.Money -= price;
            Serve();
            var message = Instantiate<Text>(Resources.Load<Text>("Hiring/Message"), MainCanvas.FindMainCanvas());
            message.text = $"{targetCharacter.CharacterName}的饱腹值+{hungryIncrase},忠诚值+{LoyaltyIncrase}";
        }
        else
        {
            var message = Instantiate<Text>(Resources.Load<Text>("Hiring/Message"), MainCanvas.FindMainCanvas());
            message.text = "你需要更多金钱";
            return;
        }
    }
    public void Serve()
    {
        slot.RoomRegistered();
        slot.GetComponent<Button>().interactable = false;
        targetCharacter.ApplyFood(hungryIncrase);
        targetCharacter.ApplyLoyalty(LoyaltyIncrase);
        confirmButton.gameObject.SetActive(false);
    }
    public void TryServeAll()
    {
        var currencyInv = FindObjectOfType<CurrencyInventory>();
        int total = int.Parse(totalPriceText.text);
        if (currencyInv.Money >= total)
        {
            currencyInv.Money -= total;
            ServeAll();
            var message = Instantiate<Text>(Resources.Load<Text>("Hiring/Message"), MainCanvas.FindMainCanvas());
            message.text = $"所有随从饱腹值+{hungryIncrase},忠诚值+{LoyaltyIncrase}";
        }
        else
        {
            var message = Instantiate<Text>(Resources.Load<Text>("Hiring/Message"), MainCanvas.FindMainCanvas());
            message.text = "你需要更多金钱";
            return;
        }
    }
    public void ServeAll()
    {
        var characterInv = GameObject.FindGameObjectWithTag("PlayerCharacterInventory").transform;
        if (characterInv == null) return;
        foreach (Transform character in characterInv)
        {
            var target = character.gameObject.GetComponent<Character>();
            target.ApplyFood(hungryIncrase);
            target.ApplyLoyalty(LoyaltyIncrase);
        }
        confirmButton.gameObject.SetActive(false);
    }
}
