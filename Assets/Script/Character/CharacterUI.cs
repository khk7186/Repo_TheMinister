using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using System.Linq;

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

    public GameObject characterSelectUI;
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
        //OnCombatImage.gameObject.SetActive(false);
        //OnDebateImage.gameObject.SetActive(false);
        //OnGobangImage.gameObject.SetActive(false);
    }

    public void Setup()
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
        string backPath = ("Art/人物卡/背景贴图/" + topRarerity.ToString()).Replace(" ", string.Empty);
        string frontPath = ("Art/人物卡/前景贴图/" + topRarerity.ToString()).Replace(" ", string.Empty);
        BackRarity.sprite = Resources.Load<Sprite>(backPath);
        FrontRarity.sprite = Resources.Load<Sprite>(frontPath);
        if (character.OnDutyState[OndutyType.Combat])
        {
            OnCombatImage.gameObject.SetActive(true);
        }
        else OnCombatImage.gameObject.SetActive(false);
        if (character.OnDutyState[OndutyType.Debate])
        {
            OnDebateImage.gameObject.SetActive(true);
        }
        else OnDebateImage.gameObject.SetActive(false);
        if (character.OnDutyState[OndutyType.Gobang])
        {
            OnGobangImage.gameObject.SetActive(true);
        }
        else OnGobangImage.gameObject.SetActive(false);
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
        var origin = GetComponent<RectTransform>().localPosition;
        GetComponent<RectTransform>().localPosition = new Vector2(origin.x - 10, origin.y - 15);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<RectTransform>().localScale = new Vector3(0.8f, 0.8f, 1f);
        var origin = GetComponent<RectTransform>().localPosition;
        GetComponent<RectTransform>().localPosition = new Vector2(origin.x + 10, origin.y + 15);
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
                    //if (character.tagList.Count >= 5)
                    //{
                    //    CreateTagSwitchUI();
                    //}
                    //else
                    //{
                    //    character.tagList.Add(newTag);
                    //    GameObject.FindGameObjectWithTag("PlayerItemInventory").GetComponent<ItemInventory>().RemoveItem();
                    //    FindObjectOfType<ItemInventoryUI>().SetUp();
                    //    inventoryCharacters.RightClickSelectMode();
                    //}
                    ChangeCurrentCharacterAsset();
                    break;
                case CardMode.OnCombatSwitchMode:
                    string CombatText = "确认更换" + character.CharacterName + "为在任 武侍 ?";
                    Confirmation.HoldingMethod Combatholding = ChangeDutyState;
                    StartCoroutine(Confirmation.CreateNewComfirmation(Combatholding, CombatText).Confirm());
                    break;
                case CardMode.OnDebateSwitchMode:
                    string DebatetText = "确认更换 " + character.CharacterName + " 为在任 文客 ?";
                    Confirmation.HoldingMethod Debateholding = ChangeDutyState;
                    StartCoroutine(Confirmation.CreateNewComfirmation(Debateholding, DebatetText).Confirm());
                    break;
                case CardMode.OnGobangSwitchMode:
                    string GobangText = "确认更换" + character.CharacterName + "为在任 弈师 ?";
                    Confirmation.HoldingMethod Gobangholding = ChangeDutyState;
                    StartCoroutine(Confirmation.CreateNewComfirmation(Gobangholding, GobangText).Confirm());
                    break;
                case CardMode.UpgradeSelectMode:
                    SelectForSlot();
                    characterSelectUI.GetComponent<ICharacterSelect>().CloseInventory(this);
                    break;
            }
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (cardMode == CardMode.UpgradeSelectMode)
            {
                if (characterSelectUI != null)
                    characterSelectUI.GetComponent<ICharacterSelect>().CloseInventory();
            }
            else
            {
                if (inventoryCharacters != null)
                {
                    inventoryCharacters.RightClickSelectMode();
                }
                else if (PannelTopTransform != null)
                {
                    PannelTopTransform.GetComponent<RightClickToClose>().RightClickEvent();
                }
            }

        }
    }

    private void ChangeCurrentCharacterAsset()
    {
        FindObjectOfType<OnSwitchAssets>().character = character;
        FindObjectOfType<MedicationUI>()?.Setup(character);
        FindObjectOfType<CharacterInfoUI>()?.Setup(character);
        FindObjectOfType<PlayerCharactersInventory>().GetComponent<RightClickToClose>().RightClickEvent();
    }

    private void ChangeDutyState()
    {
        OndutyType ondutyType = OndutyType.Combat;
        switch (cardMode)
        {
            case CardMode.OnCombatSwitchMode:
                ondutyType = OndutyType.Combat;
                break;
            case CardMode.OnDebateSwitchMode:
                ondutyType = OndutyType.Debate;
                break;
            case CardMode.OnGobangSwitchMode:
                ondutyType = OndutyType.Gobang;
                break;
        }
        character.OnDutyState[ondutyType] = false;
        TargetCharacter.OnDutyState[ondutyType] = true;
        FindObjectOfType<CharacterInfoUI>().SetOnSelectButton();
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
        currentCharacterInfoUI.Setup(character);
        //Debug.Log(currentCharacterInfoUI);
    }

    public void SelectForSlot()
    {
        if (characterSelectUI != null)
        {
            var target = characterSelectUI.GetComponent<ICharacterSelect>();
            target.ChooseCharacter(character);
            target.SetupSlotIcon();
            target.CloseInventory(this);
        }
    }
}
