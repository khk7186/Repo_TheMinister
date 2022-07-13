using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using DG.Tweening;
public class DebateUnitUI : MonoBehaviour
{
    public DebateUnit debateUnit;
    public int index = 0;
    public Image head;
    public Text Name;
    public Text PointsText;
    public RectTransform CardPool;
    public float singleCardFlipDuration = 0.2f;
    public float deckAnimationDuration = 0.5f;
    public float deckOpenSpace = 2f;
    public AnimationCurve cardPoolAnim;
    public void Setup(DebateUnit unit)
    {
        debateUnit = unit;
        Setup();
    }
    public void Setup()
    {
        if (debateUnit == null)
            return;
        string ImagePath = ReturnAssetPath.ReturnCharacterSpritePath(debateUnit.IconArtCode, false);
        head.sprite = Resources.Load<Sprite>(ImagePath);
        Name.text = debateUnit.Name;
        UpdatePoints();
        StartCoroutine(SpawnCards());
    }
    public void UpdatePoints()
    {
        PointsText.text = debateUnit.Points.ToString();
    }
    public IEnumerator OpenDeck()
    {
        var horiLay = CardPool.GetComponentInChildren<HorizontalLayoutGroup>();
        if (debateUnit && debateUnit.isPlayer)
        {
            float dropRange = 60f;
            var target = horiLay.GetComponent<RectTransform>();
            var OriginY = target.anchoredPosition.y;
            target.DOAnchorPosY(OriginY + dropRange, deckAnimationDuration);
        }
        horiLay.spacing = deckOpenSpace;
        var originSpace = -65.5f;
        float time = 0;
        while (time < deckAnimationDuration)
        {

            Debug.Log(time);
            time += Time.deltaTime * deckAnimationDuration;
            horiLay.spacing = Mathf.Lerp(originSpace, deckOpenSpace, cardPoolAnim.Evaluate(time / deckAnimationDuration));
            LayoutRebuilder.ForceRebuildLayoutImmediate(horiLay.GetComponent<RectTransform>());
            yield return null;
        }
        if (debateUnit.isPlayer)
        {
            debateUnit.isActive = true;
        }
    }
    public IEnumerator SpawnCards()
    {
        var characters = debateUnit.characters;
        TransformEx.Clear(CardPool);
        CardPool.GetComponent<HorizontalLayoutGroup>().enabled = false;
        float index = 0;
        float gap = CardPool.GetComponent<HorizontalLayoutGroup>().spacing;
        CardPool.GetComponent<HorizontalLayoutGroup>().enabled = false;
        foreach (var character in characters)
        {
            var cardObject = Instantiate(Resources.Load<DebateCharacterCardUI>("DebateScene/CharacterCard"))
                                                                                                                .GetComponent<DebateCharacterCard>();
            var cardRT = cardObject.GetComponent<RectTransform>();
            cardRT.anchoredPosition = new Vector2(0f, 19f);
            cardRT.localScale = new Vector2(0f, 1f);
            cardObject.unit = debateUnit;
            cardObject.Setup(character);
            cardRT.DOScaleX(1f, singleCardFlipDuration);
            float targetX = index * (cardRT.sizeDelta.x + gap);
            index++;
            cardRT.DOAnchorPosX(targetX, singleCardFlipDuration);
            cardRT.SetParent(CardPool, false);
            debateUnit.characterCards.Add(cardRT.GetComponent<DebateCharacterCard>());
            yield return new WaitForSeconds(singleCardFlipDuration);
        }
        CardPool.GetComponent<HorizontalLayoutGroup>().enabled = true;
        LayoutRebuilder.ForceRebuildLayoutImmediate(CardPool);
    }
    public IEnumerator CloseDeck()
    {
        debateUnit.isActive = false;
        var horiLay = CardPool.GetComponentInChildren<HorizontalLayoutGroup>();
        horiLay.spacing = deckOpenSpace;
        var targetSpace = -65.5f;
        float time = 0;
        while (time < deckAnimationDuration)
        {
            Debug.Log(time);
            time += Time.deltaTime * deckAnimationDuration;
            horiLay.spacing = Mathf.Lerp(deckOpenSpace, targetSpace, cardPoolAnim.Evaluate(time / deckAnimationDuration));
            LayoutRebuilder.ForceRebuildLayoutImmediate(horiLay.GetComponent<RectTransform>());
            yield return null;
        }
        if (debateUnit && debateUnit.isPlayer)
        {
            float dropRange = -60f;
            var target = horiLay.GetComponent<RectTransform>();
            var OriginY = target.anchoredPosition.y;
            target.DOAnchorPosY(OriginY + dropRange, deckAnimationDuration);
        }
    }
    public IEnumerator ShowCards()
    {
        var card = GetComponent<RectTransform>();
        Vector2 origin = card.anchoredPosition;

        int index = 0;
        foreach (DebateCharacterCard selected in debateUnit.SelectedCards)
        {
            if (debateUnit.isPlayer)
                selected.CardUI.StartCoroutine(selected.CardUI.ChangeCardSide(true));
            selected.CardUI.StartCoroutine(selected.CardUI.ConfirmCardAnimation
            (debateUnit.cardConfirmPosition, debateUnit.SelectedCards.Count, index));
            index++;
            yield return null;
        }
    }
    private void Start()
    {
        //if (debateUnit && debateUnit.isPlayer)
        //    StartCoroutine(CloseDeck());
    }
}
