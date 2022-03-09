using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class CharacterUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
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

    public Image FrontRarity;
    public Image BackRarity;

    public Image OnCombatImage;
    public Image OnDebateImage;
    public Image OnGobangImage;

    private PlayerCharactersInventory inventoryCharacters;
    public CardMode cardMode = CardMode.ViewMode;
    public Tag newTag;

    public Character TargetCharacter;
    public Transform PannelTopTransform;

    public ConfirmPhase confirm = ConfirmPhase.Null;
    public CharacterSlotForQuest CurrentSlot
    {
        get => inventoryCharacters.currentSlot;
        set => inventoryCharacters.currentSlot = value;
    }

    public ICharacterSelect characterSelectUI;
    public ESlot CurrentESlot;

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
        OnCombatImage.gameObject.SetActive(false);
        OnDebateImage.gameObject.SetActive(false);
        OnGobangImage.gameObject.SetActive(false);
    }

    public void UpdateUI()
    {
        string idleSpritePath = ("Art/CharacterSprites/Idle/Idle_" + character.characterArtCode.ToString()).Replace(" ", string.Empty);
        Idle.sprite = Resources.Load<Sprite>(idleSpritePath);
        Idle.rectTransform.sizeDelta = new Vector2(420f, 630f);
        Name.text = character.CharacterName;
        Health.text = character.health.ToString();
        Loyalty.text = character.loyalty.ToString();
        ModifyValueColor();
        ModifyTags();
        ModifyCardImage();
    }

    private void ModifyCardImage()
    {
        Rarerity topRarerity = Rarerity.N;
        var targetDict = character.characterValueRareDict;
        foreach (CharacterValueType type in targetDict.Keys)
        {
            if ((int)targetDict[type] > (int)topRarerity)
            {
                topRarerity = targetDict[type];
            }
        }
        string backPath = ("Art/人物卡/背景贴图/"+topRarerity.ToString()).Replace(" ", string.Empty);
        string frontPath = ("Art/人物卡/前景贴图/" + topRarerity.ToString()).Replace(" ", string.Empty);
        BackRarity.sprite = Resources.Load<Sprite>(backPath);
        FrontRarity.sprite = Resources.Load<Sprite>(frontPath);
        if (character.OnCombatDuty)
        {
            OnCombatImage.gameObject.SetActive(true);
        }
        if (character.OnDebateDuty)
        {
            OnDebateImage.gameObject.SetActive(true);
        }
        if (character.OnGobangDuty)
        {
            OnGobangImage.gameObject.SetActive(true);
        }
    }
    private void ModifyValueColor()
    {
        var targetDict = character.characterValueRareDict;
        string pathTitle = "Art/人物卡/六大项/字体背景/";
        Wisdom.sprite = Resources.Load<Sprite>((pathTitle + targetDict[CharacterValueType.智]).Replace(" ", string.Empty));
        Writing.sprite = Resources.Load<Sprite>((pathTitle + targetDict[CharacterValueType.才]).Replace(" ", string.Empty));
        Strategy.sprite = Resources.Load<Sprite>((pathTitle + targetDict[CharacterValueType.谋]).Replace(" ", string.Empty));
        Strength.sprite = Resources.Load<Sprite>((pathTitle + targetDict[CharacterValueType.武]).Replace(" ", string.Empty));
        Sneak.sprite = Resources.Load<Sprite>((pathTitle + targetDict[CharacterValueType.刺]).Replace(" ", string.Empty));
        Defense.sprite = Resources.Load<Sprite>((pathTitle + targetDict[CharacterValueType.守]).Replace(" ", string.Empty));
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
        GetComponent<RectTransform>().localScale = new Vector3(0.9f, 0.9f, 1f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<RectTransform>().localScale = new Vector3(0.8f, 0.8f, 1f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            switch (cardMode)
            {
                case CardMode.ViewMode:
                    SelectCharacterInfo();
                    break;
                case CardMode.QuestSelectMode:
                    SelectCharacter();
                    break;
                case CardMode.ItemSelectMode:
                    if (character.tagList.Count >= 5)
                    {
                        CreateTagSwitchUI();
                    }
                    else
                    {
                        character.tagList.Add(newTag);
                        GameObject.FindGameObjectWithTag("PlayerItemInventory").GetComponent<ItemInventory>().RemoveItem();
                        FindObjectOfType<ItemInventoryUI>().SetUp();
                        inventoryCharacters.RightClickSelectMode();
                    }
                    break;
                case CardMode.OndutySwitchMode:
                    string currentText = "确认更换"+character.name + "?";
                    Confirmation.HoldingMethod holding = ChangeDutyState;
                    StartCoroutine(Confirmation.CreateNewComfirmation(holding, currentText).Confirm());
                    break;
                case CardMode.UpgradeSelectMode:
                    SelectForSlot();
                    characterSelectUI.CloseInventory(this);
                    break;
            }
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (cardMode == CardMode.UpgradeSelectMode)
            {
                characterSelectUI = FindObjectOfType<CinemaUI>() as ICharacterSelect;
                characterSelectUI.CloseInventory();
            }
            else
            {
                if (inventoryCharacters != null)
                {
                    inventoryCharacters.RightClickSelectMode();
                }
                else if(PannelTopTransform != null)
                {
                    PannelTopTransform.GetComponent<RightClickToClose>().RightClickEvent();
                }
            }
            
        }
    }

    private void ChangeDutyState()
    {
        
        character.OnCombatDuty = false;
        TargetCharacter.OnCombatDuty = true;
        PannelTopTransform.GetComponent<RightClickToClose>().RightClickEvent();
    }

    private void CreateTagSwitchUI()
    {
        TagExchangeUI tagExchangeUI = Resources.Load<TagExchangeUI>("TagReplacement/TagReplacementUI");
        var current = Instantiate(tagExchangeUI, GameObject.FindGameObjectWithTag("MainUICanvas").transform);
        current.SetUp(newTag, character);
    }

    public void SelectCharacter()
    {
        if (cardMode == CardMode.QuestSelectMode)
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

    public void SelectForSlot()
    {
        characterSelectUI = FindObjectOfType<CinemaUI>() as ICharacterSelect;
        if (characterSelectUI != null)
        {
            characterSelectUI.ChooseCharacter(character);
            characterSelectUI.SetupSlotIcon();
            characterSelectUI.CloseInventory(this);
        }
    }
}
