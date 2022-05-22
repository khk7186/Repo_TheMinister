using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
public class DebateCharacterCardUI : MonoBehaviour, IPointerClickHandler
{
    public DebateCharacterCard card;
    public RectTransform mainPannel;
    public RectTransform cardBack;
    public Image characterImage;
    public Text characterName;
    public Image cardBackAsset;
    public Image cardFrontAsset;
    public Image cardFogAsset;
    public RectTransform tagPannel;
    public Text Loyalty;
    public Text Wistom;
    public Text Writing;
    public Text Strategy;
    public Image WistomField;
    public Image WritingField;
    public Image StrategyField;
    private bool OnSelect = false;
    public Character character => card.character;
    public DebateUnit unit => card.unit;
    public bool Acvite => unit.isActive;
    public float selectAnimationSpeed = 0.1f;
    public float selectAnimationRange = 10f;
    public Vector3 mainPannelOrigin;
    public void Setup(DebateCharacterCard card = null)
    {
        if (card != null)
        {
            this.card = card;
        }
        if (this.card == null)
        {
            Debug.Log("card is null");
            return;
        }
        ModifyCharacterStats();
        ModifyCardFrame();
    }
    public void ModifyLoyalty()
    {
        Loyalty.text = character.loyalty.ToString();
    }
    public void ModifyCharacterStats()
    {
        characterImage.sprite = Resources.Load<Sprite>(ReturnAssetPath.ReturnCharacterSpritePath(character.characterArtCode));
        characterName.text = character.CharacterName;
        Wistom.text = character.CharactersValueDict[CharacterValueType.ÖÇ].ToString();
        Writing.text = character.CharactersValueDict[CharacterValueType.²Å].ToString();
        Strategy.text = character.CharactersValueDict[CharacterValueType.Ä±].ToString();
        WistomField.sprite = Resources.Load<Sprite>(ReturnAssetPath.ReturnCharacterStatBackground(character.characterValueRareDict[CharacterValueType.ÖÇ]));
        WritingField.sprite = Resources.Load<Sprite>(ReturnAssetPath.ReturnCharacterStatBackground(character.characterValueRareDict[CharacterValueType.²Å]));
        StrategyField.sprite = Resources.Load<Sprite>(ReturnAssetPath.ReturnCharacterStatBackground(character.characterValueRareDict[CharacterValueType.Ä±]));
    }
    public void ModifyCardFrame()
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
        cardBackAsset.sprite = Resources.Load<Sprite>(ReturnAssetPath.ReturnDebateCardPath(topRarerity, ReturnAssetPath.CardParts.back));
        cardFrontAsset.sprite = Resources.Load<Sprite>(ReturnAssetPath.ReturnDebateCardPath(topRarerity, ReturnAssetPath.CardParts.front));
        cardFogAsset.sprite = Resources.Load<Sprite>(ReturnAssetPath.ReturnDebateCardPath(topRarerity, ReturnAssetPath.CardParts.fog));
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (OnSelect)
        {
            UnSelectCharacter();
        }
        else
        {
            SelectCharacter();
        }
    }
    public void SelectCharacter()
    {
        OnSelect = true;
        StartCoroutine(SelectAnimation());
        unit.selectCharacters.Add(character);
    }
    public void UnSelectCharacter()
    {
        OnSelect = false;
        StartCoroutine(UnSelectAnimation());
        unit.selectCharacters.Remove(character);
    }
    public IEnumerator SelectAnimation()
    {
        float target = mainPannelOrigin.x + selectAnimationRange;
        mainPannel.DOMoveY(target, selectAnimationSpeed);
        yield return null;
    }
    public IEnumerator UnSelectAnimation()
    {
        mainPannel.DOMoveY(mainPannelOrigin.y, selectAnimationSpeed);
        yield return null;
    }
    public IEnumerator ChangeCardSide(bool toFront)
    {
        RectTransform start = toFront ? cardBack : mainPannel;
        RectTransform end = toFront ? mainPannel : cardBack;
        start.DOScaleX(0, selectAnimationSpeed)
            .OnComplete(() => end.DOScaleX(1, selectAnimationSpeed));
        yield return null;
    }
}
