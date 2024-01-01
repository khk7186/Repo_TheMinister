using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoliticRequestPage : PoliticPage
{
    public PoliticSlot slot = null;
    public Text titleText = null;
    public Image gateHolderImage = null;
    public Text gateHolderNameText = null;
    public Text loyaltyValue = null;
    public LoyaltyPurchaseUnit loyaltyPurchaseUnitPref = null;
    public Transform itemParent = null;
    public Character character = null;
    public void Setup(PoliticSlot slot)
    {
        Reset();
        this.slot = slot;
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
    public void Reset()
    {
        foreach (Transform child in itemParent)
        {
            Destroy(child.gameObject);
        }
    }
    public void UpdateAfterPurchase()
    {
        foreach (Transform child in itemParent)
        {
            child.GetComponent<LoyaltyPurchaseUnit>().SetupPrice();
        }
        loyaltyValue.text = $"{character.loyalty}/20";
    }
    public void SetItems()
    {
        var items = PoliticPurchaseItem.GovernorShop[slot.governorType];
        foreach (var item in items)
        {
            var clone = Instantiate(loyaltyPurchaseUnitPref, itemParent);
            clone.Setup(item, this);
        }
        StartCoroutine(UpdateLayout());
    }
    public IEnumerator UpdateLayout()
    {
        yield return new WaitForEndOfFrame();
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }
}
