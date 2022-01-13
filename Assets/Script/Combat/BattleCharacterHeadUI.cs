using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BattleCharacterHeadUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Image Head;
    public Slider HealthBar;

    public RectTransform CardInfo;

    public Image Attack;
    public Image Defence;
    public Image Assinate;

    public Text AttackValue;
    public Text DefenceValue;
    public Text AssinateValue;

    public bool IsPlayer = true;

    public RectTransform valuePannel;
    private void Awake()
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        SelectThis(true);
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        valuePannel.gameObject.SetActive(true);
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        valuePannel.gameObject.SetActive(false);
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }

    public void Setup(Character character, BattleType battleType)
    {
        string path = ("Art/CharacterSprites/Headshot/" + character.characterArtCode.ToString()).Replace(" ", string.Empty);
        Head.sprite = Resources.Load<Sprite>(path);
        switch (battleType)
        {
            default:
                break;
            case BattleType.Duel:
                HealthBar.value = character.health / 20;
                Attack.color = CharacterUI.TagUIColorCode[character.characterValueRareDict[CharacterValueType.Îä]];
                Assinate.color = CharacterUI.TagUIColorCode[character.characterValueRareDict[CharacterValueType.´Ì]];
                Defence.color = CharacterUI.TagUIColorCode[character.characterValueRareDict[CharacterValueType.ÊØ]];
                break;
            case BattleType.Debate:
                HealthBar.value = character.loyalty / 20;
                Attack.color = CharacterUI.TagUIColorCode[character.characterValueRareDict[CharacterValueType.ÖÇ]];
                Assinate.color = CharacterUI.TagUIColorCode[character.characterValueRareDict[CharacterValueType.Ä±]];
                Defence.color = CharacterUI.TagUIColorCode[character.characterValueRareDict[CharacterValueType.²Å]];
                break;
        }
    }

    public void SelectThis(bool selected)
    {
        if (selected)
        {
            CardInfo.sizeDelta = new Vector2(60f, 50f);
        }
        else
        {

        }
    }

    public void PickSide(bool IsPlayer)
    {
        this.IsPlayer = IsPlayer;
    }
}
