using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameItemFile")]
public class SOItem : ScriptableObject
{
    
    public static Dictionary<ItemName, Tag> ItemMap = new Dictionary<ItemName, Tag>() 
    {
        {ItemName.山海经,Tag.书通二酉},
        {ItemName.机关残卷,Tag.偃师},
        {ItemName.阴阳八卦盘,Tag.奇门遁甲},
        {ItemName.蛤蟆功秘籍,Tag.蛤蟆功},
        {ItemName.浑天仪,Tag.通晓天文},
        {ItemName.冰霜宝剑,Tag.冰霜宝剑},
        {ItemName.火炮,Tag.火炮},
        {ItemName.东洋词典,Tag.东洋语},
        {ItemName.西洋词典,Tag.西洋语},
        {ItemName.羽衣,Tag.能歌善舞},
        {ItemName.杂技,Tag.梧鼠五技},
        {ItemName.奉子丹,Tag.身怀六甲},
        {ItemName.麝香,Tag.不孕不育},
        {ItemName.咖啡,Tag.夜不能寐},
        {ItemName.雕,Tag.雕},
        {ItemName.论语,Tag.儒生},
        {ItemName.道德经,Tag.道士},
        {ItemName.起世经,Tag.僧人},
        {ItemName.毛笔,Tag.儒生},
        {ItemName.拂尘,Tag.道士},
        {ItemName.佛珠,Tag.僧人}
    };
    public static Dictionary<ItemType, List<ItemName>> ItemTypeDict = new Dictionary<ItemType, List<ItemName>>()
    {
        { 
            ItemType.兵器, new List<ItemName>()
            { 
            }
        },
        {
            ItemType.丹药, new List<ItemName>()
            {
            }
        },
        {
            ItemType.书籍, new List<ItemName>()
            {
            }
        },
        {
            ItemType.奇兽, new List<ItemName>()
            {
            }
        },
        {
            ItemType.服装, new List<ItemName>()
            {
            }
        },
        {
            ItemType.机关, new List<ItemName>()
            {
            }
        }
    };
    public Sprite NullSprite;

    private void Awake()
    {
    }



}
