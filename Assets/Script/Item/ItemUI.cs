using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum ItemName
{
    Null,
    ³¤Éú²»ÀÏÒ©,
    Ê®È«´ó²¹Íè,
    ºÍÊÏèµ,
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
    È®,
    ±ª×Ó,
    Ïó»¢,
    É½º£¾­,
    »ú¹Ø²Ð¾í,
    ÒõÑô°ËØÔÅÌ,
    ¹í¹È×Ó,
    Å·Ò±×ÓµÄ´ó´¸,
    »ÆµÛÄÚ¾­,
    ±¾²Ý¸ÙÄ¿,
    ´©Ê¯ÁÒ·ç¹­,
    ÁÒ»ðÕ¶ÔÆµ¶,
    ×ÏÄ¾À×µçÇ¹,
    ¼ÓÊ®¶þµÄ±¦½£,
    ÃÀÃÎ¾Æ,
    ÈýÎ¶¾Æ,
    »ÊÖ®½£,
    Ìì°Ô·½Ììêª,
    »ìÔª¹¦,
    ¸ßÌÀ°×²Ë,
    Áú¾®ÖñÝ¥,
    ÎÄ»¯É³Ä®,
    °Ë±¦Ò°Ñ¼,
    ·ðÊÖ½ð¾í,
    ÉñÆøµ¤,
    ÑøÆøÖþ»ùÉ¢,
    Ò½Ê¥µÄÒ©Ïä,
    ¸ëÑªºì,
    Ä¾×ôÂÌ,
    ½ðÂÌ±¦Ê¯,
    Ëº·ç³àÍÃÂí,
    ÁÁÔÆ°×Áú¾Ô,
    ¶éÔÆ»¢,
    ÍäÔÂÀÇ,
    Öì»§ÒÂ,
    ÔÆÎÆÅÛ,
    ³¤Ðä×°,
    ½ðÇ®ïÚ,
    ÐäÅÚ,
    ÑªµÎ×Ó,
    ÁéÖ¥,
    Ä¾ÐëÊÁ×Ó,
    Ëá²Ë·ÛÌõ,
    ºìÉÕÇÑ×Ó,
    Çå³´²ËÐÄ,
    ËâÞ·³´Èâ,
    Ä¾ÐëÈâ,
    ·ÐÌÚÉ¢,
    Áú»¢µ¤,
    Ï´Ëèµ¤,
    ¸òó¡¹¦ÃØ¼®,
    »ëÌìÒÇ,
    ±ùËª±¦½£,
    »Æ½ð¹­,
    °×ÒøÇ¹,
    ´ó¿³µ¶,
    ÌúÆ¬êª,
    ¾ÅÑôÕæ¾­,
    ¾ÅÒõÕæ¾­,
    »ðÅÚ,
    ¶«Ñó´Êµä,
    Î÷Ñó´Êµä,
    Ë¿³ñ,
    ²¼ÒÂ,
    »¤ÐÄ¾µ,
    Æ¤¼×,
    Ìú¼×,
    ËòÒÂ,
    ÈË²Î,
    µ±¹é,
    ³ÁÏã,
    Ë®ÎÌ»¨,
    »¢¹Ç,
    ÊØ¹¬,
    ÓðÒÂ,
    ºì±¦Ê¯,
    ×ÏË®¾§,
    µ°°×Ê¯,
    ×æÄ¸ÂÌ,
    Ä«×Ó·Ç¹¥,
    Ä«×Ó¼æ°®,
    ÓùÂí¹ÙÓ¡,
    ¶¾¾­,
    Î¨ÎïÂÛ,
    ¶¾ÄÌÆ¿,
    Æå¾÷,
    ÖñÒ¶Çà,
    ¶Å¿µ¾Æ,
    Å®¶ùºì,
    ½õÐå»ª·þ,
    »õÖ³ÁÐ´«,
    Å·Ò±×ÓµÄÐ¡´¸,
    ÉËº®ÔÓ²¡ÂÛ,
    ÎåÏã·Û,
    »î²¦µÄ¿ìÂí,
    ðÐðÄ,
    ÀÏ»¢,
    ÀÇ,
    ´¸×Ó,
    Ðå»¨Õë,
    ÖìÉ°Ö¬,
    ¿Ìµ¶,
    ´óÍðÂí,
    ÃÉ¹ÅÂí,
    Á¹ÖÝÂí,
    ¶ëÃ¼´Ì,
    Ðä¼ý,
    Ð¡µ¶,
    ±³½£,
    ÎÄ¹Ù×´,
    Îä¹Ù×´,
    Çà¾Æ,
    »Æ¾Æ,
    Ñò¾Æ,
    Â«¾Æ,
    ÐÓÈÊ¾Æ,
    ÒøÌõ¾Æ,
    ÁãÂäµÄ±¦Ê¯,
    È±¿ÚµÄ±¦Ê¯,
    ÓÐÆÆËðµÄ»Æ½ð,
    ³³ÄÖµÄðÐðÄ,
    Á¼½ª,
    ¹ÈÑ¿,
    ³ÂÆ¤,
    ÑòÈé,
    ºì»¨,
    ¹Ùå·Êé,
    ÔÓ¼¼,
    ·î×Óµ¤,
    ÷êÏã,
    Ï´Ô©Â¼,
    ¿§·È,
    ¼ôµ¶,
    ³¤½ÅÂí,
    ¶ÌÎ²Âí,
    Ð¢¾­ÔÝ,
    µñ,
    Ã«±Ê,
    ·÷³¾,
    ·ðÖé,
    Âí¾­,
    Ò©²Ä´óÈ«,
    ¹­,
    µ¶,
    Ç¹,
    ½£,
    êª,
    ÑÝÔ±µÄ×ÔÎÒÐÞÑø,
    ÌÀÍ·¸è¾÷,
    ·É»ÈÊ¯,
    Ê÷Ò¶,
    ºÎÊ×ÎÚ,
    ½ð´¯Ò©,
    ÌÇ,
    Ö¹Ñª¸à,
    Êæ·þµÄÒÎ×Ó,
    Çå³´¶¹Ñ¿,
    ÅÄ»Æ¹Ï,
    µ°³´·¹,
    ÇåÕô°×ÂÜ²·,
    Ìú¿ó,
    Í­¿ó,
    Òø¿ó,
    ²¼Æ¥,
    Ä¾Í·,
    Æ¤¸ï,
    Ã­¶¤,
    Ó²Ä¾,
    ´½Ö½,
    ëÙÖ¬,
    ÓÍ,
    Éþ×Ó,
    ½´ÓÍ,
    ´×,
    ÑÎ,
    ÎÚèê×Ó,
    ÌúÜÈ,
    °Ë½ÇÁ«,
    »ÆÜÎ,
    ÂÞºº¹û,
    Ñª·çÌÙ,
    »Æ¾«,
    °×»¨ÉßÉà²Ý,
    Ë®¾Æ,
    ¶¾¾Æ,
    ÓÐÈ±¿ÚµÄÎäÆ÷,
    ÀÃÒÂ·þ,
    ·ÊÂí,
    ÈýÆß,
    Çá·Û,
    ºËÌÒ,
    ¹ýÉ½Áú,
    ÐÇ³½»¨



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
        current.SetupMode(CardMode.ItemSelectMode);
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
