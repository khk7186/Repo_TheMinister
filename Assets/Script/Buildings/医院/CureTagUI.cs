using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CureTagUI : MonoBehaviour
{
    public Tag OriginTag;
    public Image tagImage;
    public Button tagButton;
    public int price = 100;

    public void Setup(Tag tag)
    {
        OriginTag = tag;
        tagImage.sprite = Resources.Load<Sprite>(ReturnAssetPath.ReturnTagPath(tag));
        //tagButton.onClick.AddListener(() =>
        //{
        //});
    }
    public void TryCure()
    {
        string message = "";
        if(FindObjectOfType<CurrencyInventory>().Money< price)
        {
            message = "你需要更多银两";
            var alert =Instantiate( Resources.Load<RiseUpTextAnimation>("Hiring/Message"),MainCanvas.FindMainCanvas());
            alert.GetComponent<Text>().text = message;
            return;
        }
        message = $"确认花费{price}银两治愈并移除“{OriginTag}”词条？\n（治疗后将获得新词条“无伤大雅”）";
        var confirm = Confirmation.CreateNewComfirmation(Cure,message);
        StartCoroutine(confirm.Confirm());
    }
    public void Cure()
    {
        var character = FindObjectOfType<OnSwitchAssets>().character;
        character.ExchangeTag(Tag.无伤大雅, OriginTag);
        FindObjectOfType<CurrencyInventory>().MoneyAdd(-price);
        string message = $"治愈{character.CharacterName}成功";
        var alert = Instantiate(Resources.Load<RiseUpTextAnimation>("Hiring/Message"), MainCanvas.FindMainCanvas());
        alert.GetComponent<Text>().text = message;
        Destroy(gameObject);
    }
}
