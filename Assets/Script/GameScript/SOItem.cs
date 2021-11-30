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
        {ItemName.毛笔,Tag.儒生},
        {ItemName.拂尘,Tag.道士},
        {ItemName.佛珠,Tag.僧人}
    };
    public static Dictionary<ItemType, List<ItemName>> ItemTypeDict = new Dictionary<ItemType, List<ItemName>>()
    {
        { 
            ItemType.兵器, new List<ItemName>()
            {
                ItemName.冰霜宝剑,
                ItemName.火炮,
                ItemName.欧冶子的大锤,
                ItemName.欧冶子的小锤,
                ItemName.弓,
                ItemName.刀,
                ItemName.枪,
                ItemName.剑,
                ItemName.戟
            }
        },
        {
            ItemType.丹药, new List<ItemName>()
            {
                ItemName.奉子丹
            }
        },
        {
            ItemType.书籍, new List<ItemName>()
            {
                ItemName.山海经,
                ItemName.机关残卷,
                ItemName.蛤蟆功秘籍,
                ItemName.东洋词典,
                ItemName.西洋词典,
                ItemName.杂技,
                ItemName.鬼谷子,
                ItemName.黄帝内经,
                ItemName.本草纲目,
                ItemName.墨子非攻,
                ItemName.墨子兼爱,
                ItemName.毒经,
                ItemName.唯物论,
                ItemName.棋诀,
                ItemName.货殖列传,
                ItemName.伤寒杂病论,
                ItemName.官宸书,
                ItemName.洗冤录,
                ItemName.孝经暂,
                ItemName.马经,
                ItemName.药材大全,
                ItemName.演员的自我修养,
                ItemName.汤头歌诀
            }
        },
        {
            ItemType.奇兽, new List<ItemName>()
            {
                ItemName.雕,
                ItemName.吵闹的鹦鹉,
            }
        },
        {
            ItemType.服装, new List<ItemName>()
            {
                ItemName.羽衣
            }
        },
        {
            ItemType.机关, new List<ItemName>()
            {
            }
        },
        {
            ItemType.杂货, new List<ItemName>()
            {
                ItemName.阴阳八卦盘,
                ItemName.浑天仪,
                ItemName.咖啡,
                ItemName.毛笔,
                ItemName.拂尘,
                ItemName.佛珠,
                ItemName.御马官印,
                ItemName.毒奶瓶,
                ItemName.文官状,
                ItemName.武官状,
                ItemName.杂技,
                ItemName.剪刀
            }
        },
        {
            ItemType.药材, new List<ItemName>()
            {
                ItemName.麝香
            }
        }
    };

    public static Dictionary<BuildingType, List<ItemName>> BuildingCraftDict = new Dictionary<BuildingType, List<ItemName>>()
    {
        {
            BuildingType.铁匠铺, new List<ItemName>()
            {
                ItemName.刀,
                ItemName.枪,
                ItemName.剑,
                ItemName.戟,
                ItemName.弓,
                ItemName.穿石烈风弓,
                ItemName.烈火斩云刀,
                ItemName.紫木雷电枪,
                ItemName.百胜刀,
                ItemName.落日神弓,
                ItemName.擎天枪,
                ItemName.龙源剑,
                ItemName.金钱镖,
                ItemName.袖炮
            }
        },
        {
            BuildingType.药铺, new List<ItemName>()
            {
                ItemName.奉子丹,
                ItemName.金疮药,
                ItemName.长生不老药,
                ItemName.十全大补丸,
                ItemName.沸腾散,
                ItemName.龙虎丹,
                ItemName.洗髓丹,
                ItemName.止血膏,
                ItemName.阴阳玄龙丹,
                ItemName.天机造化丹
            }    
        },
        {
            BuildingType.纺织铺, new List<ItemName>()
            {
                ItemName.皮甲,
                ItemName.铁甲,
                ItemName.黄金甲,
                ItemName.云纹袍,
                ItemName.朱户衣,
                ItemName.锦绣华服
            }
        }
    };
    public Sprite NullSprite;




}
