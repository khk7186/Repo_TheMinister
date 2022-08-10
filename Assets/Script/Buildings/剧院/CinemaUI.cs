using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CinemaUI : MonoBehaviour, ICharacterSelect
{
    public PlayName currentPlayName;
    public Text PlayTitle;
    public Text PlayInfo;
    public CinemaTagUI tagUI;
    [SerializeField] private PlayerCharactersInventory charactersInventory;

    public HotelCharacterFrame[] CharacterIconList;

    public Character[] CharacterList = new Character[3];

    public ESlot currentESlot;
    private void Awake()
    {
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

    private void OnDisable()
    {
        var target = GetComponent<SpawnUI>();
        Destroy(target.CurrentTarget.gameObject);
    }
    public void StartCheck()
    {
        var UpgradeList = new List<Character>();
        foreach (Character character in CharacterList)
        {
            if (NullCheck(character)) UpgradeList.Add(character);
        }
        if (UpgradeList.Count > 0)
        {
            //TODO: remove money from inventory, make effect on character in list and start animation
            foreach (Character character in UpgradeList)
            {
                Debug.Log(character);
                UpgradeCharacter(character);
                Debug.Log(character.loyalty);
            }
            CharacterList = new Character[3];
            var target = GetComponent<SpawnUI>();
            Destroy(target.CurrentTarget.gameObject);
        }
    }

    private void UpgradeCharacter(Character character)
    {
        if (TagPair(character))
        {
            character.loyalty += 1;
        }
    }

    private bool TagPair(Character character)
    {
        var characterTagList = character.tagList;
        foreach (Tag tag in tagUI.tagList)
        {
            if (characterTagList.Contains(tag)) return true;
        }
        return false;
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
            invUI.SetupSelection(gameObject) ;

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
        target.SetupNewCharacter(CharacterList[index]);
        CharacterList[index] = null;
        CharacterIconList[index].SetupEmpty();
    }
    public void Confirm()
    {
        CharacterList[0].loyalty += 1;
        CharacterList[1].loyalty += 1;
    }
}
