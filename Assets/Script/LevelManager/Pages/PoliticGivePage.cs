using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoliticGivePage : PoliticPage
{
    public PoliticSlot slot = null;
    public Text titleText = null;
    public Image gateHolderImage = null;
    public Text gateHolderNameText = null;
    public Text loyaltyValue = null;
    public LoyaltyGiveUnit loyaltyGiveUnitPref = null;
    public Transform itemParent = null;
    public Character character = null;
    public void Setup(PoliticSlot slot)
    {
        Reset();
        this.slot = slot;
        this.titleText.text = slot.slotName;
        character = slot.GateHolder;
        if (character == null)
        {
            character = slot.characterOnHold;
        }
        var spritePath = ReturnAssetPath.ReturnCharacterSpritePath(character.characterArtCode, false);
        gateHolderImage.sprite = Resources.Load<Sprite>(spritePath);
        gateHolderNameText.text = character.CharacterName;
        SetItems();
        loyaltyValue.text = $"{character.loyalty}/20";
    }

    private void SetItems()
    {
        foreach (var item in PoliticPurchaseItem.GovLoyaltyRecovery)
        {
            var clone = Instantiate(loyaltyGiveUnitPref, itemParent);
            Debug.Log(item.Key);
            clone.Setup(item.Key, this);
        }
        if (gameObject.activeSelf) { StartCoroutine(UpdateLayout()); }

    }

    public void Reset()
    {
        foreach (Transform child in itemParent)
        {
            Destroy(child.gameObject);
        }
    }
    public IEnumerator UpdateLayout()
    {
        yield return new WaitForEndOfFrame();
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }

    internal void UpdateAfterPurchase()
    {
        foreach (Transform child in itemParent)
        {
            child.GetComponent<LoyaltyGiveUnit>().SetupPrice();
            child.GetComponent<LoyaltyGiveUnit>().SetupAmount();
        }
        loyaltyValue.text = $"{character.loyalty}/20";
    }
}
