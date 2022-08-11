using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterShopCardUI : MonoBehaviour
{
    public Character character;
    public Image back;
    public Image icon;
    public Image front;
    public Text characterName;
    public Text price;
    public Text pristige;
    public Text influence;
    public Button buy;
    internal void Setup(Character character)
    {
        this.character = character;
        Rarerity rarerity = character.CheckTopRare();
        back.sprite = Resources.Load<Sprite>($"Art/BuildingUI/戏馆/青楼二级/青楼人物卡/稀有度背景/{rarerity}");
        front.sprite = Resources.Load<Sprite>($"Art/BuildingUI/戏馆/青楼二级/青楼人物卡/稀有度前景/{rarerity}");
        icon.sprite = Resources.Load<Sprite>(ReturnAssetPath.ReturnCharacterSpritePath(character.characterArtCode));
        characterName.text = character.CharacterName;
        price.text = CharacterShopPriceAndList.ReturnPrice(character.CharacterName)[0].ToString();
        influence.text = CharacterShopPriceAndList.ReturnPrice(character.CharacterName)[1].ToString();
        pristige.text = CharacterShopPriceAndList.ReturnPrice(character.CharacterName)[2].ToString();
        buy.onClick.AddListener(Buy);
    }
    public void Buy()
    {
        bool NonInFileCharacterError = CharacterShopPriceAndList.CharacterPool.ContainsKey(character.CharacterName);
        if (!NonInFileCharacterError)
        {
            Debug.Log("NonInFileCharacterError");
        }
        var Requires = CharacterShopPriceAndList.ReturnPrice(character.CharacterName);
        var currencyInv = FindObjectOfType<CurrencyInventory>();
        string message = "";
        bool alertation = false;
        if (currencyInv.Influence < Requires[1])
        {
            alertation = true;
            message += "需要更多的声望";
        }
        if (currencyInv.Prestige < Requires[2])
        {
            alertation = true;
            if (message != "") message += "以及势力";
            else message += "需要更多的势力";
        }
        if (!alertation)
        {
            if (currencyInv.Money < Requires[0])
            {
                alertation = true;
                message += "需要更多银两";
            }
        }
        var alert = Instantiate<Text>(Resources.Load<Text>("Hiring/Message"), MainCanvas.FindMainCanvas());
        if (alertation)
        {
            alert.text = message;
            return;
        }
        currencyInv.MoneyAdd(-Requires[0]);
        alert.color = Color.white;
        alert.text = $"{character.CharacterName} 拜入门下";
        StartCoroutine(BuyRator());
    }
    public IEnumerator BuyRator()
    {
        character.hireStage = HireStage.Hired;
        Debug.Log(GameObject.FindGameObjectWithTag("PlayerCharacterInventory").name);
        character.transform.SetParent(GameObject.FindGameObjectWithTag("PlayerCharacterInventory").transform);
        CharacterShopPriceAndList.DeleteSomeGirls(new List<string>() { character.CharacterName });
        yield return new WaitUntil(() => character.hireStage == HireStage.Hired);
        Destroy(gameObject);
    }
}
