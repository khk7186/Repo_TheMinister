using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public enum EdibleType
{
    草药,
    补药,
    香料,
    调料,
    素食,
    荤食,
    甜点,
    酒水,
    丹药
};
public class EdiblesItems : MonoBehaviour
{


    // Start is called before the first frame update
    public static Dictionary<ItemName, List<int>> FoodRecovery = new Dictionary<ItemName, List<int>>()
    {
        {ItemName.乌桕子,new List<int>(){-3,0}},
        {ItemName.铁苋,new List<int>(){-3,0}},
        {ItemName.八角莲,new List<int>(){-3,0}},
        {ItemName.黄芪,new List<int>(){-3,0}},
        {ItemName.罗汉果,new List<int>(){-3,0}},
        {ItemName.血风藤,new List<int>(){-3,0}},
        {ItemName.黄精,new List<int>(){-3,0}},
        {ItemName.白花蛇舌草,new List<int>(){-3,0}},
        {ItemName.三七,new List<int>(){-3,0}},
        {ItemName.轻粉,new List<int>(){-3,0}},
        {ItemName.过山龙,new List<int>(){-3,0}},
        {ItemName.星辰花,new List<int>(){-3,0}},
        {ItemName.麝香,new List<int>(){-3,0}},
        {ItemName.人参,new List<int>(){2,1}},
        {ItemName.当归,new List<int>(){2,1}},
        {ItemName.沉香,new List<int>(){2,1}},
        {ItemName.水翁花,new List<int>(){2,1}},
        {ItemName.虎骨,new List<int>(){2,1}},
        {ItemName.守宫,new List<int>(){2,1}},
        {ItemName.何首乌,new List<int>(){1,0}},
        {ItemName.灵芝,new List<int>(){10,1}},
        {ItemName.良姜,new List<int>(){0,1}},
        {ItemName.谷芽,new List<int>(){0,1}},
        {ItemName.陈皮,new List<int>(){0,1}},
        {ItemName.羊乳,new List<int>(){0,1}},
        {ItemName.红花,new List<int>(){0,1}},
        {ItemName.核桃粉,new List<int>(){0,1}},
        {ItemName.咖啡,new List<int>(){0,1}},
        {ItemName.油,new List<int>(){0,1}},
        {ItemName.酱油,new List<int>(){0,1}},
        {ItemName.醋,new List<int>(){0,1}},
        {ItemName.盐,new List<int>(){0,1}},
        {ItemName.五香粉,new List<int>(){0,1}},
        {ItemName.木须柿子,new List<int>(){0,5}},
        {ItemName.酸菜粉条,new List<int>(){0,5}},
        {ItemName.红烧茄子,new List<int>(){0,5}},
        {ItemName.清炒菜心,new List<int>(){0,5}},
        {ItemName.高汤白菜,new List<int>(){0,7}},
        {ItemName.龙井竹荪,new List<int>(){0,7}},
        {ItemName.清炒豆芽,new List<int>(){0,4}},
        {ItemName.拍黄瓜,new List<int>(){0,4}},
        {ItemName.蛋炒饭,new List<int>(){0,4}},
        {ItemName.清蒸白萝卜,new List<int>(){0,4}},
        {ItemName.蒜薹炒肉,new List<int>(){0,5}},
        {ItemName.木须肉,new List<int>(){0,5}},
        {ItemName.八宝野鸭,new List<int>(){0,7}},
        {ItemName.佛手金卷,new List<int>(){0,7}},
        {ItemName.水酒,new List<int>(){-2,0}},
        {ItemName.毒酒,new List<int>(){-4,0}},
        {ItemName.青酒,new List<int>(){-1,0}},
        {ItemName.黄酒,new List<int>(){-1,0}},
        {ItemName.羊酒,new List<int>(){-1,0}},
        {ItemName.芦酒,new List<int>(){-1,0}},
        {ItemName.杏仁酒,new List<int>(){-1,0}},
        {ItemName.银条酒,new List<int>(){-1,0}},
        {ItemName.竹叶青,new List<int>(){1,0}},
        {ItemName.杜康酒,new List<int>(){1,0}},
        {ItemName.女儿红,new List<int>(){1,0}},
        {ItemName.美梦酒,new List<int>(){2,0}},
        {ItemName.三味酒,new List<int>(){2,0}},
        {ItemName.仙人醉,new List<int>(){4,0}},
        {ItemName.止血膏,new List<int>(){4,0}},
        {ItemName.金疮药,new List<int>(){4,0}},
        {ItemName.奉子丹,new List<int>(){-1,0}},
        {ItemName.龙虎丹,new List<int>(){1,0}},
        {ItemName.洗髓丹,new List<int>(){1,0}},
        {ItemName.神气丹,new List<int>(){2,0}},
        {ItemName.养气筑基散,new List<int>(){2,0}},
        {ItemName.天机造化丹,new List<int>(){3,0}},
        {ItemName.阴阳玄龙丹,new List<int>(){10,0}},
        {ItemName.长生不老药,new List<int>(){20,0}},
        {ItemName.十全大补丸,new List<int>(){20,0}},
        {ItemName.干粮,new List<int>(){0,10}},
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
        {EdibleType.草药,new List<ItemName>()
        {
        ItemName.乌桕子,
        ItemName.铁苋,
        ItemName.八角莲,
        ItemName.黄芪,
        ItemName.罗汉果,
        ItemName.血风藤,
        ItemName.黄精,
        ItemName.白花蛇舌草,
        ItemName.三七,
        ItemName.轻粉,
        ItemName.过山龙,
        ItemName.星辰花,
        ItemName.麝香,
        }
    },
            {EdibleType.补药,new List<ItemName>()
        {
                ItemName.人参,
                ItemName.当归,
                ItemName.沉香,
                ItemName.水翁花,
                ItemName.虎骨,
                ItemName.守宫,
                ItemName.何首乌,
                ItemName.灵芝,
        }

        },
        {EdibleType.香料,new List<ItemName>()
        {
                ItemName.良姜,
                ItemName.谷芽,
                ItemName.陈皮,
                ItemName.羊乳,
                ItemName.红花,
                ItemName.核桃粉,
                ItemName.咖啡
        }

        },
        {EdibleType.调料,new List<ItemName>()
        {
                ItemName.油,
                ItemName.酱油,
                ItemName.醋,
                ItemName.盐,
                ItemName.五香粉
        }

        },
        {EdibleType.素食,new List<ItemName>()
        {
                ItemName.木须柿子,
                ItemName.酸菜粉条,
                ItemName.红烧茄子,
                ItemName.清炒菜心,
                ItemName.高汤白菜,
                ItemName.龙井竹荪,
                ItemName.清炒豆芽,
                ItemName.拍黄瓜,
                ItemName.蛋炒饭,
                ItemName.清蒸白萝卜,
                ItemName.干粮
        }

        },
        {
            EdibleType.荤食,new List<ItemName>()
            {
                ItemName.蒜薹炒肉,
                ItemName.木须肉,
                ItemName.八宝野鸭,
                ItemName.佛手金卷
            }
        },
         {
            EdibleType.酒水,new List<ItemName>()
            {
                ItemName.水酒,
                ItemName.毒酒,
                ItemName.青酒,
                ItemName.黄酒,
                ItemName.羊酒,
                ItemName.芦酒,
                ItemName.杏仁酒,
                ItemName.银条酒,
                ItemName.竹叶青,
                ItemName.杜康酒,
                ItemName.女儿红,
                ItemName.美梦酒,
                ItemName.三味酒,
                ItemName.仙人醉
            }
        },
         {
            EdibleType.丹药,new List<ItemName>()
            {
                ItemName.止血膏,
                ItemName.金疮药,
                ItemName.奉子丹,
                ItemName.龙虎丹,
                ItemName.洗髓丹,
                ItemName.神气丹,
                ItemName.养气筑基散,
                ItemName.天机造化丹,
                ItemName.阴阳玄龙丹,
                ItemName.长生不老药,
                ItemName.十全大补丸
            }
        },
    };

