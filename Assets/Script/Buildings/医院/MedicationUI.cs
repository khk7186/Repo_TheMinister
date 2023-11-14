using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedicationUI : MonoBehaviour
{
    public Button healButton;
    public Button cureButton;
    public GameObject healUI;
    public GameObject cureUI;
    public Character currentCharacter;
    public Image characterImage;
    public Text characterName;
    public Button switchCharacter;
    public CureTagUI TMP;
    public Transform CureContent;
    public int healPrice = 10;
    public Slider healthBar;
    bool OnCure => cureUI?.gameObject.active == true;
    private void Awake()
    {
        cureUI.gameObject.SetActive(false);
        healUI.gameObject.SetActive(true);
        Setup();
    }
    public void Setup()
    {
        currentCharacter = GameObject.FindGameObjectWithTag("PlayerCharacterInventory").GetComponentInChildren<Character>();
        TMP.gameObject.SetActive(false);
        GetComponent<OnSwitchAssets>().character = currentCharacter;
        Setup(currentCharacter);
    }
    public void Setup(Character character)
    {
        currentCharacter = character;
        characterName.text = character.CharacterName;
        characterImage.sprite = Resources.Load<Sprite>(ReturnAssetPath.ReturnCharacterSpritePath(character.characterArtCode));
        if (OnCure)
        {
            SetupCureUI();
        }
        else
        {
            SetupHealUI();
        }

    }
    public void SetupHealUI()
    {
        cureUI.gameObject.SetActive(false);
        healUI.gameObject.SetActive(true);
        healthBar.value = currentCharacter.health / 20f;
    }
    public void SetupCureUI()
    {
        cureUI.gameObject.SetActive(true);
        healUI.gameObject.SetActive(false);
        TransformEx.Clear(CureContent);
        foreach (Tag tag in currentCharacter.tagList)
        {
            if (Player.AllTagRareDict[tag] == Rarerity.B)
            {
                var newTmp = Instantiate(TMP, CureContent);
                newTmp.Setup(tag);
                newTmp.gameObject.SetActive(true);
            }
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(CureContent.GetComponent<RectTransform>());
    }

    public void TryHeal()
    {
        string message = "";
        var currencyInv = FindObjectOfType<CurrencyInventory>();
        if (currentCharacter.health >= 20)
        {
            message = $"{currentCharacter.CharacterName}的生命已经满了";
        }
        else if (currencyInv.Money < healPrice)
        {
            message = "你需要更多银两";
        }
        else
        {
            currencyInv.MoneyAdd(-healPrice);
            currentCharacter.health += 5;

            message = "治疗成功";
            Setup();
        }
        var alert = Instantiate(Resources.Load<RiseUpTextAnimation>("Hiring/Message"), MainCanvas.FindMainCanvas());
        alert.GetComponent<Text>().text = message;
    }
}
