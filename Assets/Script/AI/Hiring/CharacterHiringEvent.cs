using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHiringEvent : MonoBehaviour
{
    private static Dictionary<Rarerity, Dictionary<ItemName, int>> FemalePoestRarityItemRequestDict
        = new Dictionary<Rarerity, Dictionary<ItemName, int>>
        {
            {Rarerity.N,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.三七,10 }
                 }
            },
            {
             Rarerity.R,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.三七,10 }
                 }
            } ,
            {
             Rarerity.SR,
                new Dictionary<ItemName, int>()
                {
                    {ItemName.三七,10 }
                 }
            }
        };
    private static Dictionary<CharacterArtCode, Dictionary<Rarerity, Dictionary<ItemName, int>>> CharacterArtCodeToRarityItemRequestDict
        = new Dictionary<CharacterArtCode, Dictionary<Rarerity, Dictionary<ItemName, int>>>
        {
            {CharacterArtCode.女诗人, FemalePoestRarityItemRequestDict }
        };
    public Character character;
    public Dictionary<ItemName, int> requestItems;
    public string FailedMessage;
    private void Awake()
    {
        character = GetComponent<DefaultInGameAI>().character;
    }

    public void StartHiring()
    {
        if (character == null)
        {
            return;
        }
        StartCoroutine(HiringRator());
    }
    public void SetRequest()
    {
        Rarerity rarerity = Rarerity.N;
        foreach (Tag tag in character.tag)
        {
            if ((int)Player.AllTagRareDict[tag] > (int)rarerity)
            {
                rarerity = (Rarerity)Player.AllTagRareDict[tag];
            }
        }
        requestItems = CharacterArtCodeToRarityItemRequestDict[character.characterArtCode][rarerity];
    }
    public IEnumerator HiringRator()
    {
        var UIobject = Resources.Load<CharacterHiringUI>("Hiring/HireUI");
        var currentUI = Instantiate(UIobject, MainCanvas.FindMainCanvas());
        SetRequest();
        currentUI.Setup(character, requestItems);
        bool NeverFalse = true;
        while (NeverFalse)
        {
            if (currentUI.TryHire == true)
            {
                if (TryHiring() == true)
                {
                    break;
                }
                currentUI.TryHire = false;
                var sampleText = Resources.Load<Text>("Hiring/Message");
                var message = Instantiate<Text>(sampleText, MainCanvas.FindMainCanvas());
                message.text = FailedMessage;
            }
            yield return null;
        }
    }
    public bool TryHiring()
    {
        var itemInventory = FindObjectOfType<ItemInventory>();
        var itemDict = itemInventory.ItemDict;
        foreach (ItemName item in requestItems.Keys)
        {
            if (itemDict.ContainsKey(item) == false)
            {
                FailedMessage = "缺少招募道具";
                return false;
            }
            if (itemDict[item] < requestItems[item])
            {
                FailedMessage = "道具数量不足";
                return false;
            }
        }
        foreach (ItemName item in requestItems.Keys)
        {
            for (int i = 0; i < requestItems[item]; i++)
            {
                itemInventory.RemoveItem(item);
            }
        }
        return true;
    }
}
