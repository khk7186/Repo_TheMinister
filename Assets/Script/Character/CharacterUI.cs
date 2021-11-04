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

    private CharacterSlotForQuest currentSlot;
    public bool selectMode
    {
        get => currentSlot != null;
    }
    public CharacterSlotForQuest CurrentSlot
    {
        get => currentSlot;
        set => currentSlot = value;
    }

    public static Dictionary<Raitity, Color> TagUIColorCode = new Dictionary<Raitity, Color>()
    {
        { Raitity.VB, new Color32(153, 0, 0, 255)},
        { Raitity.B, new Color32(141, 75, 6, 255)},
        { Raitity.Null, new Color32(183, 183, 183, 255)},
        { Raitity.N, Color.white },
        { Raitity.R, new Color32(171,219,227, 255) },
        { Raitity.SR, new Color32(180, 167, 214, 255) },
        { Raitity.SSR, new Color32(255, 217, 102, 255) },
        { Raitity.UR, new Color32(234, 153, 153, 255) }
    };


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
                    SelectCharacterInfo();
                    break;
            }
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            var CharacterSelectWindow = FindObjectOfType<InventoryCharacters>();
            switch (selectMode)
            {
                case true:
                    currentSlot.UndisableField();
                    var allCharacters = CharacterSelectWindow.GetComponentsInChildren<CharacterUI>();
                    foreach (CharacterUI c in allCharacters) c.CurrentSlot = null;
                    break;
                case false:
                    break;
            }
            CharacterSelectWindow.gameObject.SetActive(false);
        }
    }


    public void SelectCharacter()
    {
        if (selectMode)
        {
            currentSlot.UndisableField();
            currentSlot.character = character;
            currentSlot.CheckAllQuestAchievement();
            string headshotSpritePath = ("Art/CharacterSprites/Headshot/Headshot_" + character.characterArtCode.ToString()).Replace(" ", string.Empty);
            currentSlot.selectImage.sprite = Resources.Load<Sprite>(headshotSpritePath);
            currentSlot.selectImage.color = new Color
                (
                currentSlot.selectImage.color.r,
                currentSlot.selectImage.color.g,
                currentSlot.selectImage.color.b,
                1f
                );
            var CharacterSelectWindow = FindObjectOfType<InventoryCharacters>();
            var allCharacters = CharacterSelectWindow.GetComponentsInChildren<CharacterUI>();
            foreach (CharacterUI c in allCharacters) c.CurrentSlot = null;

            CharacterSelectWindow.gameObject.SetActive(false);
        }
    }

    public void SelectCharacterInfo()
    {
        currentCharacterInfoUI = Instantiate(characterInfoUI,FindObjectOfType<Canvas>().transform);
        currentCharacterInfoUI.SetUp(character);
        Debug.Log(currentCharacterInfoUI);
    }

}
