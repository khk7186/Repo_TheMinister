using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEditor;

public enum ItemName
{
    Null,
    ≥§…˙≤ª¿œ“©,
     Æ»´¥Û≤πÕË,
    ∫Õ œËµ,
    ¬‰»’…Òπ≠,
    ±©”Í¿Êª®’Î,
    «‡¡˙∑ΩÍ™,
    ∞Ÿ §µ∂,
    «ÊÃÏ«π,
    ¡˙‘¥Ω£,
    ¿Àª˜¡¨ÂÛ,
    œ…»À◊Ì,
    ª∆Ωº◊,
    ◊Í Ø,
    ¡˙¬Ì,
    ¥Û∫π÷Æ”•,
    ÃÏª˙‘ÏªØµ§,
    “ı—Ù–˛¡˙µ§,
    »Æ,
    ±™◊”,
    œÛª¢,
    …Ω∫£æ≠,
    ª˙πÿ≤–æÌ,
    “ı—Ù∞Àÿ‘≈Ã,
    πÌπ»◊”,
    ≈∑“±◊”µƒ¥Û¥∏,
    ª∆µ€ƒ⁄æ≠,
    ±æ≤›∏Ÿƒø,
    ¥© Ø¡“∑Áπ≠,
    ¡“ª’∂‘∆µ∂,
    ◊œƒæ¿◊µÁ«π,
    º” Æ∂˛µƒ±¶Ω£,
    √¿√Œæ∆,
    »˝Œ∂æ∆,
    ª ÷ÆΩ£,
    ÃÏ∞‘∑ΩÃÏÍ™,
    ªÏ‘™π¶,
    ∏ﬂÃ¿∞◊≤À,
    ¡˙æÆ÷Ò›•,
    ŒƒªØ…≥ƒÆ,
    ∞À±¶“∞—º,
    ∑ ÷ΩæÌ,
    …Ò∆¯µ§,
    —¯∆¯÷˛ª˘…¢,
    “Ω •µƒ“©œ‰,
    ∏Î—™∫Ï,
    ƒæ◊Ù¬Ã,
    Ω¬Ã±¶ Ø,
    À∫∑Á≥‡Õ√¬Ì,
    ¡¡‘∆∞◊¡˙æ‘,
    ∂È‘∆ª¢,
    Õ‰‘¬¿«,
    ÷Ïªß“¬,
    ‘∆Œ∆≈€,
    ≥§–‰◊∞,
    Ω«ÆÔ⁄,
    –‰≈⁄,
    —™µŒ◊”,
    ¡È÷•,
    ƒæ–Î ¡◊”,
    À·≤À∑€Ãı,
    ∫Ï…’«—◊”,
    «Â≥¥≤À–ƒ,
    À‚ﬁ∑≥¥»‚,
    ƒæ–Î»‚,
    ∑–Ã⁄…¢,
    ¡˙ª¢µ§,
    œ¥ÀËµ§,
    ∏ÚÛ°π¶√ÿºÆ,
    ªÎÃÏ“«,
    ±˘À™±¶Ω£,
    ª∆Ωπ≠,
    ∞◊“¯«π,
    ¥Ûø≥µ∂,
    Ã˙∆¨Í™,
    æ≈—Ù’Êæ≠,
    æ≈“ı’Êæ≠,
    ª≈⁄,
    ∂´—Û¥ µ‰,
    Œ˜—Û¥ µ‰,
    Àø≥Ò,
    ≤º“¬,
    ª§–ƒæµ,
    ∆§º◊,
    Ã˙º◊,
    ÀÚ“¬,
    »À≤Œ,
    µ±πÈ,
    ≥¡œ„,
    ÀÆŒÃª®,
    ª¢π«,
     ÿπ¨,
    ”“¬,
    ∫Ï±¶ Ø,
    ◊œÀÆæß,
    µ∞∞◊ Ø,
    ◊Êƒ∏¬Ã,
    ƒ´◊”∑«π•,
    ƒ´◊”ºÊ∞Æ,
    ”˘¬ÌπŸ”°,
    ∂ææ≠,
    Œ®ŒÔ¬€,
    ∂æƒÃ∆ø,
    ∆Âæ˜,
    ÷Ò“∂«‡,
    ∂≈øµæ∆,
    ≈Æ∂˘∫Ï,
    Ωı–Âª™∑˛,
    ªı÷≥¡–¥´,
    ≈∑“±◊”µƒ–°¥∏,
    …À∫Æ‘”≤°¬€,
    ŒÂœ„∑€,
    ªÓ∆√µƒøÏ¬Ì,
    ¿œª¢,
    ¿«,
    ¥∏◊”,
    –Âª®’Î,
    ÷Ï…∞÷¨,
    øÃµ∂,
    ¥ÛÕ¬Ì,
    √…π≈¬Ì,
    ¡π÷›¬Ì,
    ∂Î√º¥Ã,
    –‰º˝,
    –°µ∂,
    ±≥Ω£,
    ŒƒπŸ◊¥,
    Œ‰πŸ◊¥,
    «‡æ∆,
    ª∆æ∆,
    —Úæ∆,
    ¬´æ∆,
    –”» æ∆,
    “¯Ãıæ∆,
    ¡„¬‰µƒ±¶ Ø,
    »±ø⁄µƒ±¶ Ø,
    ”–∆∆Àµƒª∆Ω,
    ≥≥ƒ÷µƒ–ƒ,
    ¡ºΩ™,
    π»—ø,
    ≥¬∆§,
    —Ú»È,
    ∫Ïª®,
    πŸÂ∑ È,
    ‘”ºº,
    ∑Ó◊”µ§,
    ˜Íœ„,
    œ¥‘©¬º,
    øß∑»,
    ºÙµ∂,
    ≥§Ω≈¬Ì,
    ∂ÃŒ≤¬Ì,
    –¢æ≠,
    µÒ,
    √´± ,
    ∑˜≥æ,
    ∑÷È,
    ¬Ìæ≠,
    “©≤ƒ¥Û»´,
    π≠,
    µ∂,
    «π,
    Ω£,
    Í™,
    —›‘±µƒ◊‘Œ“–ﬁ—¯,
    Ã¿Õ∑∏Ëæ˜,
    ∑…ª» Ø,
     ˜“∂,
    ∫Œ ◊Œ⁄,
    Ω¥Ø“©,
    Ã«,
    ÷π—™∏‡,
     Ê∑˛µƒ“Œ◊”,
    «Â≥¥∂π—ø,
    ≈ƒª∆πœ,
    µ∞≥¥∑π,
    «Â’Ù∞◊¬‹≤∑,
    Ã˙øÛ,
    Õ≠øÛ,
    “¯øÛ,
    ≤º∆•,
    ƒæÕ∑,
    ∆§∏Ô,
    √≠∂§,
    ”≤ƒæ,
    ¥Ω÷Ω,
    ÎŸ÷¨,
    ”Õ,
    …˛◊”,
    Ω¥”Õ,
    ¥◊,
    —Œ,
    Œ⁄ËÍ◊”,
    Ã˙‹»,
    ∞ÀΩ«¡´,
    ª∆‹Œ,
    ¬ﬁ∫∫π˚,
    —™∑ÁÃŸ,
    ª∆æ´,
    ∞◊ª®…ﬂ…‡≤›,
    ÀÆæ∆,
    ∂ææ∆,
    ”–»±ø⁄µƒŒ‰∆˜,
    ¿√“¬∑˛,
    ∑ ¬Ì,
    »˝∆ﬂ,
    «·∑€,
    ∫ÀÃ“∑€,
    π˝…Ω¡˙,
    –«≥Ωª®,
    π˜◊”,
    ”Ò ÷ÔÌ,
    ƒæ∑œÒ,
    ≤œÀø,
    ∆§√´,
    ¬È≤º,
    æ∆∫˘¬´,
    «‡÷Ø∑…”„≈€,
    ∆ÌÃÏ–˛“¬,
    ≤ΩÈ˝≈€…¿,
}

