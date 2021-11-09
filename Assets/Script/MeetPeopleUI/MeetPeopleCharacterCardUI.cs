using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class MeetPeopleCharacterCardUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject TagSlot;
    public GameObject IdleBackground;
    public Image Idle;

    public Character character;
    private GameObject tagPref;
    private CharacterInfoUI characterInfo;

    private void Awake()
    {
        TagSlot.gameObject.SetActive(false);
        GetComponent<RectTransform>().sizeDelta = new Vector2(37.5f, 237.5f);
        IdleBackground.GetComponent<RectTransform>().sizeDelta = new Vector2(37.5f, 237.5f);
        tagPref = Resources.Load<GameObject>("Tag/Tag");
        characterInfo = Resources.Load<CharacterInfoUI>("CharacterInfo/CharacterInfo");
    }



    public void UpdateUI()
    {
        string idleSpritePath = ("Art/CharacterSprites/Idle/Idle_" + character.characterArtCode.ToString()).Replace(" ", string.Empty);
        Idle.sprite = Resources.Load<Sprite>(idleSpritePath);
        var tagList = character.tagList;
        foreach (Tag tag in tagList)
        {
            var newTag = Instantiate(tagPref, TagSlot.transform);
            string FolderPathOfTags = ("Art/Tags/" + tag.ToString()).Replace(" ", string.Empty);
            newTag.GetComponent<Image>().sprite = Resources.Load<Sprite>(FolderPathOfTags);
        }
    }

    public void UpdateUI(Character character)
    {
        this.character = character;
        UpdateUI();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            SelectCharacterInfo();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            GetComponentInParent<RightClickToClose>().RightClickEvent();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(37.5f, 237.5f);
        IdleBackground.GetComponent<RectTransform>().sizeDelta = new Vector2(37.5f, 237.5f);
        TagSlot.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(37.5f * 2, 237.5f);
        IdleBackground.GetComponent<RectTransform>().sizeDelta = new Vector2(37.5f * 2, 237.5f);

        TagSlot.gameObject.SetActive(true);
    }
    public void SelectCharacterInfo()
    {
        CharacterInfoUI currentCharacterInfoUI;
        currentCharacterInfoUI = Instantiate(characterInfo, FindObjectOfType<Canvas>().transform);
        currentCharacterInfoUI.SetUp(character);
    }
}
