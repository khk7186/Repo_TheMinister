using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PoliticFactionMenuUI : MonoBehaviour,IPointerClickHandler
{
    public static PoliticFactionSelectionUI CurrentOnSelect = null;
    public List<PoliticFaction> FactionList = null;
    public List<PoliticFactionSelectionUI> FactionUIList = null;
    public PoliticFactionSelectionUI SelectionPref = null;
    public Transform selectionHolder = null;
    public SOPoliticFaction SOPoliticFaction = null;
    public HorizontalLayoutGroup horizontalLayoutGroup = null;
    public float AnimationSpeed = 0.2f;
    private RectTransform rect => GetComponent<RectTransform>();
    private void Start()
    {
        FactionList = SOPoliticFaction.politicFactions;
        Setup(FactionList);
        //horizontalLayoutGroup.enabled = false;
    }
    public void Reset()
    {
        TransformEx.Clear(selectionHolder);
    }
    public void Show()
    {
        rect.DOAnchorPosY(0, AnimationSpeed);
    }
    public void Hide()
    {
        rect.DOAnchorPosY(-450, AnimationSpeed);
    }
    public void Setup(List<PoliticFaction> factionList)
    {
        Reset();
        foreach (var faction in factionList)
        {
            var clone = Instantiate(SelectionPref, selectionHolder);
            clone.Setup(faction);
            clone.OnSelectAction.AddListener(OnSelect);
        }
        StartCoroutine(BuildLayout());
        FindObjectOfType<PoliticFactionInfoUI>().gameObject.SetActive(false);
    }
    IEnumerator BuildLayout()
    {
        horizontalLayoutGroup.enabled = true;
        Debug.Log("true");
        yield return new WaitForEndOfFrame();
        LayoutRebuilder.ForceRebuildLayoutImmediate(selectionHolder.GetComponent<RectTransform>());
        yield return new WaitForEndOfFrame();
        foreach (var selection in selectionHolder.GetComponentsInChildren<PoliticFactionSelectionUI>())
        {
            selection.OriginX = selection.GetComponent<RectTransform>().anchoredPosition.x;
        }
        horizontalLayoutGroup.enabled = false;
        Debug.Log("false");

    }
    public void OnSelect()
    {
        foreach (var factionUI in FactionUIList)
        {
            if (factionUI != CurrentOnSelect)
            {
                factionUI.Hide();
            }
        }
        //FindObjectOfType<PoliticFactionUIMaster>().OpenInfo();
    }

    private void OnDestroy()
    {
        foreach (var target in FactionUIList)
        {
            target.OnSelectAction.RemoveListener(OnSelect);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Hide();
        }
    }
}