public enum ItemType
{
    ±¯∆˜,
    ◊¯∆Ô,
     ÈºÆ,
    ∑˛◊∞,
     Œ∆∑,
    ª˙πÿ,
    ≤À∆∑,
    æ∆∆∑,
    ‘”ªı,
    “©≤ƒ,
    µ§“©,
    ∆Ê ﬁ,
    ≤ƒ¡œ
}
public class ItemUI : MonoBehaviour, IIcon, IPointerClickHandler
{
    public ItemName ItemName;
    public Image icon;
    public Text amount;
    public TagExchangeUI tagExchangeUI;
    public Image Frame;
    public Image Icon => icon;
    public bool InUse = true;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!InUse)
            return;
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //LeftClickAction();
            SetupInUseItem();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            //TODO: destroyed Mother Object
        }
    }
    public virtual void SetupInUseItem()
    {
        GameObject.FindGameObjectWithTag("PlayerItemInventory").GetComponent<ItemInventory>().InUseItem = ItemName;
        FindObjectOfType<FocusImage>().Setup(ItemName);
        FindObjectOfType<OnSwitchAssets>().replacementTag = Use();
        Debug.Log(FindObjectOfType<OnSwitchAssets>().replacementTag);
        FindObjectOfType<OnSwitchAssets>().item = ItemName;
    }
    protected virtual void LeftClickAction()
    {
        PlayerCharactersInventory playerCharactersInventory
            = Resources.Load<PlayerCharactersInventory>("CharacterInvUI/ChraInvUI");

        PlayerCharactersInventory current
            = Instantiate(playerCharactersInventory,
            GameObject.FindGameObjectWithTag("MainUICanvas").transform);
        current.SetupMode(CardMode.ItemSelectMode);

        GameObject.FindGameObjectWithTag("PlayerItemInventory")
            .GetComponent<ItemInventory>().InUseItem = ItemName;

        foreach (CharacterUI characterUI in current.characterUIList)
        {
            characterUI.newTag = Use();
        }
    }
    public virtual void Setup(ItemName item, int amount)
    {
        this.ItemName = item;
        string SpritePath = ("Art/ItemIcon/" + item.ToString()).Replace(" ", string.Empty);
        icon.sprite = Resources.Load<Sprite>(SpritePath);
        this.amount.text = amount.ToString();
        var framRarity = Player.AllTagRareDict[Use()] != Rarerity.B ? Player.AllTagRareDict[Use()] : Rarerity.N;
        string FramePath = $"Art/BuildingUI/‘”ªı∆Ã/≥ıº∂ŒÂΩ∆Ã/ŒÔ∆∑øÚ/ŒÔ∆∑øÚ-{framRarity}";
        Frame.sprite = Resources.Load<Sprite>(FramePath);
        var spritSize = icon.GetComponent<RectTransform>().sizeDelta;
        Frame.GetComponent<RectTransform>().sizeDelta = new Vector2(spritSize.x * 1.16f, spritSize.y * 1.1f);
    }

    public Tag Use()
    {
        Tag output = Tag.Null;
        if (SOItem.ItemMap.ContainsKey(ItemName))
        {
            output = SOItem.ItemMap[ItemName];
            return output;
        }
        else
        {
            Debug.LogError(ItemName);
            return output;
        }


    }

}
