using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoliticAppointPage : PoliticPage, IPoliticSelectionAction
{
    public Character target => PoliticCharacterSelect.SelectedCharacter;
    public PoliticCharacterSelect politicCharacterSelect = null;
    public Image currentOnHold = null;
    public PoliticSlot slot = null;
    public Text titleText = null;
    public Transform TagParent = null;
    public Image Wisdom = null;
    public Image Writing = null;
    public Image Strategy = null;
    public Image Strength = null;
    public Image Sneak = null;
    public Image Defense = null;
    public Transform ValueParent = null;
    public GameObject ConfirmButton = null;
    public GameObject OngoingView = null;
    public TagWithDescribetion tagWithDescribetion = null;
    public Sprite DarkFace = null;

    public void Setup(PoliticSlot slot)
    {
        Reset();
        this.slot = slot;
        titleText.text = slot.slotName;
        currentOnHold.sprite = DarkFace;
        politicCharacterSelect.politicSelectionAction = this;
        politicCharacterSelect.SetupEmpty();
        ConfirmButton.SetActive(false);
        SetTags();
        SetValues();
    }
    public void Reset()
    {
        foreach (Transform child in TagParent)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in ValueParent)
        {
            child.gameObject.SetActive(false);
        }
        currentOnHold.sprite = DarkFace;
        politicCharacterSelect.gameObject.SetActive(true);
        ConfirmButton.gameObject.SetActive(true);
        OngoingView.gameObject.SetActive(false);
    }
    public void SetTags()
    {
        foreach (Tag tag in slot.requestTags)
        {
            var clone = Instantiate(tagWithDescribetion, TagParent);
            clone.Setup(tag);
        }
    }
    public void SetValues()
    {
        if (slot.Wisdom != Rarerity.Null)
        {
            Wisdom.sprite = Resources.Load<Sprite>($"Art/人物卡/六大项/字体背景/{slot.Wisdom.ToString()}");
            Wisdom.gameObject.SetActive(true);
        }
        else { Wisdom.gameObject.SetActive(false); }

        if (slot.Writing != Rarerity.Null)
        {
            Writing.sprite = Resources.Load<Sprite>($"Art/人物卡/六大项/字体背景/{slot.Writing.ToString()}");
            Writing.gameObject.SetActive(true);
        }
        else { Writing.gameObject.SetActive(false); }

        if (slot.Strategy != Rarerity.Null)
        {
            Strategy.sprite = Resources.Load<Sprite>($"Art/人物卡/六大项/字体背景/{slot.Strategy.ToString()}");
            Strategy.gameObject.SetActive(true);
        }
        else { Strategy.gameObject.SetActive(false); }

        if (slot.Strength != Rarerity.Null)
        {
            Strength.sprite = Resources.Load<Sprite>($"Art/人物卡/六大项/字体背景/{slot.Strength.ToString()}");
            Strength.gameObject.SetActive(true);
        }
        else { Strength.gameObject.SetActive(false); }

        if (slot.Sneak != Rarerity.Null)
        {
            Sneak.sprite = Resources.Load<Sprite>($"Art/人物卡/六大项/字体背景/{slot.Sneak.ToString()}");
            Sneak.gameObject.SetActive(true);
        }
        else { Sneak.gameObject.SetActive(false); }

        if (slot.Defense != Rarerity.Null)
        {
            Defense.sprite = Resources.Load<Sprite>($"Art/人物卡/六大项/字体背景/{slot.Defense.ToString()}");
            Defense.gameObject.SetActive(true);
        }
        else { Defense.gameObject.SetActive(false); }
    }
    public void TryStartEvent()
    {
        if (target.loyalty < 10)
        {
            var sampleText = Resources.Load<Text>("Hiring/Message");
            var message = GameObject.Instantiate<Text>(sampleText, MainCanvas.FindMainCanvas());
            message.text = $"{target.CharacterName}的忠诚度过低";
            return;
        }
        if (TestCharacter() == true)
        {
            StartEvent();
        }
        else
        {
            var sampleText = Resources.Load<Text>("Hiring/Message");
            var message = GameObject.Instantiate<Text>(sampleText, MainCanvas.FindMainCanvas());
            message.text = $"{target.CharacterName}不满足职位需求";
        }
    }
    public void StartEvent()
    {
        slot.requestAmount = 0;
        slot.characterOnHold = target;
        slot.CharacterHead.sprite = politicCharacterSelect.characterHead.sprite;
        slot.CharacterHead.gameObject.SetActive(true);
        politicCharacterSelect.gameObject.SetActive(false);
        ConfirmButton.gameObject.SetActive(false);
        OngoingView.gameObject.SetActive(true);
        currentOnHold.sprite = politicCharacterSelect.characterHead.sprite;
        target.hireStage = HireStage.OnCourt;
        target.transform.parent = slot.transform;
        slot.GetComponent<PoliticSlotInteraction>().politicPopup.Setup(slot);
        foreach (var slot in FindObjectsOfType<PoliticSlot>())
        {
            slot.SetupLineSprites();
        }
        //TODO: Show Message
        slot.TrySpecialEffect();
        LevelManager.UpdateLevel();
    }
    public bool TestCharacter()
    {
        var character = target;
        foreach (Tag tag in slot.requestTags)
        {
            if (!character.tagList.Contains(tag)) return false;
        }
        var valueDict = character.characterValueRareDict;
        if (slot.Wisdom > 0 && slot.Wisdom > valueDict[CharacterValueType.智]) return false;
        if (slot.Writing > 0 && slot.Writing > valueDict[CharacterValueType.才]) return false;
        if (slot.Strategy > 0 && slot.Strategy > valueDict[CharacterValueType.谋]) return false;
        if (slot.Strength > 0 && slot.Strength > valueDict[CharacterValueType.武]) return false;
        if (slot.Sneak > 0 && slot.Sneak > valueDict[CharacterValueType.刺]) return false;
        if (slot.Defense > 0 && slot.Defense > valueDict[CharacterValueType.守]) return false;
        return true;
    }
    public void AfterPoliticSelectionEvent()
    {
        ConfirmButton.gameObject.SetActive(true);
    }
}
