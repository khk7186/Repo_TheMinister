using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotelUI : MonoBehaviour, ICharacterSelect
{
    public List<RectTransform> Rooms;
    public List<int> RoomBedCounts = new List<int> { 1, 2, 5 };
    public List<int> RoomPrices = new List<int> { 50, 20, 20 };
    public List<Text> RoomPricesUIText;
    public List<List<Character>> Characters;
    public HotelCharacterFrame CharacterFrameTemp;
    public List<Button> ConfirmButtons;
    public delegate void HotelUIButtonAction();
    public HotelUIButtonAction OpenChangeCharacterUIAction;
    private HotelCharacterFrame OnEdit;
    private int HotelRoomIndex = 0;
    private Character OnEditCharacter;
    private void Awake()
    {
        Characters =
        new List<List<Character>>()
        {
            new List<Character>(){ null,null,null,null,null},
            new List<Character>(){ null,null,null,null,null},
            new List<Character>(){ null,null,null,null,null}
        };
    }
    public void Setup()
    {
        CharacterFrameTemp.gameObject.SetActive(false);
        for (int i = 0; i < Rooms.Count; i++)
        {
            TransformEx.Clear(Rooms[i]);
            SetRoomPriceUI(i);
            for (int j = 0; j < RoomBedCounts[i]; j++)
            {
                var target = Instantiate(CharacterFrameTemp, Rooms[i]);
                target.gameObject.SetActive(true);
                target.SetupEmpty();
                target.Index = j;
                SetButtons(i, target);
            }
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }
    public void SetButtons(int roomNumber, HotelCharacterFrame hotelCharacter)
    {
        var target = hotelCharacter.GetComponent<Button>();
        target.onClick.AddListener(() =>
        {
            SelectFrame(hotelCharacter, roomNumber);
            OpenInventory();
        });
        var remove = hotelCharacter.Remove;
        remove.onClick.AddListener(
            () =>
            {
                RemoveFromRoom(roomNumber, hotelCharacter.Index);
                hotelCharacter.SetupEmpty();
            });
        //Debug.Log($"{roomNumber}, {hotelCharacter.Index}");
    }
    public void SetRoomPriceUI(int roomNumber)
    {
        Text target = RoomPricesUIText[roomNumber];
        switch (roomNumber)
        {
            default:
                break;
            case 0:
                target.text = $"上房\n{RoomPrices[roomNumber]}两/天";
                break;
            case 1:
                target.text = $"标间\n{RoomPrices[roomNumber]}两/天";
                break;
            case 2:
                target.text = $"柴屋\n{RoomPrices[roomNumber]}两/天";
                break;
        }
    }
    public void SelectFrame(HotelCharacterFrame gameObject, int roomIndex)
    {
        HotelRoomIndex = roomIndex;
        OnEdit = gameObject;
    }
    public void RemoveFromRoom(int roomIndex, int spotIndex)
    {
        var last = Characters[roomIndex][spotIndex];
        var target = GetComponent<SpawnUI>().CurrentTarget.GetComponent<PlayerCharactersInventory>().SetupNewCharacter(last);
        target.cardMode = CardMode.UpgradeSelectMode;
        target.characterSelectUI = gameObject;
        Characters[roomIndex][spotIndex] = null;
    }
    public void ChooseCharacter(Character character)
    {
        if (Characters[HotelRoomIndex][OnEdit.Index] != null)
        {
            RemoveFromRoom(HotelRoomIndex, OnEdit.Index);
        }
        Characters[HotelRoomIndex][OnEdit.Index] = character;
        OnEditCharacter = character;
    }
    public void SetupSlotIcon()
    {
        OnEdit.Setup(OnEditCharacter);
    }
    public void CloseInventory()
    {
        var target = GetComponent<SpawnUI>();
        target.CurrentTarget.gameObject.SetActive(false);
    }
    public void CloseInventory(CharacterUI current)
    {
        StartCoroutine(CloseInventoryRator(current));
    }
    public IEnumerator CloseInventoryRator(CharacterUI current)
    {
        Destroy(current.gameObject);
        yield return new WaitUntil(() => current == null);
        CloseInventory();
    }
    public void OpenInventory()
    {
        var target = GetComponent<SpawnUI>();
        if (target.CurrentTarget == null)
        {
            target.SpawnHere();
            PlayerCharactersInventory UI = target.CurrentTarget.GetComponent<PlayerCharactersInventory>();
            UI.SetupMode(CardMode.UpgradeSelectMode);
            UI.SetupSelection(gameObject);
        }
        target.CurrentTarget.gameObject.SetActive(true);
    }

    public void ConfirmUse(int index)
    {
        bool emptyRoom = true;
        bool notEnoughMoney = false;
        bool characterDontLikeRoom = false;
        List<Character> targetList = new List<Character>();
        foreach (Character obj in Characters[index])
        {
            if (obj == null) continue;
            emptyRoom = false;
            Rarerity rarerity = obj.CheckTopRare();
            if ((rarerity >= Rarerity.SR && index > 1) || (rarerity >= Rarerity.SSR && index != 0))
            {
                characterDontLikeRoom = true;
                targetList.Add(obj);
            }
        }
        if (FindObjectOfType<CurrencyInventory>().Money < RoomPrices[index])
            notEnoughMoney = true;

        RiseUpTextAnimation alertPref = Resources.Load<RiseUpTextAnimation>("Hiring/Message");
        if (emptyRoom)
        {
            var current = Instantiate(alertPref, MainCanvas.FindMainCanvas());
            current.GetComponent<Text>().text = "没有宾客入住";
            return;
        }
        if (notEnoughMoney)
        {
            var current = Instantiate(alertPref, MainCanvas.FindMainCanvas());
            current.GetComponent<Text>().text = "没有足够的银两";
            return;
        }
        if (characterDontLikeRoom)
        {
            var current = Instantiate(alertPref, MainCanvas.FindMainCanvas());
            string Names = string.Empty;
            foreach (Character character in targetList)
            {
                if (Names != string.Empty) Names += ",";
                Names += character.CharacterName;
            }
            current.GetComponent<Text>().text = $"{Names}需要更好的房间";
            return;
        }
        string Residents = string.Empty;
        foreach (Character character in Characters[index])
        {
            if (character == null) continue;
            RecoverHealth(character);
            if (Residents != string.Empty) Residents += ",";
            Residents += character.CharacterName;
        }
        var confirmText = Instantiate(alertPref, MainCanvas.FindMainCanvas());
        confirmText.GetComponent<Text>().text = $"{Residents}入住酒店，将在一天后回复体力并回归";
        RegisterRoom(index);
    }

    public void RecoverHealth(Character character)
    {
        character.health += 2;
        character.awayMessage = "hotel";
        character.Away(1);
    }

    public void RegisterRoom(int index)
    {
        var rooms = Rooms[index].GetComponentsInChildren<HotelCharacterFrame>();
        foreach (HotelCharacterFrame room in rooms)
        {
            room.RoomRegistered();
            room.GetComponent<Button>().interactable = false;
        }
        ConfirmButtons[index].gameObject.SetActive(false);
    }
}
