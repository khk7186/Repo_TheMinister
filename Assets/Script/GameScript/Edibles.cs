using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EdibleType
{
    ²İÒ©,
    ²¹Ò©,
    ÏãÁÏ,
    µ÷ÁÏ,
    ËØÊ³,
    »çÊ³,
    Ìğµã
};
public class EdiblesItems : MonoBehaviour
{


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
    public static EdibleType RandomFavor()
    {
        List<EdibleType> list = new List<EdibleType>();
        foreach (EdibleType type in Enum.GetValues(typeof(EdibleType)))
        {
            list.Add(type);
        }
        int index = UnityEngine.Random.Range(0, list.Count);
        return list[index];
    }

    public static Dictionary<EdibleType, List<ItemName>> EdibleTypeDict = new Dictionary<EdibleType, List<ItemName>>()
    {
        {EdibleType.²İÒ©,new List<ItemName>()
        {
        ItemName.ÎÚèê×Ó,
        ItemName.ÌúÜÈ,
        ItemName.°Ë½ÇÁ«,
        ItemName.»ÆÜÎ,
        ItemName.ÂŞºº¹û,
        ItemName.Ñª·çÌÙ,
        ItemName.»Æ¾«,
        ItemName.°×»¨ÉßÉà²İ,
        ItemName.ÈıÆß,
        ItemName.Çá·Û,
        ItemName.¹ıÉ½Áú,
        ItemName.ĞÇ³½»¨,
        }
    },
            {EdibleType.²¹Ò©,new List<ItemName>()
        {
                ItemName.ÈË²Î,
                ItemName.µ±¹é,
                ItemName.³ÁÏã,
                ItemName.Ë®ÎÌ»¨,
                ItemName.»¢¹Ç,
                ItemName.ÊØ¹¬,
                ItemName.ÁéÖ¥,
        }

        },
        {EdibleType.ÏãÁÏ,new List<ItemName>()
        {
                ItemName.Á¼½ª,
                ItemName.¹ÈÑ¿,
                ItemName.³ÂÆ¤,
                ItemName.ÑòÈé,
                ItemName.ºì»¨,
                ItemName.¿§·È,
                ItemName.ºËÌÒ·Û,
        }

        },
        {EdibleType.µ÷ÁÏ,new List<ItemName>()
        {
                ItemName.ÓÍ,
                ItemName.½´ÓÍ,
                ItemName.´×,
                ItemName.ÑÎ,
        }

        },
        {EdibleType.ËØÊ³,new List<ItemName>()
        {
                ItemName.Ä¾ĞëÊÁ×Ó,
                ItemName.Ëá²Ë·ÛÌõ,
                ItemName.ºìÉÕÇÑ×Ó,
                ItemName.Çå³´²ËĞÄ,
                ItemName.Áú¾®Öñİ¥,
        }

        },
        {
            EdibleType.»çÊ³,new List<ItemName>()
            {
                ItemName.ËâŞ·³´Èâ,
                ItemName.Ä¾ĞëÈâ,
                ItemName.°Ë±¦Ò°Ñ¼,
            }
        }
    };
}
