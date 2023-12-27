using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharacterInfoUI : MonoBehaviour, IPointerClickHandler
{
    public bool InfoPro = true;

    public Image Idle;
    public Text Name;

    public Slider loyalty;
    public Slider health;

    public Transform tagHolder;
    public TagSpecUI tagSpecUI;

    public Image Wisdom;
    public Image Writing;
    public Image Strategy;
    public Image Strength;
    public Image Sneak;
    public Image Defense;

    public Text WisdomValue;
    public Text WritingValue;
    public Text StrategyValue;
    public Text StrengthValue;
    public Text SneakValue;
    public Text DefenseValue;

    public Image backGround;
    public List<Image> ShadedImages;

    private Rarerity rarerity;

    public void Setup()
    {
        var character = FindObjectOfType<OnSwitchAssets>().character;
        if (character != null)
        {
            Setup(character);
            return;
        }
        else
        {
            var target = GameObject.FindGameObjectWithTag("PlayerCharacterInventory");
            var choices = target.GetComponentsInChildren<Character>();
            if (choices.Length > 0)
            {
                Setup(choices[0]);
                FindObjectOfType<OnSwitchAssets>().character = choices[0];
            }
        }
    }
    public void Setup(Character character)
    {
        var valueSignController = FindObjectOfType<ValueChangeSignController>();
        valueSignController?.Reset();
        rarerity = character.CheckTopRare();
        if (backGround != null)
        {
            backGround.sprite = Resources.Load<Sprite>($"Art/人物背包/背景/{rarerity}");
        }
        SetValueBG(character);
        Name.text = character.CharacterName;
        SetIdle(character);
        SetValues(character.CharactersValueDict);
        SetTags(character.tagList);
        SetHealthAndLoyalty(character);
        SetOnSelectButton(character);
        SetShadedImages();
    }
    public void SetShadedImages()
    {
        foreach (var image in ShadedImages)
        {
            image.material = Resources.Load<Material>($"Mat/BackInkEffect/{rarerity}");
        }
    }

    public void SetValueColors(Rarerity wisdom, Rarerity writing, Rarerity strategy, Rarerity strength, Rarerity sneak, Rarerity defense)
    {
        var path = "Art/人物卡/六大项/字体背景/";
        Wisdom.sprite = Resources.Load<Sprite>($"{path}{wisdom.ToString()}");
        Writing.sprite = Resources.Load<Sprite>($"{path}{writing.ToString()}"); 
        Strategy.sprite = Resources.Load<Sprite>($"{path}{strategy.ToString()}");
        Strength.sprite = Resources.Load<Sprite>($"{path}{strength.ToString()}"); 
        Sneak.sprite = Resources.Load<Sprite>($"{path}{sneak.ToString()}"); ;
        Defense.sprite = Resources.Load<Sprite>($"{path}{defense.ToString()}"); ;
    }

    public void SetOnSelectButton(Character character)
    {
        foreach (var target in FindObjectsOfType<OndutySelectButton>())
        {
            target.Setup(character);
        }
    }
    public void SetOnSelectButton()
    {
        foreach (var target in FindObjectsOfType<OndutySelectButton>())
        {
            target.Setup();
        }
    }

    public void SetIdle(Character character)
    {
        string idleSpritePath = ("Art/CharacterSprites/Idle/Idle_" + character.characterArtCode.ToString()).Replace(" ", string.Empty);
        Idle.sprite = Resources.Load<Sprite>(idleSpritePath);
    }

    public void SetValues(Dictionary<CharacterValueType, int> dict)
    {
        WisdomValue.text = dict[CharacterValueType.智].ToString();
        StrategyValue.text = dict[CharacterValueType.谋].ToString();
        WritingValue.text = dict[CharacterValueType.才].ToString();
        StrengthValue.text = dict[CharacterValueType.武].ToString();
        SneakValue.text = dict[CharacterValueType.刺].ToString();
        DefenseValue.text = dict[CharacterValueType.守].ToString();
    }

    public void SetTags(List<Tag> tags)
    {
        TransformEx.Clear(tagHolder);
        foreach (Tag tag in tags)
        {
            TagSpecUI thisTag = Instantiate(tagSpecUI, tagHolder);
            thisTag.SetUp(tag);
            //Debug.Log(tag.ToString() + string.Join("," ,Player.TagInfDict[tag]));
        }
    }

    public void SetHealthAndLoyalty(Character character)
    {
        if (health == null || loyalty == null)
        {
            return;
        }
        health.value = character.health;
        loyalty.value = character.loyalty;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && InfoPro)
        {
            AudioManager.Play("翻页");
            var target = FindObjectOfType<PlayerCharactersInventory>();
            if (target != null) target.Reset();
            GetComponent<InvIntroAnimation>().Outro();
        }
    }
    public void SetValueBG(Character character)
    {
        var path = "Art/人物卡/六大项/字体背景/";
        Wisdom.sprite = Resources.Load<Sprite>($"{path}{character.characterValueRareDict[CharacterValueType.智].ToString()}");
        Writing.sprite = Resources.Load<Sprite>($"{path}{character.characterValueRareDict[CharacterValueType.才].ToString()}");
        Strategy.sprite = Resources.Load<Sprite>($"{path}{character.characterValueRareDict[CharacterValueType.谋].ToString()}");
        Strength.sprite = Resources.Load<Sprite>($"{path}{character.characterValueRareDict[CharacterValueType.武].ToString()}");
        Sneak.sprite = Resources.Load<Sprite>($"{path}{character.characterValueRareDict[CharacterValueType.刺].ToString()}");
        Defense.sprite = Resources.Load<Sprite>($"{path}{character.characterValueRareDict[CharacterValueType.守].ToString()}");
    }


}
