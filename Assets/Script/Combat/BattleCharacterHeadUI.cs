using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class BattleCharacterHeadUI : MonoBehaviour
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


    public Transform parent;
    public RectTransform valuePannel;
    public RectTransform namePannel;
    public float animationSpeed = 0.2f;
    public void Setup(Character character, BattleType battleType, Transform parentTransform, bool isPlayer)
    {
        IsPlayer = isPlayer;
        parent = parentTransform;
        this.character = character;
        string path = ("Art/CharacterSprites/Idle/Idle_" + this.character.characterArtCode.ToString()).Replace(" ", string.Empty);
        Head.sprite = Resources.Load<Sprite>(path);
        switch (battleType)
        {
            default:
                break;
            case BattleType.Combat:
                //HealthBar.value = character.health / 20;
                Attack.color = CharacterUI.TagUIColorCode[character.characterValueRareDict[CharacterValueType.Îä]];
                Assinate.color = CharacterUI.TagUIColorCode[character.characterValueRareDict[CharacterValueType.´Ì]];
                Defence.color = CharacterUI.TagUIColorCode[character.characterValueRareDict[CharacterValueType.ÊØ]];
                break;
            case BattleType.Debate:
                //HealthBar.value = character.loyalty / 20;
                Attack.color = CharacterUI.TagUIColorCode[character.characterValueRareDict[CharacterValueType.ÖÇ]];
                Assinate.color = CharacterUI.TagUIColorCode[character.characterValueRareDict[CharacterValueType.Ä±]];
                Defence.color = CharacterUI.TagUIColorCode[character.characterValueRareDict[CharacterValueType.²Å]];
                break;
        }
    }
    public void PickSide(bool IsPlayer)
    {
        this.IsPlayer = IsPlayer;
    }

    public void OnSelect()
    {
        GetComponent<RectTransform>()
            .DOPivotX(0.1f, animationSpeed)
            .SetEase(Ease.Linear)
            .SetDelay(animationSpeed);
        valuePannel.DOAnchorPosX(-25, animationSpeed)
            .SetEase(Ease.Linear)
            .SetDelay(animationSpeed);
        namePannel.DOAnchorPosX(-35, animationSpeed)
            .SetEase(Ease.Linear)
            .SetDelay(animationSpeed);
    }
    public void OffSelect()
    {
        GetComponent<RectTransform>()
            .DOPivotX(0.5f, animationSpeed)
            .SetEase(Ease.Linear)
            .SetDelay(animationSpeed);
        valuePannel.DOAnchorPosX(0, animationSpeed)
            .SetEase(Ease.Linear)
            .SetDelay(animationSpeed);
        namePannel.DOAnchorPosX(0, animationSpeed)
            .SetEase(Ease.Linear)
            .SetDelay(animationSpeed);
    }

}
