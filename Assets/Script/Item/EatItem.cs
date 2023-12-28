using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EatItem : MonoBehaviour
{
    public PlayerCharactersInventory current = null;
    public int hungryUp = 0;
    public int loyaltyUp = 0;
    public int healthUp = 0;
    public EdibleType edibleType;
    public Rarerity rarerity;
    private void Start()
    {
        var item = FindObjectOfType<OnSwitchAssets>().item;
        if (item == ItemName.Null || !EdiblesItems.IsEdible(item)) gameObject.SetActive(false);
    }
    public void Setup()
    {
        var item = FindObjectOfType<OnSwitchAssets>().item;
        EdiblesItems.FoodRecovery.TryGetValue(item, out List<int> healthHungry);
        healthUp = healthHungry[0];
        hungryUp = healthHungry[1];
        rarerity = Player.AllTagRareDict[Use(item)] != Rarerity.B ? Player.AllTagRareDict[Use(item)] : Rarerity.N;
        edibleType = EdiblesItems.GetEdibleType(item);
    }
    public void SpawnCharacterChooseUI()
    {
        PlayerCharactersInventory playerCharactersInventory = Resources.Load<PlayerCharactersInventory>("CharacterInvUI/ChraInvUI");
        current = Instantiate(playerCharactersInventory, MainCanvas.FindMainCanvas());
        current.SetupMode(CardMode.EatMode);
    }

    public void EatBy(Character character)
    {
        var item = FindObjectOfType<OnSwitchAssets>().item;
        character.ApplyHealth(healthUp);
        character.ApplyFood(hungryUp);
        character.ApplyLoyalty(loyaltyUp);
        current.GetComponent<RightClickToClose>().RightClickEvent();
        var itemInv = FindObjectOfType<ItemInventory>();
        TryAddTemporaryTag(character);
        itemInv.RemoveItem(item);
        ResetUI();
    }
    public Tag Use(ItemName itemName)
    {
        Tag output = Tag.Null;
        if (SOItem.ItemMap.ContainsKey(itemName))
        {
            output = SOItem.ItemMap[itemName];
            return output;
        }
        else
        {
            Debug.LogError(itemName);
            return output;
        }
    }
    public void ResetUI()
    {
        bool notEmptyInv = FindObjectOfType<ItemInventory>().ItemDict.Keys.Count > 0;
        var inv = FindObjectOfType<ItemInventoryUI>();
        inv.SetUp(inv.itemInventory);
        if (notEmptyInv)
        {
            inv.GetComponentInChildren<ItemUI>().SetupInUseItem();
        }
    }
    public void TryAddTemporaryTag(Character character)
    {
        var item = FindObjectOfType<OnSwitchAssets>().item;
        if (EdiblesItems.ItemToTempDict.Keys.Contains(item))
        {
            var targetTag = EdiblesItems.ItemToTempDict[item];
            foreach (var tempTag in character.temporaryTags)
            {
                if (tempTag.tag == targetTag)
                {
                    tempTag.timeLeft = Mathf.Max(tempTag.timeLeft, 7);
                }
            }
            character.temporaryTags.Add(new TemporaryTag(targetTag, 7));
        }
    }
}
