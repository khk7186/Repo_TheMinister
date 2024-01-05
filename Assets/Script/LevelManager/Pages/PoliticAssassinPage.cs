using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PoliticAssassinPage : PoliticPage, IPoliticSelectionAction
{
    public Character target => PoliticCharacterSelect.SelectedCharacter;
    public PoliticCharacterSelect politicCharacterSelect = null;
    public PoliticSlot slot = null;
    public Text titleText = null;
    public Image gateHolderImage = null;
    public Text gateHolderNameText = null;
    public Text difficultyText = null;
    public Text winRateText = null;
    public GameObject winRateObject = null;
    public GameObject ConfirmButton = null;
    public GameObject OngoingView = null;
    public void Setup(PoliticSlot slot)
    {
        this.slot = slot;
        Debug.Log(slot.GateHolder.characterArtCode);
        var spritePath = ReturnAssetPath.ReturnCharacterSpritePath(slot.GateHolder.characterArtCode, false);
        gateHolderImage.sprite = Resources.Load<Sprite>(spritePath);
        gateHolderNameText.text = slot.GateHolder.CharacterName;
        titleText.text = slot.slotName;
        SetDifficulty(slot.GateHolder.AssassinDifficulty);
        politicCharacterSelect.politicSelectionAction = this;
        politicCharacterSelect.SetupEmpty();
        winRateObject.SetActive(false);
        ConfirmButton.SetActive(false);
        if (slot.GateHolder.Assassin != null)
        {
            SetOnGoing();
        }
        else
        {
            
            ConfirmButton.SetActive(true);
            OngoingView.SetActive(false);
        }
    }
    public void TryStartEvent()
    {
        ShowMessage($"{target.CharacterName}已出发");

        StartEvent();
    }
    public void StartEvent()
    {
        PoliticSystemManager.Instance.OngoingAssassinEvents.Add(PoliticAssassinEvent.StartAssassin(slot.GateHolder, target));
        SetOnGoing();
    }
    public void SetOnGoing()
    {
        politicCharacterSelect.SetOnGoing(slot.GateHolder.Assassin);
        ConfirmButton.SetActive(false);
        OngoingView.SetActive(true);
    }
    public void SetOffGoing()
    {
        politicCharacterSelect.SetupEmpty();
        ConfirmButton.SetActive(false);
        OngoingView.SetActive(false);
    }
    public void SetDifficulty(int difficulty)
    {
        string output = string.Empty;
        if (difficulty > 70)
        {
            output = "神仙活";
        }
        else if (difficulty > 40)
        {
            output = "极难";
        }
        else if (difficulty > 30)
        {
            output = "难";
        }
        else if (difficulty > 15)
        {
            output = "一般";
        }
        else if (difficulty > 5)
        {
            output = "简单";
        }
        else
        {
            output = "轻松";
        }
        difficultyText.text = $"刺杀难度\r\n<color=red><size=20>{output}</size></color>";
    }
    public void SetWinRate(float rate)
    {
        string output = string.Empty;
        if (rate > 100 / 100)
        {
            output = "必杀";
        }
        else if (rate > 80 / 100)
        {
            output = "极高";
        }
        else if (rate > 60 / 100)
        {
            output = "较高";
        }
        else if (rate > 40 / 100)
        {
            output = "中等";
        }
        else if (rate > 20 / 100)
        {
            output = "较低";
        }
        else if (rate > 10 / 100)
        {
            output = "低";
        }
        else if (rate > 5 / 100)
        {
            output = "极低";
        }
        else if (rate > 0)
        {
            output = "渺茫";
        }
        else
        {
            output = "不可能";
        }
        winRateText.text = $"成功率\r\n<color=red><size=20>{output}</size></color>";
        winRateObject.SetActive(true);
    }

    public void AfterPoliticSelectionEvent()
    {
        int value = PoliticCharacterSelect.SelectedCharacter.CharactersValueDict[CharacterValueType.刺];
        int total = slot.GateHolder.AssassinDifficulty;
        SetWinRate((float)value / (float)total);
        ConfirmButton.gameObject.SetActive(true);
    }
    public void ShowMessage(string messageString)
    {
        var sampleText = Resources.Load<Text>("Hiring/Message");
        var message = GameObject.Instantiate<Text>(sampleText, MainCanvas.FindMainCanvas());
        message.text = messageString;
    }
}
