using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHiringUI : MonoBehaviour
{
    public Image Idle;
    public Text CharacterName;
    public Transform Tags;
    public Vector2 SizeDelta = new Vector2(70f, 20f);
    public Transform Items;

    public Image Wisdom;
    public Image Writing;
    public Image Strategy;
    public Image Strength;
    public Image Sneak;
    public Image Defense;

    public Text WisdomValue;
    public Text WritingValue;
    public Text StrategyValue;
    public Text StrengthValue;
    public Text SneakValue;
    public Text DefenseValue;

    public bool TryHire;
    public void Setup(Character character, Dictionary<ItemName, int> ItemsAmountDict)
    {
        var targetIdleImagePath = ReturnAssetPath.ReturnCharacterSpritePath(character.characterArtCode);
        Idle.sprite = Resources.Load<Sprite>(targetIdleImagePath);
        CharacterName.text = character.CharacterName;

        SetItems(ItemsAmountDict);
        SetTags(character);
        SetValueBG(character);
        SetValues(character.CharactersValueDict);
    }
    public void SetTags(Character character)
    {
        Image tagObject = Resources.Load<Image>("Tag/Tag");
        TransformEx.Clear(Tags);
        Debug.Log(character.tagList);
        foreach (Tag tag in character.tagList)
        {
            var tagImagePath = $"Art/Tags/{tag.ToString()}";
            var current = Instantiate(tagObject, Tags);
            current.sprite = Resources.Load<Sprite>(tagImagePath);
            current.GetComponent<RectTransform>().sizeDelta = SizeDelta;
        }
    }
    public void SetItems(Dictionary<ItemName, int> ItemsAmountDict)
    {
        var itemObject = Resources.Load<HiringRequestItemUI>("Hiring/HireRequestItem");
        TransformEx.Clear(Items);
        foreach (ItemName item in ItemsAmountDict.Keys)
        {
            var current = Instantiate(itemObject, Items);
            var playerInv = FindObjectOfType<ItemInventory>();
            var playerInvDict = playerInv.ItemDict;
            int playerCount = playerInvDict.ContainsKey(item) ? playerInvDict[item] : 0;
            current.Setup(item, playerCount, ItemsAmountDict[item]);
            current.InUse = false;
        }
    }

    public void SetValues(Dictionary<CharacterValueType, int> dict)
    {
        WisdomValue.text = dict[CharacterValueType.ÖÇ].ToString();
        StrategyValue.text = dict[CharacterValueType.Ä±].ToString();
        WritingValue.text = dict[CharacterValueType.²Å].ToString();
        StrengthValue.text = dict[CharacterValueType.Îä].ToString();
        SneakValue.text = dict[CharacterValueType.´Ì].ToString();
        DefenseValue.text = dict[CharacterValueType.ÊØ].ToString();
    }

    public void SetValueBG(Character character)
    {
        var path = "Art/ÈËÎï¿¨/Áù´óÏî/×ÖÌå±³¾°/";
        Wisdom.sprite = Resources.Load<Sprite>($"{path}{character.characterValueRareDict[CharacterValueType.ÖÇ].ToString()}");
        Writing.sprite = Resources.Load<Sprite>($"{path}{character.characterValueRareDict[CharacterValueType.²Å].ToString()}");
        Strategy.sprite = Resources.Load<Sprite>($"{path}{character.characterValueRareDict[CharacterValueType.Ä±].ToString()}");
        Strength.sprite = Resources.Load<Sprite>($"{path}{character.characterValueRareDict[CharacterValueType.Îä].ToString()}");
        Sneak.sprite = Resources.Load<Sprite>($"{path}{character.characterValueRareDict[CharacterValueType.´Ì].ToString()}");
        Defense.sprite = Resources.Load<Sprite>($"{path}{character.characterValueRareDict[CharacterValueType.ÊØ].ToString()}");
    }

    public void ConfirmHire()
    {
        TryHire = true;
    }
}