    public static Dictionary<ItemName, Tag> ItemToTempDict = new Dictionary<ItemName, Tag>()
    {
        {ItemName.人参,Tag.益血},
        {ItemName.虎骨,Tag.固肾},
        {ItemName.咖啡,Tag.提神},
        {ItemName.毒酒,Tag.中毒},
        {ItemName.龙虎丹,Tag.淬体},
        {ItemName.洗髓丹,Tag.淬体},
        {ItemName.神气丹,Tag.淬体},
        {ItemName.养气筑基散,Tag.淬体},
        {ItemName.天机造化丹,Tag.养神},
    };
    public static Dictionary<ItemName, int> ItemTempDuration = new Dictionary<ItemName, int>()
    {
        {ItemName.人参,4},
        {ItemName.虎骨,4},
        {ItemName.咖啡,4},
        {ItemName.毒酒,6},
        {ItemName.龙虎丹,2},
        {ItemName.洗髓丹,2},
        {ItemName.神气丹,3},
        {ItemName.养气筑基散,3},
        {ItemName.天机造化丹,4},

    };
    public static bool IsEdible(ItemName item)
    {
        if (FoodRecovery.Keys.ToList().Contains(item)) return true;
        return false;
    }
    public static EdibleType GetEdibleType(ItemName item)
    {
        foreach (var unit in EdibleTypeDict)
        {
            if (unit.Value.Contains(item))
            {
                return unit.Key;
            }
        }
        return EdibleType.草药;
    }
}
