using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class PoliticFactionInfoUI : MonoBehaviour, IPointerClickHandler
{
    public FactionType factionType;
    public List<Image> imageList;
    public List<Text> textList;
    public Transform MessageHolder;
    public GameObject MessagePref;
    public Text JobTittle = null;
    public Text CharacterName = null;
    public Text Level = null;
    public Text CharacterStory = null;
    public Transform FriendlyHolder = null;
    public Image FriendlyLevel = null;
    public Text FriendlyLevelText = null;
    private void Awake()
    {
        foreach (Image image in imageList)
        {
            image.DOFade(0, 0);
        }
        foreach (Text text in textList)
        {
            text.DOFade(0, 0);
        }
    }
    public void Setup(PoliticFaction politicFaction)
    {
        factionType = politicFaction.factionType;
        JobTittle.text = politicFaction.factionJobTitle;
        CharacterName.text = politicFaction.factionName;
        
        CharacterStory.text = politicFaction.factionStory;

        if (politicFaction.factionType == FactionType.¿Óµ≥)
        {
            FriendlyHolder.gameObject.SetActive(false);
            Level.text = LevelManager.Instance.level.ToString();
        }
        else
        {
            Level.text = politicFaction.level.ToString();
            FriendlyHolder.gameObject.SetActive(true);
            FriendlyLevel.fillAmount = (float)politicFaction.friendly / 100;
            FriendlyLevelText.text = $"{politicFaction.friendly}/100";
        }
    }
    public void SetMessage(PoliticFaction politicFaction)
    {
        TransformEx.Clear(MessageHolder);
        foreach (var message in politicFaction.messages)
        {
            var parts = message.Split('@');
            var clone = Instantiate(MessagePref, MessageHolder);
            clone.transform.Find("reason").GetComponent<Text>().text = parts[0];
            clone.transform.Find("value").GetComponent<Text>().text = parts[1];
        }
    }
    public void Show()
    {
        gameObject.SetActive(true);
        foreach (Image image in imageList)
        {
            image.DOFade(1, 0.2f);
        }
        foreach (Text text in textList)
        {
            text.DOFade(1, 0.2f);
        }
    }
    public void Hide()
    {
        PoliticFactionMenuUI.CurrentOnSelect.MoveRight();
        PoliticFactionMenuUI.CurrentOnSelect = null;
        foreach (Image image in imageList)
        {
            image.DOFade(0, 0.2f);
        }
        foreach (Text text in textList)
        {
            text.DOFade(0, 0.2f);
        }
        StartCoroutine(DisableAfter());
    }
    IEnumerator DisableAfter()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
    }
    public IEnumerator SetOff()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Hide();
            var selections = FindObjectsOfType<PoliticFactionSelectionUI>();
            foreach (PoliticFactionSelectionUI selection in selections)
            {
                selection.DeSelectAction.Invoke();
            }
        }

    }
}
