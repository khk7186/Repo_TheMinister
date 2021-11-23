using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum ItemName
{
    Null,
    ÂäÈÕÉñ¹­,
    ±©ÓêÀæ»¨Õë,
    ÇàÁú·½êª,
    °ÙÊ¤µ¶,
    ÇæÌìÇ¹,
    ÁúÔ´½£,
    ÀË»÷Á¬åó,
    ÏÉÈË×í,
    »Æ½ð¼×,
    ×êÊ¯,
    ÁúÂí,
    ´óº¹Ö®Ó¥,
    Ìì»úÔì»¯µ¤,
    ÒõÑôÐþÁúµ¤,
    É½º£¾­,
    »ú¹Ø²Ð¾í,
    ÒõÑô°ËØÔÅÌ,
    ¹í¹È×Ó,
    Å·Ò±×ÓµÄ´ó´¸,
    »ÆµÛÄÚ¾­,
    ±¾²Ý¸ÙÄ¿,
    ¸òó¡¹¦ÃØ¼®,
    »ëÌìÒÇ,
    ±ùËª±¦½£,
    »ðÅÚ,
    ¶«Ñó´Êµä,
    Î÷Ñó´Êµä,
    ÓðÒÂ,
    Ä«×Ó·Ç¹¥,
    Ä«×Ó¼æ°®,
    ÓùÂí¹ÙÓ¡,
    ¶¾¾­,
    Î¨ÎïÂÛ,
    ¶¾ÄÌÆ¿,
    Æå¾÷,
    »õÖ³ÁÐ´«,
    Å·Ò±×ÓµÄÐ¡´¸,
    ÉËº®ÔÓ²¡ÂÛ,
    ÎÄ¹Ù×´,
    Îä¹Ù×´,
    ³³ÄÖµÄðÐðÄ,
    ¹Ùå·Êé,
    ÔÓ¼¼,
    ·î×Óµ¤,
    ÷êÏã,
    Ï´Ô©Â¼,
    ¿§·È,
    ¼ôµ¶,
    Ð¢¾­ÔÝ,
    µñ,
    Ã«±Ê,
    ·÷³¾,
    ·ðÖé,
    Âí¾­,
    Ò©²Ä´óÈ«,
    ¾ÆÆ·,
    ¹­,
    µ¶,
    Ç¹,
    ½£,
    êª,
    ÑÝÔ±µÄ×ÔÎÒÐÞÑø,
    ÌÀÍ·¸è¾÷

}

public enum ItemType
{
    ±øÆ÷,
    ×øÆï,
    Êé¼®,
    ·þ×°,
    ÊÎÆ·,
    »ú¹Ø,
    ²ËÆ·,
    ¾ÆÆ·,
    ÔÓ»õ,
    Ò©²Ä,
    µ¤Ò©,
    ÆæÊÞ
}
public class ItemUI : MonoBehaviour, IIcon, IPointerClickHandler
{
    public ItemName ItemName;
    public Image icon;
    public Text amount;
    public TagExchangeUI tagExchangeUI;

    public Image Icon => icon;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            LeftClickAction();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            //TODO: destroyed Mother Object
        } 

    }

    protected virtual void LeftClickAction()
    {
        PlayerCharactersInventory playerCharactersInventory = Resources.Load<PlayerCharactersInventory>("CharacterInvUI/ChraInvUI");
        PlayerCharactersInventory current = Instantiate(playerCharactersInventory, GameObject.FindGameObjectWithTag("MainUICanvas").transform);
        GameObject.FindGameObjectWithTag("PlayerItemInventory").GetComponent<ItemInventory>().InUseItem = ItemName;
        foreach (CharacterUI characterUI in current.characterUIList)
        {
            characterUI.newTag = Use();
        }
    }

    public void SetUp(ItemName item, int amount)
    {
        this.ItemName = item;
        string SpritePath = ("Art/ItemIcon/" + item.ToString()).Replace(" ", string.Empty);
        icon.sprite = Resources.Load<Sprite>(SpritePath);
        this.amount.text = amount.ToString();
    }

    public Tag Use()
    {
        return SOItem.ItemMap[this.ItemName];
    }

}
