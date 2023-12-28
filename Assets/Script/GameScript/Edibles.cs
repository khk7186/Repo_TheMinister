using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdiblesItems : MonoBehaviour
{

    public enum EdibleType
    {
        ²İÒ©,
        ²¹Ò©,
        ÏãÁÏ,
        µ÷ÁÏ,
        ËØÊ³,
        »çÊ³
    };
    // Start is called before the first frame update
    public static Dictionary<ItemName, List<int>> FoodRecovery = new Dictionary<ItemName, List<int>>()
    {
        {ItemName.ÎÚèê×Ó,new List<int>(){-3,0}},
        {ItemName.ÌúÜÈ,new List<int>(){-3,0}},
        {ItemName.°Ë½ÇÁ«,new List<int>(){-3,0}},
        {ItemName.»ÆÜÎ,new List<int>(){-3,0}},
        {ItemName.ÂŞºº¹û,new List<int>(){-3,0}},
        {ItemName.Ñª·çÌÙ,new List<int>(){-3,0}},
        {ItemName.»Æ¾«,new List<int>(){-3,0}},
        {ItemName.°×»¨ÉßÉà²İ,new List<int>(){-3,0}},
        {ItemName.ÈıÆß,new List<int>(){-3,0}},
        {ItemName.Çá·Û,new List<int>(){-3,0}},
        {ItemName.¹ıÉ½Áú,new List<int>(){-3,0}},
        {ItemName.ĞÇ³½»¨,new List<int>(){-3,0}},
        {ItemName.ÈË²Î,new List<int>(){2,1}},
        {ItemName.µ±¹é,new List<int>(){2,1}},
        {ItemName.³ÁÏã,new List<int>(){2,1}},
        {ItemName.Ë®ÎÌ»¨,new List<int>(){2,1}},
        {ItemName.»¢¹Ç,new List<int>(){2,1}},
        {ItemName.ÊØ¹¬,new List<int>(){2,1}},
        {ItemName.ÁéÖ¥,new List<int>(){10,1}},
        {ItemName.Á¼½ª,new List<int>(){0,0}},
        {ItemName.¹ÈÑ¿,new List<int>(){0,0}},
        {ItemName.³ÂÆ¤,new List<int>(){0,0}},
        {ItemName.ÑòÈé,new List<int>(){0,0}},
        {ItemName.ºì»¨,new List<int>(){0,0}},
        {ItemName.ºËÌÒ·Û,new List<int>(){0,0}},
        {ItemName.ÓÍ,new List<int>(){0,0}},
        {ItemName.½´ÓÍ,new List<int>(){0,0}},
        {ItemName.´×,new List<int>(){0,0}},
        {ItemName.ÑÎ,new List<int>(){0,0}},
        {ItemName.Ä¾ĞëÊÁ×Ó,new List<int>(){0,3}},
        {ItemName.Ëá²Ë·ÛÌõ,new List<int>(){0,3}},
        {ItemName.ºìÉÕÇÑ×Ó,new List<int>(){0,3}},
        {ItemName.Çå³´²ËĞÄ,new List<int>(){0,3}},
        {ItemName.ËâŞ·³´Èâ,new List<int>(){0,3}},
        {ItemName.Ä¾ĞëÈâ,new List<int>(){0,3}},

    };
}
