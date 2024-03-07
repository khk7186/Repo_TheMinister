using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CinemaUI : MonoBehaviour, ICharacterSelect
{
    public PlayName currentPlayName;
    public Text PlayTitle;
    public Text PlayInfo;
    public Button ConfirmButton;
    public CinemaTagUI tagUI;
    [SerializeField] private PlayerCharactersInventory charactersInventory;
    public Text Total;
    public int Price;
    private int count;

    public HotelCharacterFrame[] CharacterIconList;

    public Character[] CharacterList = new Character[3];

    public ESlot currentESlot;
    private void Awake()
    {
        Total.text = "0";
        foreach (HotelCharacterFrame frame in CharacterIconList)
        {
            frame.SetupEmpty();
        }
    }
    public void Setup(PlayName playName)
    {
        currentPlayName = playName;
        var targetAL = PlayList.PlayListDict[playName];
        PlayTitle.text = targetAL[0] as string;
        PlayInfo.text = targetAL[1] as string;
        tagUI.Setup(targetAL[2] as List<Tag>);
    }

    public void StartCheck()
    {
        var UpgradeList = new List<Character>();
        foreach (Character character in CharacterList)
        {
            if (NullCheck(character)) UpgradeList.Add(character);
        }

        string message = string.Empty;
        if (UpgradeList.Count > 0)
        {
            Finish();
            foreach (Character character in UpgradeList)
            {
                if (message != string.Empty)
                    message += "和";
                message += character.CharacterName;
                UpgradeCharacter(character);
                character.Away(1);
                character.awayMessage = "recovery";
            }
            var alert = Instantiate<Text>(Resources.Load<Text>("Hiring/Message"), MainCanvas.FindMainCanvas());
            alert.text = message + "将在一天后回归并提升忠诚度";
            CharacterList = new Character[3];
            var target = GetComponent<SpawnUI>();
            Destroy(target.CurrentTarget.gameObject);
            ConfirmButton.gameObject.SetActive(false);
        }
        else
        {
            var alert = Instantiate<Text>(Resources.Load<Text>("Hiring/Message"), MainCanvas.FindMainCanvas());
            alert.text = "请选择角色入座";
        }
    }

    private void UpgradeCharacter(Character character)
    {
        character.loyalty += 1;
        int extra = TagPair(character);
        if (extra > 0)
        {
            character.loyalty += 1;
        }
    }
    private void FixedUpdate()
    {
        count = 0;
        foreach (Character character in CharacterList)
        {
            if (NullCheck(character))
            {
                count += 1;
            }
        }
        Total.text = count.ToString();
    }
    private int TagPair(Character character)
    {
        int output = 0;
        var characterTagList = character.tagList;
        foreach (Tag tag in tagUI.tagList)
        {
            if (characterTagList.Contains(tag))
                output += 1;
        }
        return output;
    }

    public bool NullCheck(object target)
    {
        if (target == null)
        {
            return false;
        }
        else return true;
    }

    public void ChooseCharacter(Character character)
    {
        if (CharacterList[(int)currentESlot - 1] != null)
        {
            Remove((int)currentESlot - 1);
        }
        CharacterList[(int)currentESlot - 1] = character;
    }

    public void SetupSlotIcon()
    {

        var target = CharacterIconList[(int)currentESlot - 1];
        var character = CharacterList[(int)currentESlot - 1];
        //var path = ("Art/CharacterSprites/Headshot/Headshot_" + character.characterArtCode.ToString()).Replace(" ", string.Empty);
        //target.sprite = Resources.Load<Sprite>(path);
        target.GetComponent<HotelCharacterFrame>().Setup(character);
    }

    public void OpenInventory()
    {
        var target = GetComponent<SpawnUI>();
        if (target.CurrentTarget == null)
        {
            target.SpawnHere();
            var invUI = target.CurrentTarget.GetComponent<PlayerCharactersInventory>();
            invUI.SetupMode(CardMode.UpgradeSelectMode);
            invUI.SetupSelection(gameObject);
        }
        target.CurrentTarget.gameObject.SetActive(true);
    }
    public void CloseInventory()
    {
        var target = GetComponent<SpawnUI>();
        target.CurrentTarget.gameObject.SetActive(false);
    }
    public void CloseInventory(CharacterUI current)
    {
        Destroy(current.gameObject);
        CloseInventory();
    }
    public void SetSlotOne()
    {
        currentESlot = ESlot.one;
    }
    public void SetSlotTwo()
    {
        currentESlot = ESlot.two;
    }
    public void SetSlotThree()
    {
        currentESlot = ESlot.three;
    }
    public void Remove(int index)
    {
        var target = GetComponent<SpawnUI>().CurrentTarget.GetComponent<PlayerCharactersInventory>();
        var ui = target.SetupNewCharacter(CharacterList[index]);
        ui.cardMode = CardMode.UpgradeSelectMode;
        ui.characterSelectUI = gameObject;
        CharacterList[index] = null;
        CharacterIconList[index].SetupEmpty();
    }
    public void Confirm()
    {
        var currencyInv = FindObjectOfType<CurrencyInventory>();
        if (currencyInv.Money >= Price * count)
        {
            currencyInv.Money -= Price * count;
            StartCheck();
        }
        else
        {
            var message = Instantiate<Text>(Resources.Load<Text>("Hiring/Message"), MainCanvas.FindMainCanvas());
            message.text = "你需要更多金钱";
            return;
        }

    }
    public void Finish()
    {
        CharacterIconList[0].RoomRegistered();
        CharacterIconList[1].RoomRegistered();
        CharacterIconList[0].GetComponent<Button>().interactable = false;
        CharacterIconList[1].GetComponent<Button>().interactable = false;
    }
}
