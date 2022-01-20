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

    public Character character;

    public bool IsPlayer = true;

    public RectTransform valuePannel;

    public Transform parent;
    public Transform valueResizeblePannel;
    public void OnPointerClick(PointerEventData eventData)
    {
        parent.GetComponent<BattleUI>().SelectCurrentCharacter(this);
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
    public void Setup(Character character, BattleType battleType, Transform parentTransform, bool isPlayer)
    {
        IsPlayer = isPlayer;
        GetComponent<HorizontalLayoutGroup>().reverseArrangement = (!IsPlayer);
        valueResizeblePannel.GetComponent<HorizontalLayoutGroup>().reverseArrangement = (!IsPlayer);
        parent = parentTransform;
        this.character = character;
        string path = ("Art/CharacterSprites/Headshot/Headshot_" + this.character.characterArtCode.ToString()).Replace(" ", string.Empty);
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
            CardInfo.sizeDelta = new Vector2(30f, 50f);
        }
    }
    public void PickSide(bool IsPlayer)
    {
        this.IsPlayer = IsPlayer;
    }
    private void Start()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }
}
