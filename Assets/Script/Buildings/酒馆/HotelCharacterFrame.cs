using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HotelCharacterFrame : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image CharacterHead = null;
    public Button Remove;
    public Image Change;
    public Text PlusSign;
    public GameObject Registered;
    public int Index;
    public void SetupEmpty()
    {
        Remove.gameObject.SetActive(false);
        CharacterHead.gameObject.SetActive(false);
        Change.gameObject.SetActive(false);
        PlusSign.gameObject.SetActive(true);
        Registered.SetActive(false);
    }
    public void Setup(Character character)
    {
        PlusSign.gameObject.SetActive(false);
        Remove.gameObject.SetActive(true);
        CharacterHead.gameObject.SetActive(true);
        var spritePath = ReturnAssetPath.ReturnCharacterSpritePath(character.characterArtCode, false);
        CharacterHead.sprite = Resources.Load<Sprite>(spritePath);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        bool haveCharacter = CharacterHead.gameObject.activeSelf;
        if (haveCharacter && !Registered)
        {
            Change.gameObject.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        bool haveCharacter = CharacterHead.gameObject.activeSelf;
        if (haveCharacter && !Registered)
        {
            Change.gameObject.SetActive(false);
        }
    }

    public void RoomRegistered()
    {
        Registered.SetActive(true);
        PlusSign.gameObject.SetActive(false);
        Remove.gameObject.SetActive(false);
    }
}
