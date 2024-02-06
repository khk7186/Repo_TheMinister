using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class PoliticFactionSelectionUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public UnityEvent OnSelectAction;
    public UnityEvent DeSelectAction;
    public Image ParentMask = null;
    public Image Idel = null;
    public Text level = null;
    public Text FactionName = null;
    public FactionType factionType;
    private PoliticFaction politicFaction;
    private float moveDuration = 0.2f;
    public float OriginX = 0;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            PoliticFactionMenuUI.CurrentOnSelect = this;
            OnSelectAction.Invoke();
            var infoUI = FindObjectOfType<PoliticFactionInfoUI>(true);
            infoUI.Show();
            infoUI.Setup(politicFaction);
            MoveLeft();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            var infoUI = FindObjectOfType<PoliticFactionInfoUI>();
            if (infoUI != null)
            {
                infoUI.Hide();
            }
            else
            {
                FindObjectOfType<PoliticFactionMenuUI>()?.Hide();
            }
        }
    }
    public void Hide()
    {
        var rect = GetComponent<RectTransform>();
        rect.DOAnchorPosY(250, moveDuration);
        ParentMask.DOFade(0, moveDuration);
    }
    public void Show()
    {
        var rect = GetComponent<RectTransform>();
        rect.DOAnchorPosY(-200, moveDuration);
        ParentMask.DOFade(1, moveDuration);
    }
    public void MoveLeft()
    {
        var rect = GetComponent<RectTransform>();
        rect.DOAnchorPosX(75, moveDuration).SetEase(Ease.InSine);
        DeSelectAction.AddListener(MoveRight);
    }
    public void MoveRight()
    {
        var rect = GetComponent<RectTransform>();
        rect.DOAnchorPosX(OriginX, moveDuration).SetEase(Ease.InSine);
        DeSelectAction.RemoveAllListeners();
    }

    public void Setup(PoliticFaction faction)
    {
        SetIdel(faction.factionType);
        level.text = $"<size=5>势力</size>{faction.level.ToString()}";
        this.politicFaction = faction;
        //OriginX = GetComponent<RectTransform>().anchoredPosition.x;
        FactionName.text = MakeVertical(faction.factionType.ToString());
    }
    public void SetIdel(FactionType factionType)
    {
        switch (factionType)
        {
            case FactionType.李党:
                Idel.sprite = Resources.Load<Sprite>("Art/CharacterSprites/Idle/Idle_李袁陌");
                break;
            case FactionType.九千岁:
                Idel.sprite = Resources.Load<Sprite>("Art/CharacterSprites/Idle/Idle_李阿");
                break;
            case FactionType.于党:
                Idel.sprite = Resources.Load<Sprite>("Art/CharacterSprites/Idle/Idle_官员");
                break;
            case FactionType.士族门阀:
                Idel.sprite = Resources.Load<Sprite>("Art/CharacterSprites/Idle/Idle_张海鹿");
                break;
            case FactionType.刘党:
                Idel.sprite = Resources.Load<Sprite>("Art/CharacterSprites/Idle/Idle_男官");
                break;
            default: break;
        }
    }
    static string MakeVertical(string input)
    {
        if (string.IsNullOrEmpty(input)) return string.Empty;

        // Use Environment.NewLine for compatibility with different OS newline conventions
        return string.Join(Environment.NewLine, input.ToCharArray());
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        ParentMask.GetComponent<RectTransform>().localScale = new Vector2(1f, 1f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ParentMask.GetComponent<RectTransform>().localScale = new Vector2(1.05f, 1.05f);
    }
}
