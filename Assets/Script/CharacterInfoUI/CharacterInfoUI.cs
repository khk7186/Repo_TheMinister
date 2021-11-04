using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharacterInfoUI : MonoBehaviour, IPointerClickHandler
{
    public Image Idle;
    public Text Name;

    public Slider loyalty;
    public Slider health;

    public Transform tagHolder;
    public TagSpecUI tagSpecUI;

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

    public void SetUp(Character character)
    {
        SetValueColors(
            CharacterUI.TagUIColorCode[character.characterValueRareDict[CharacterValueType.ÖÇ]],
            CharacterUI.TagUIColorCode[character.characterValueRareDict[CharacterValueType.²Å]],
            CharacterUI.TagUIColorCode[character.characterValueRareDict[CharacterValueType.Ä±]],
            CharacterUI.TagUIColorCode[character.characterValueRareDict[CharacterValueType.Îä]],
            CharacterUI.TagUIColorCode[character.characterValueRareDict[CharacterValueType.´Ì]],
            CharacterUI.TagUIColorCode[character.characterValueRareDict[CharacterValueType.ÊØ]]
            );
        SetIdle(character);
        SetValues(character.characterValueDict);
        SetTags(character.tagList);
        SetHealthAndLoyalty(character);
    }

    public void SetValueColors(Color32 wisdom,Color32 writing, Color32 strategy, Color32 strength, Color32 sneak, Color32 defense)
    {
        Wisdom.color = wisdom;
        Writing.color = writing;
        Strategy.color = strategy;
        Strength.color = strength;
        Sneak.color = sneak;
        Defense.color = defense;
    }

    public void SetIdle(Character character)
    {
        string idleSpritePath = ("Art/CharacterSprites/Idle/Idle_" + character.characterArtCode.ToString()).Replace(" ", string.Empty);
        Idle.sprite = Resources.Load<Sprite>(idleSpritePath);
    }

    public void SetValues(Dictionary<CharacterValueType,int> dict)
    {
        WisdomValue.text = dict[CharacterValueType.ÖÇ].ToString();
        StrategyValue.text = dict[CharacterValueType.Ä±].ToString();
        WritingValue.text = dict[CharacterValueType.²Å].ToString();
        StrengthValue.text = dict[CharacterValueType.Îä].ToString();
        SneakValue.text = dict[CharacterValueType.´Ì].ToString();
        DefenseValue.text = dict[CharacterValueType.ÊØ].ToString();
    }

    public void SetTags(List<Tag> tags)
    {
        foreach (Tag tag in tags)
        {
            TagSpecUI thisTag = Instantiate(tagSpecUI, tagHolder);
            thisTag.SetUp(tag);
        }
    }

    public void SetHealthAndLoyalty(Character character)
    {
        health.value = character.health;
        loyalty.value = character.loyalty;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Destroy(gameObject);
        }
    }
}
