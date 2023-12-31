using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PoliticCharacterSelect : MonoBehaviour, ICharacterSelect, IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler
{
    public static Character SelectedCharacter = null;
    public IPoliticSelectionAction politicSelectionAction = null;
    public Image characterHead;
    public Image characterFrame;
    public Sprite LightFrame;
    public Sprite DarkFrame;
    public Sprite DarkFace = null;
    private void OnEnable()
    {
        SetupEmpty();
    }
    public void SetupEmpty()
    {
        SelectedCharacter = null;
        characterFrame.sprite = DarkFrame;
        characterHead.sprite = DarkFace;
    }
    public void SetCharacter(Character character)
    {
        SelectedCharacter = character;
        var spritePath = ReturnAssetPath.ReturnCharacterSpritePath(character.characterArtCode, false);
        characterHead.sprite = Resources.Load<Sprite>(spritePath);
        if (politicSelectionAction != null) politicSelectionAction.AfterPoliticSelectionEvent();
    }
    public void ChooseCharacter(Character character)
    {
        SetCharacter(character);
    }

    public void CloseInventory()
    {
        var target = GetComponent<SpawnUI>();
        target.CurrentTarget.gameObject.SetActive(false);
    }

    public void CloseInventory(CharacterUI current)
    {
        CloseInventory();
    }

    public void SetupSlotIcon()
    {

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
            target.CurrentTarget.GetComponent<Canvas>().sortingOrder = 104;
        }
        target.CurrentTarget.gameObject.SetActive(true);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        characterFrame.sprite = LightFrame;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        characterFrame.sprite = DarkFrame;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        characterFrame.sprite = DarkFrame;
    }
}
