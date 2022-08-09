using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class DatingCharacterUI : MonoBehaviour, IPointerClickHandler
{
    public Character character;
    public Image CharacterImage;
    public Image BackRarity;
    public Text CharacterName;
    public Image Wisdom;
    public Image Writing;
    public Image Strategy;
    public Image Strength;
    public Image Sneak;
    public Image Defense;
    public void Setup(Character character)
    {
        this.character = character;
        ModifyCardImage();
        ModifyValueColor();
        ModifyCardName();
    }
    private void FixedUpdate()
    {
        if (character.hireStage == HireStage.Hired)
        {
            Destroy(gameObject);
        }
    }
    private void ModifyCardName()
    {
        CharacterName.text = character.CharacterName;
    }
    private void ModifyValueColor()
    {
        var targetDict = character.characterValueRareDict;
        string pathTitle = "Art/人物卡/六大项/字体背景/";
        Wisdom.sprite = Resources.Load<Sprite>((pathTitle + targetDict[CharacterValueType.智]).Replace(" ", string.Empty));
        Writing.sprite = Resources.Load<Sprite>((pathTitle + targetDict[CharacterValueType.才]).Replace(" ", string.Empty));
        Strategy.sprite = Resources.Load<Sprite>((pathTitle + targetDict[CharacterValueType.谋]).Replace(" ", string.Empty));
        Strength.sprite = Resources.Load<Sprite>((pathTitle + targetDict[CharacterValueType.武]).Replace(" ", string.Empty));
        Sneak.sprite = Resources.Load<Sprite>((pathTitle + targetDict[CharacterValueType.刺]).Replace(" ", string.Empty));
        Defense.sprite = Resources.Load<Sprite>((pathTitle + targetDict[CharacterValueType.守]).Replace(" ", string.Empty));
    }
    private void ModifyCardImage()
    {
        Rarerity topRarerity = Rarerity.N;
        var targetDict = character.characterValueRareDict;
        CharacterImage.sprite = Resources.Load<Sprite>(ReturnAssetPath.ReturnCharacterSpritePath(character.characterArtCode)); 
        foreach (CharacterValueType type in targetDict.Keys)
        {
            if ((int)targetDict[type] > (int)topRarerity)
            {
                topRarerity = targetDict[type];
            }
        }
        BackRarity.sprite = Resources.Load<Sprite>(ReturnAssetPath.ReturnDebateCardPath(topRarerity, ReturnAssetPath.CardParts.back));
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        CharacterHiringEvent hireEvent = new GameObject().AddComponent<CharacterHiringEvent>();
        hireEvent.character = character;
        hireEvent.StartHiring();
    }
}
