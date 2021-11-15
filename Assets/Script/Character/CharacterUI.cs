using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class CharacterUI : MonoBehaviour, IPointerClickHandler, ISelectMode, IPointerEnterHandler, IPointerExitHandler
{
    public Character character;
    public GameObject tagPref;

    public Image Idle;
    public Text Name;
    public Text Health;
    public Text Loyalty;
    public GameObject TagSlot;

    public Image Wisdom;
    public Image Writing;
    public Image Strategy;
    public Image Strength;
    public Image Sneak;
    public Image Defense;

    public CharacterInfoUI characterInfoUI;
    private CharacterInfoUI currentCharacterInfoUI;

    private PlayerCharactersInventory inventoryCharacters;
    public bool selectMode
    {
        get => inventoryCharacters?.currentSlot != null;
    }

    public Tag newTag;

    public bool itemMode
    {
        get => newTag != Tag.Null;
    }

    public CharacterSlotForQuest CurrentSlot
    {
        get => inventoryCharacters.currentSlot;
        set => inventoryCharacters.currentSlot = value;
    }

    public static Dictionary<Rarerity, Color> TagUIColorCode = new Dictionary<Rarerity, Color>()
    {
        { Rarerity.VB, new Color32(153, 0, 0, 255)},
        { Rarerity.B, new Color32(141, 75, 6, 255)},
        { Rarerity.Null, new Color32(183, 183, 183, 255)},
        { Rarerity.N, Color.white },
        { Rarerity.R, new Color32(171,219,227, 255) },
        { Rarerity.SR, new Color32(180, 167, 214, 255) },
        { Rarerity.SSR, new Color32(255, 217, 102, 255) },
        { Rarerity.UR, new Color32(234, 153, 153, 255) }
    };

    private void Awake()
    {
        inventoryCharacters = FindObjectOfType<PlayerCharactersInventory>();
    }

    public void UpdateUI()
    {
        string idleSpritePath = ("Art/CharacterSprites/Idle/Idle_" + character.characterArtCode.ToString()).Replace(" ", string.Empty);
        Idle.sprite = Resources.Load<Sprite>(idleSpritePath);
        Idle.rectTransform.sizeDelta = new Vector2(290f, 435f);
        Name.text = character.CharacterName;
        Health.text = character.health.ToString();
        Loyalty.text = character.loyalty.ToString();
        //TODO:TagSlots
        ModifyValueColor();
        ModifyTags();
    }

    private void ModifyValueColor()
    {
        Wisdom.color = TagUIColorCode[character.characterValueRareDict[CharacterValueType.ÖÇ]];
        Writing.color = TagUIColorCode[character.characterValueRareDict[CharacterValueType.²Å]];
        Strategy.color = TagUIColorCode[character.characterValueRareDict[CharacterValueType.Ä±]];
        Strength.color = TagUIColorCode[character.characterValueRareDict[CharacterValueType.Îä]];
        Sneak.color = TagUIColorCode[character.characterValueRareDict[CharacterValueType.´Ì]];
        Defense.color = TagUIColorCode[character.characterValueRareDict[CharacterValueType.ÊØ]];
    }

    private void ModifyTags()
    {
        foreach (Tag tag in character.tagList)
        {
            var newTag = Instantiate(tagPref, TagSlot.transform);
            string FolderPathOfTags = ("Art/Tags/" + tag.ToString()).Replace(" ", string.Empty);
            newTag.GetComponent<Image>().sprite = Resources.Load<Sprite>(FolderPathOfTags);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<RectTransform>().localScale = new Vector3(1.15f, 1.15f, 0f);

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 0f);

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            switch (selectMode)
            {
                case true:
                    SelectCharacter();
                    break;
                case false:
                    switch (itemMode)
                    {
                        case true:
                            CreateTagSwitchUI();
                            break;
                        case false:
                            SelectCharacterInfo();
                            break;
                    }
                    break;

                    
            }
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            inventoryCharacters.RightClickSelectMode();
        }
    }

    private void CreateTagSwitchUI()
    {
        TagExchangeUI tagExchangeUI = Resources.Load<TagExchangeUI>("TagReplacement/TagReplacementUI");
        var current = Instantiate(tagExchangeUI, GameObject.FindGameObjectWithTag("MainUICanvas").transform);
        current.SetUp(newTag, character);
    }

    public void SelectCharacter()
    {
        if (selectMode)
        {
            CurrentSlot.UndisableField();
            CurrentSlot.character = character;
            CurrentSlot.CheckAllQuestAchievement();
            string headshotSpritePath = ("Art/CharacterSprites/Headshot/Headshot_" + character.characterArtCode.ToString()).Replace(" ", string.Empty);
            CurrentSlot.selectImage.sprite = Resources.Load<Sprite>(headshotSpritePath);
            CurrentSlot.selectImage.color = new Color
                (
                CurrentSlot.selectImage.color.r,
                CurrentSlot.selectImage.color.g,
                CurrentSlot.selectImage.color.b,
                1f
                );
            var CharacterSelectWindow = FindObjectOfType<PlayerCharactersInventory>();
            var allCharacters = CharacterSelectWindow.GetComponentsInChildren<CharacterUI>();
            foreach (CharacterUI c in allCharacters) c.CurrentSlot = null;

            CharacterSelectWindow.gameObject.SetActive(false);
        }
    }

    public void SelectCharacterInfo()
    {
        currentCharacterInfoUI = Instantiate(characterInfoUI, FindObjectOfType<Canvas>().transform);
        currentCharacterInfoUI.SetUp(character);
        //Debug.Log(currentCharacterInfoUI);
    }

}
