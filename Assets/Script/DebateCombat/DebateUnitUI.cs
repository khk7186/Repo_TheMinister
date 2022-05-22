using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using DG.Tweening;

public class DebateUnitUI : MonoBehaviour
{
    public DebateUnit debateUnit;
    public Image head;
    public Text Name;
    public Text PointsText;
    public RectTransform CardPool;
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
        CardPool.GetComponent<HorizontalLayoutGroup>().enabled = false;
        foreach (var character in characters)
        {
            var card = Instantiate(Resources.Load<DebateCharacterCard>("Prefabs/DebateCard"));
            card.transform.SetParent(CardPool, false);
            
            yield return new WaitForSeconds(0.1f);
        }
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
    private void Start()
    {
        if (debateUnit && debateUnit.isPlayer)
            StartCoroutine(CloseDeck());
    }
}
