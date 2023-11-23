using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;

public class DebateCharacterCardUI : MonoBehaviour, IPointerClickHandler
{
    public int currentSelect
    {
        get
        {
            return unit.characterCards.Where(x => x.CardUI.OnSelect).Count();
        }
    }
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
    public bool OnSelect = false;
    public Character character => card.character;
    public DebateUnit unit => card.unit;
    Rarerity topRarerity;
    public bool Acvite => unit.isActive;
    public float selectAnimationSpeed = 0.1f;
    public float selectAnimationRange = 10f;
    public Vector3 mainPannelOrigin;
    ChangeMaterial changeMaterial => GetComponent<ChangeMaterial>();
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
        ModifyTags();
    }
    public void ModifyLoyalty()
    {
        Loyalty.text = character.loyalty.ToString();
    }
    public void ModifyTags()
    {
        TransformEx.Clear(tagPannel);
        foreach (var tag in character.tagList)
        {
            Image tagUI = Instantiate(Resources.Load<Image>("Tag/Tag"));
            tagUI.transform.SetParent(tagPannel, false);
            tagUI.sprite = Resources.Load<Sprite>($"Art/Tags/{tag.ToString()}");
        }
    }
    public void ModifyCharacterStats()
    {
        characterImage.sprite = Resources.Load<Sprite>(ReturnAssetPath.ReturnCharacterSpritePath(character.characterArtCode));
        characterName.text = character.CharacterName;
        Wistom.text = character.CharactersValueDict[CharacterValueType.智].ToString();
        Writing.text = character.CharactersValueDict[CharacterValueType.才].ToString();
        Strategy.text = character.CharactersValueDict[CharacterValueType.谋].ToString();
        WistomField.sprite = Resources.Load<Sprite>(ReturnAssetPath.ReturnCharacterStatBackground(character.characterValueRareDict[CharacterValueType.智]));
        WritingField.sprite = Resources.Load<Sprite>(ReturnAssetPath.ReturnCharacterStatBackground(character.characterValueRareDict[CharacterValueType.才]));
        StrategyField.sprite = Resources.Load<Sprite>(ReturnAssetPath.ReturnCharacterStatBackground(character.characterValueRareDict[CharacterValueType.谋]));
    }
    public void ModifyCardFrame()
    {
        topRarerity = Rarerity.N;
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
        if (unit.isPlayer == false) return;
        if (OnSelect)
        {
            UnSelectCharacter();
        }
        else
        {
            if (currentSelect >= 3)
            {
                var alert = Instantiate<Text>(Resources.Load<Text>("Hiring/Message"), MainCanvas.FindMainCanvas());
                alert.text = "最多同时选择三名文客辩题 ";
                return;
            }
            SelectCharacter();
        }
    }
    public void SelectCharacter()
    {

        OnSelect = true;
        StartCoroutine(SelectAnimation());
        changeMaterial?.Change(topRarerity.ToString(), cardBackAsset);
        FindObjectOfType<DebateConfirm>(true).gameObject.SetActive(true);
    }
    public void UnSelectCharacter()
    {
        OnSelect = false;
        StartCoroutine(UnSelectAnimation());
        changeMaterial?.UnChange(cardBackAsset);
        if (currentSelect <= 0)
            FindObjectOfType<DebateConfirm>(true)?.gameObject.SetActive(false);
    }
    public IEnumerator SelectAnimation()
    {
        StopAllCoroutines();
        if (mainPannelOrigin == Vector3.zero)
            mainPannelOrigin = GetComponent<RectTransform>().anchoredPosition;
        float target = GetComponent<RectTransform>().anchoredPosition.y + selectAnimationRange;
        GetComponent<RectTransform>().DOAnchorPosY(target, selectAnimationSpeed);
        yield return null;
    }
    public IEnumerator UnSelectAnimation()
    {
        StopAllCoroutines();
        float target = GetComponent<RectTransform>().anchoredPosition.y - selectAnimationRange;
        GetComponent<RectTransform>().DOAnchorPosY(target, selectAnimationSpeed);
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
    public IEnumerator ConfirmCardAnimation(Vector2 targetPos, int total, int index)
    {

        yield return null;
    }
}
