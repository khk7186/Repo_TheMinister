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
        {ItemName.佛珠,Tag.僧人},
        {ItemName.落日神弓,Tag.穿日},
        {ItemName.暴雨梨花针,Tag.无声},
        {ItemName.青龙方戟,Tag.青龙},
        {ItemName.百胜刀,Tag.必胜},
        {ItemName.擎天枪,Tag.撑天},
        {ItemName.龙源剑,Tag.龙之力},
        {ItemName.浪击连弩,Tag.火力压制},
        {ItemName.仙人醉,Tag.醉生梦死},
        {ItemName.黄金甲,Tag.金光闪闪},
        {ItemName.钻石,Tag.光碎 },
        {ItemName.龙马,Tag.龙马精神},
        {ItemName.大汗之鹰,Tag.鹰之力},
        {ItemName.天机造化丹,Tag.窥得天机},
        {ItemName.阴阳玄龙丹,Tag.百毒不侵},
        {ItemName.犬,Tag.嘤嘤狂吠},
        {ItemName.豹子,Tag.波纹行走},
        {ItemName.象虎,Tag.象虎之力},
        {ItemName.穿石烈风弓,Tag.百步穿杨},
        {ItemName.烈火斩云刀,Tag.刀王},
        {ItemName.紫木雷电枪,Tag.雷电法王},
        {ItemName.加十二的宝剑,Tag.氪金战士},
        {ItemName.美梦酒,Tag.诗兴大发},
        {ItemName.三味酒,Tag.如醉如狂},
        {ItemName.皇之剑,Tag.皇家血统},
        {ItemName.天霸方天戟,Tag.霸王},
        {ItemName.混元功,Tag.气功达人},
        {ItemName.高汤白菜,Tag.把素持斋},
        {ItemName.龙井竹荪,Tag.把素持斋},
        {ItemName.八宝野鸭,Tag.盛食厉兵},
        {ItemName.佛手金卷,Tag.盛食厉兵},
        {ItemName.医圣的药箱,Tag.妙手丹心},
        {ItemName.鸽血红,Tag.侵略如火},
        {ItemName.木佐绿,Tag.仁人君子},
        {ItemName.撕风赤兔马,Tag.宝马良驹},
        {ItemName.亮云白龙驹,Tag.宝马良驹},
        {ItemName.堕云虎,Tag.虎猛},
        {ItemName.弯月狼,Tag.独狼},
        {ItemName.朱户衣,Tag.忠贞之志},
        {ItemName.云纹袍,Tag.景星庆云},
        {ItemName.长袖装,Tag.长袖善舞},
        {ItemName.金钱镖,Tag.金钱镖},
        {ItemName.袖炮,Tag.袖袍},
        {ItemName.血滴子,Tag.血滴子},
        {ItemName.木须柿子,Tag.素餐},
        {ItemName.酸菜粉条,Tag.素餐},
        {ItemName.红烧茄子,Tag.素餐},
        {ItemName.清炒菜心,Tag.素餐},
        {ItemName.蒜薹炒肉,Tag.荤菜},
        {ItemName.木须肉,Tag.荤菜},
        {ItemName.洗髓丹,Tag.根骨清奇},
        {ItemName.黄金弓,Tag.箭无虚发},
        {ItemName.白银枪,Tag.一点寒芒},
        {ItemName.大砍刀,Tag.买瓜人},
        {ItemName.铁片戟,Tag.武艺精湛},
        {ItemName.九阳真经,Tag.登堂入室},
        {ItemName.九阴真经,Tag.走火入魔},
        {ItemName.金绿宝石,Tag.鸿运当头},
        {ItemName.丝绸,Tag.丝绸},
        {ItemName.护心镜,Tag.护心},
        {ItemName.皮甲,Tag.皮甲},
        {ItemName.铁甲,Tag.铁甲},
        {ItemName.人参,Tag.辟邪安正},
        {ItemName.当归,Tag.辟邪安正},
        {ItemName.沉香,Tag.辟邪安正},
        {ItemName.水翁花,Tag.辟邪安正},
        {ItemName.虎骨,Tag.辟邪安正},
        {ItemName.守宫,Tag.辟邪安正},
        {ItemName.红宝石,Tag.珠光宝气},
        {ItemName.紫水晶,Tag.珠光宝气},
        {ItemName.蛋白石,Tag.珠光宝气},
        {ItemName.祖母绿,Tag.珠光宝气},
        {ItemName.吵闹的鹦鹉,Tag.花言巧语},

    };
    public static Dictionary<ItemType, List<ItemName>> ItemTypeDict = new Dictionary<ItemType, List<ItemName>>()
    {
        { 
            ItemType.兵器, new List<ItemName>()
            {
                ItemName.青龙方戟,
                ItemName.落日神弓,
                ItemName.百胜刀,
                ItemName.擎天枪,
                ItemName.龙源剑,
                ItemName.穿石烈风弓,
                ItemName.烈火斩云刀,
                ItemName.紫木雷电枪,
                ItemName.加十二的宝剑,
                ItemName.天霸方天戟,
                ItemName.皇之剑,
                ItemName.冰霜宝剑,
                ItemName.火炮,
                ItemName.欧冶子的大锤,
                ItemName.欧冶子的小锤,
                ItemName.黄金弓,
                ItemName.白银枪,
                ItemName.大砍刀,
                ItemName.弓,
                ItemName.刀,
                ItemName.枪,
                ItemName.剑,
                ItemName.戟,
                ItemName.有缺口的武器,
                ItemName.铁片戟
            }
        },
        {
            ItemType.丹药, new List<ItemName>()
            {
                ItemName.奉子丹,
                ItemName.长生不老药,
                ItemName.十全大补丸,
                ItemName.天机造化丹,
                ItemName.阴阳玄龙丹,
                ItemName.神气丹,
                ItemName.养气筑基散,
                ItemName.医圣的药箱,
                ItemName.沸腾散,
                ItemName.龙虎丹,
                ItemName.洗髓丹,
                ItemName.金疮药,
                ItemName.止血膏

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
                ItemName.混元功,
                ItemName.九阳真经,
                ItemName.九阴真经,
                ItemName.毒经,
                ItemName.唯物论,
                ItemName.棋诀,
                ItemName.货殖列传,
                ItemName.伤寒杂病论,
                ItemName.官宸书,
                ItemName.洗冤录,
                ItemName.孝经,
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
                ItemName.大汗之鹰,
                ItemName.犬,
                ItemName.豹子,
                ItemName.象虎,
                ItemName.堕云虎,
                ItemName.弯月狼,
                ItemName.老虎,
                ItemName.狼,

            }
        },
        {
            ItemType.服装, new List<ItemName>()
            {
                ItemName.羽衣,
                ItemName.黄金甲,
                ItemName.朱户衣,
                ItemName.云纹袍,
                ItemName.长袖装,
                ItemName.布衣,
                ItemName.护心镜,
                ItemName.皮甲,
                ItemName.铁甲,
                ItemName.蓑衣,
                ItemName.锦绣华服,
                ItemName.烂衣服
            }
        },
        {
            ItemType.机关, new List<ItemName>()
            {
                ItemName.暴雨梨花针,
                ItemName.浪击连弩,
                ItemName.金钱镖,
                ItemName.袖炮,
                ItemName.血滴子,
                ItemName.峨眉刺,
                ItemName.袖箭,
                ItemName.小刀,
                ItemName.背剑,
                ItemName.飞蝗石,

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
                ItemName.剪刀,
                ItemName.锤子,
                ItemName.刻刀,
                ItemName.绣花针,
                ItemName.文化沙漠,
                ItemName.舒服的椅子
            }
        },
        {
            ItemType.药材, new List<ItemName>()
            {
                ItemName.麝香,
                ItemName.灵芝,
                ItemName.人参,
                ItemName.当归,
                ItemName.沉香,
                ItemName.水翁花,
                ItemName.虎骨,
                ItemName.守宫,
                ItemName.何首乌,
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
                ItemName.核桃,
                ItemName.过山龙,
                ItemName.星辰花
            }
        },
        {
            ItemType.材料, new List<ItemName>()
            {
                ItemName.丝绸,
                ItemName.五香粉,
                ItemName.良姜,
                ItemName.谷芽,
                ItemName.陈皮,
                ItemName.羊乳,
                ItemName.红花,
                ItemName.树叶,
                ItemName.糖,
                ItemName.铁矿,
                ItemName.铜矿,
                ItemName.银矿,
                ItemName.布匹,
                ItemName.木头,
                ItemName.皮革,
                ItemName.铆钉,
                ItemName.硬木,
                ItemName.唇纸,
                ItemName.胭脂,
                ItemName.油,
                ItemName.绳子,
                ItemName.酱油,
                ItemName.醋,
                ItemName.盐

            }
        },
        {
            ItemType.坐骑, new List<ItemName>()
            {
                ItemName.龙马,
                ItemName.撕风赤兔马,
                ItemName.亮云白龙驹,
                ItemName.活泼的快马,
                ItemName.大宛马,
                ItemName.蒙古马,
                ItemName.凉州马,
                ItemName.长脚马,
                ItemName.短尾马,
                ItemName.肥马,

            }
        },
        {
            ItemType.饰品, new List<ItemName>()
            {
                ItemName.和氏璧,
                ItemName.钻石,
                ItemName.鸽血红,
                ItemName.木佐绿,
                ItemName.金绿宝石,
                ItemName.红宝石,
                ItemName.紫水晶,
                ItemName.蛋白石,
                ItemName.祖母绿,
                ItemName.朱砂脂,
                ItemName.零落的宝石,
                ItemName.缺口的宝石,
                ItemName.有破损的黄金
            }
        },
        {
            ItemType.酒品, new List<ItemName>()
            {
                ItemName.仙人醉,
                ItemName.美梦酒,
                ItemName.三味酒,
                ItemName.竹叶青,
                ItemName.杜康酒,
                ItemName.女儿红,
                ItemName.青酒,
                ItemName.黄酒,
                ItemName.羊酒,
                ItemName.芦酒,
                ItemName.杏仁酒,
                ItemName.银条酒,
                ItemName.水酒,
                ItemName.毒酒,

            }
        },
        {
            ItemType.菜品, new List<ItemName>()
            {
                ItemName.高汤白菜,
                ItemName.龙井竹荪,
                ItemName.八宝野鸭,
                ItemName.佛手金卷,
                ItemName.木须柿子,
                ItemName.酸菜粉条,
                ItemName.红烧茄子,
                ItemName.清炒菜心,
                ItemName.蒜薹炒肉,
                ItemName.木须肉,
                ItemName.清炒豆芽,
                ItemName.拍黄瓜,
                ItemName.蛋炒饭,
                ItemName.清蒸白萝卜

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
                ItemName.弓

            }
        },
        {
            BuildingType.武器铺, new List<ItemName>()
            {
                ItemName.刀,
                ItemName.枪,
                ItemName.剑,
                ItemName.戟,
                ItemName.弓,
                ItemName.白银枪,
                ItemName.黄金弓,
                ItemName.大砍刀,
                ItemName.穿石烈风弓,
                ItemName.烈火斩云刀,
                ItemName.紫木雷电枪
            }
        },
        {
            BuildingType.万兵阁, new List<ItemName>()
            {
                ItemName.刀,
                ItemName.枪,
                ItemName.剑,
                ItemName.戟,
                ItemName.弓,
                ItemName.白银枪,
                ItemName.黄金弓,
                ItemName.大砍刀,
                ItemName.穿石烈风弓,
                ItemName.烈火斩云刀,
                ItemName.紫木雷电枪,
                ItemName.落日神弓
            }
        },
        {
            BuildingType.机关阁, new List<ItemName>()
            {

                ItemName.血滴子,
                ItemName.袖炮,
                ItemName.金钱镖

            }
            
        },
        {
            BuildingType.武侯楼, new List<ItemName>()
            {
                ItemName.血滴子,
                ItemName.袖炮,
                ItemName.金钱镖,
                ItemName.暴雨梨花针

            }

        },
        {
            BuildingType.药铺, new List<ItemName>()
            {
                ItemName.奉子丹,
                ItemName.金疮药,
                ItemName.止血膏
            }
        },
        {
            BuildingType.纺织铺, new List<ItemName>()
            {

                ItemName.羽衣,
                ItemName.长袖装,

            }
        },
        {
            BuildingType.梭织坊, new List<ItemName>()
            {

                ItemName.羽衣,
                ItemName.长袖装,
                ItemName.云纹袍,
                ItemName.朱户衣

            }
        },
        {
            BuildingType.长安织造, new List<ItemName>()
            {

                ItemName.羽衣,
                ItemName.长袖装,
                ItemName.黄金甲,
                ItemName.云纹袍,
                ItemName.朱户衣
            }
        },
        {
            BuildingType.服装店, new List<ItemName>()
            {

                ItemName.皮甲,
                ItemName.铁甲,
                ItemName.羽衣,
                ItemName.长袖装,
                ItemName.锦绣华服
            }
        },
        {
            BuildingType.玉服华裳, new List<ItemName>()
            {
                ItemName.皮甲,
                ItemName.铁甲,
                ItemName.羽衣,
                ItemName.长袖装,
                ItemName.锦绣华服
            }
        },
        {
            BuildingType.珠宝店, new List<ItemName>()
            {
            }
        },
        {
            BuildingType.商行, new List<ItemName>()
            {
            }
        },
        {
            BuildingType.西域珍品, new List<ItemName>()
            {
            }
        },
        {
            BuildingType.胭脂铺, new List<ItemName>()
            {
            }
        },
        {
            BuildingType.万香阁, new List<ItemName>()
            {
            }
        },
        {
            BuildingType.马厩, new List<ItemName>()
            {
            }
        },
        {
            BuildingType.御马场, new List<ItemName>()
            {
            }
        },
        {
            BuildingType.天马阁, new List<ItemName>()
            {
            }
        },
        {
            BuildingType.奇兽堂, new List<ItemName>()
            {
            }
        },
        {
            BuildingType.百兽园, new List<ItemName>()
            {
            }
        },
        {
            BuildingType.酒馆, new List<ItemName>()
            {
            }
        },
        {
            BuildingType.酒店, new List<ItemName>()
            {
            }
        },
        {
            BuildingType.酒楼, new List<ItemName>()
            {
            }
        },
        {
            BuildingType.馆驿, new List<ItemName>()
            {
            }
        },
        {
            BuildingType.客栈, new List<ItemName>()
            {
            }
        },
        {
            BuildingType.丹房, new List<ItemName>()
            {
                ItemName.奉子丹,
                ItemName.金疮药,
                ItemName.沸腾散,
                ItemName.龙虎丹,
                ItemName.洗髓丹,
                ItemName.止血膏

            }
        },
        {
            BuildingType.仙鼎台, new List<ItemName>()
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
            BuildingType.医院, new List<ItemName>()
            {
            }
        },
        {
            BuildingType.研究院, new List<ItemName>()
            {
            }
        },
        {
            BuildingType.杂货铺, new List<ItemName>()
            {
            }
        },
        {
            BuildingType.百货店, new List<ItemName>()
            {
            }
        },
        {
            BuildingType.万仙楼, new List<ItemName>()
            {
            }
        },
        {
            BuildingType.当铺, new List<ItemName>()
            {
            }
        },
        {
            BuildingType.拍卖行, new List<ItemName>()
            {
            }
        },
        {
            BuildingType.戏馆, new List<ItemName>()
            {
            }
        },
        {
            BuildingType.青楼, new List<ItemName>()
            {
            }
        },
        {
            BuildingType.红人馆, new List<ItemName>()
            {
            }
        },
        {
            BuildingType.戏院, new List<ItemName>()
            {
            }
        },
        {
            BuildingType.鼓瑟楼, new List<ItemName>()
            {
            }
        }
    };
    public static Dictionary<BuildingType, List<ItemName>> BuildingVendorDict = new Dictionary<BuildingType, List<ItemName>>()
    {
        {
            BuildingType.铁匠铺, new List<ItemName>()
            {
            }
        },
        {
            BuildingType.武器铺, new List<ItemName>()
            {
                ItemName.刀,
                ItemName.枪,
                ItemName.剑,
                ItemName.戟,
                ItemName.弓

            }
        },
        {
            BuildingType.万兵阁, new List<ItemName>()
            {
                ItemName.刀,
                ItemName.枪,
                ItemName.剑,
                ItemName.戟,
                ItemName.弓

            }
        },
        {
            BuildingType.机关阁, new List<ItemName>()
            {
                ItemName.飞蝗石,
                ItemName.树叶,
                ItemName.背剑,
                ItemName.小刀,
                ItemName.袖箭,
                ItemName.峨眉刺,

            }

        },
        {
            BuildingType.武侯楼, new List<ItemName>()
            {
                ItemName.飞蝗石,
                ItemName.树叶,
                ItemName.背剑,
                ItemName.小刀,
                ItemName.袖箭,
                ItemName.峨眉刺


            }

        },
        {
            BuildingType.药铺, new List<ItemName>()
            {
                ItemName.过山龙,
                ItemName.当归,
                ItemName.人参,
                ItemName.轻粉,
                ItemName.三七,
                ItemName.黄精,
                ItemName.血风藤,
                ItemName.罗汉果,
                ItemName.黄芪,
                ItemName.八角莲,
                ItemName.乌桕子,
                ItemName.何首乌,
                ItemName.麝香,
                ItemName.红花,
                ItemName.羊乳,
                ItemName.陈皮,
                ItemName.谷芽,
                ItemName.良姜,
                ItemName.沉香

            }
        },
        {
            BuildingType.纺织铺, new List<ItemName>()
            {
                ItemName.蓑衣,
                ItemName.布衣,
                ItemName.丝绸

            }
        },
        {
            BuildingType.梭织坊, new List<ItemName>()
            {
                ItemName.蓑衣,
                ItemName.布衣,
                ItemName.丝绸


            }
        },
        {
            BuildingType.长安织造, new List<ItemName>()
            {
                ItemName.蓑衣,
                ItemName.布衣,
                ItemName.丝绸

            }
        },
        {
            BuildingType.服装店, new List<ItemName>()
            {
                ItemName.皮甲,
                ItemName.铁甲,

            }
        },
        {
            BuildingType.玉服华裳, new List<ItemName>()
            {
                ItemName.皮甲,
                ItemName.铁甲

            }
        },
        {
            BuildingType.珠宝店, new List<ItemName>()
            {
                ItemName.有破损的黄金,
                ItemName.缺口的宝石,
                ItemName.零落的宝石,
                ItemName.祖母绿,
                ItemName.蛋白石,
                ItemName.紫水晶,
                ItemName.红宝石,
                ItemName.金绿宝石,
                ItemName.木佐绿,
                ItemName.鸽血红
            }
        },
        {
            BuildingType.商行, new List<ItemName>()
            {
                ItemName.有破损的黄金,
                ItemName.缺口的宝石,
                ItemName.零落的宝石,
                ItemName.祖母绿,
                ItemName.蛋白石,
                ItemName.紫水晶,
                ItemName.红宝石
                
            }
        },
        {
            BuildingType.西域珍品, new List<ItemName>()
            {
                ItemName.有破损的黄金,
                ItemName.缺口的宝石,
                ItemName.零落的宝石,
                ItemName.祖母绿,
                ItemName.蛋白石,
                ItemName.紫水晶,
                ItemName.红宝石,
                ItemName.金绿宝石,
                ItemName.木佐绿,
                ItemName.鸽血红,
                ItemName.钻石
            }
        },
        {
            BuildingType.胭脂铺, new List<ItemName>()
            {
                ItemName.唇纸,
                ItemName.胭脂
            }
        },
        {
            BuildingType.万香阁, new List<ItemName>()
            {
                ItemName.唇纸,
                ItemName.胭脂
            }
        },
        {
            BuildingType.马厩, new List<ItemName>()
            {
                ItemName.肥马,
                ItemName.短尾马,
                ItemName.长脚马
            }
        },
        {
            BuildingType.御马场, new List<ItemName>()
            {
                ItemName.肥马,
                ItemName.短尾马,
                ItemName.长脚马,
                ItemName.凉州马,
                ItemName.蒙古马,
                ItemName.大宛马,
                ItemName.活泼的快马,
                ItemName.亮云白龙驹,
                ItemName.撕风赤兔马,

            }
        },
        {
            BuildingType.天马阁, new List<ItemName>()
            {
                ItemName.肥马,
                ItemName.短尾马,
                ItemName.长脚马,
                ItemName.凉州马,
                ItemName.蒙古马,
                ItemName.大宛马,
                ItemName.活泼的快马,
                ItemName.亮云白龙驹,
                ItemName.撕风赤兔马,
                ItemName.龙马
            }
        },
        {
            BuildingType.奇兽堂, new List<ItemName>()
            {
                ItemName.雕,
                ItemName.吵闹的鹦鹉,
                ItemName.老虎,
                ItemName.狼,
                ItemName.堕云虎,
                ItemName.弯月狼

            }
        },
        {
            BuildingType.百兽园, new List<ItemName>()
            {
                ItemName.雕,
                ItemName.吵闹的鹦鹉,
                ItemName.老虎,
                ItemName.狼,
                ItemName.堕云虎,
                ItemName.弯月狼,
                ItemName.大汗之鹰,
                ItemName.象虎
            }
        },
        {
            BuildingType.酒馆, new List<ItemName>()
            {
                ItemName.清炒豆芽,
                ItemName.拍黄瓜,
                ItemName.蛋炒饭,
                ItemName.清蒸白萝卜,
                ItemName.水酒,
                ItemName.银条酒,
                ItemName.杏仁酒,
                ItemName.芦酒,
                ItemName.羊酒,
                ItemName.黄酒,
                ItemName.青酒,
                ItemName.五香粉,
                ItemName.女儿红,
                ItemName.杜康酒,
                ItemName.竹叶青,
                ItemName.木须肉,
                ItemName.蒜薹炒肉,
                ItemName.清炒菜心,
                ItemName.红烧茄子,
                ItemName.酸菜粉条,
                ItemName.木须柿子
            }
        },
        {
            BuildingType.酒店, new List<ItemName>()
            {
                ItemName.清炒豆芽,
                ItemName.拍黄瓜,
                ItemName.蛋炒饭,
                ItemName.清蒸白萝卜,
                ItemName.水酒,
                ItemName.银条酒,
                ItemName.杏仁酒,
                ItemName.芦酒,
                ItemName.羊酒,
                ItemName.黄酒,
                ItemName.青酒,
                ItemName.五香粉,
                ItemName.女儿红,
                ItemName.杜康酒,
                ItemName.竹叶青,
                ItemName.木须肉,
                ItemName.蒜薹炒肉,
                ItemName.清炒菜心,
                ItemName.红烧茄子,
                ItemName.酸菜粉条,
                ItemName.木须柿子,
                ItemName.八宝野鸭,
                ItemName.龙井竹荪,
                ItemName.高汤白菜,
                ItemName.美梦酒,
                ItemName.三味酒



            }
        },
        {
            BuildingType.酒楼, new List<ItemName>()
            {
                ItemName.清炒豆芽,
                ItemName.拍黄瓜,
                ItemName.蛋炒饭,
                ItemName.清蒸白萝卜,
                ItemName.水酒,
                ItemName.银条酒,
                ItemName.杏仁酒,
                ItemName.芦酒,
                ItemName.羊酒,
                ItemName.黄酒,
                ItemName.青酒,
                ItemName.五香粉,
                ItemName.女儿红,
                ItemName.杜康酒,
                ItemName.竹叶青,
                ItemName.木须肉,
                ItemName.蒜薹炒肉,
                ItemName.清炒菜心,
                ItemName.红烧茄子,
                ItemName.酸菜粉条,
                ItemName.木须柿子,
                ItemName.八宝野鸭,
                ItemName.龙井竹荪,
                ItemName.高汤白菜,
                ItemName.美梦酒,
                ItemName.三味酒,
                ItemName.仙人醉
            }
        },
        {
            BuildingType.馆驿, new List<ItemName>()
            {
                ItemName.清炒豆芽,
                ItemName.拍黄瓜,
                ItemName.蛋炒饭,
                ItemName.清蒸白萝卜,
                ItemName.水酒,
                ItemName.银条酒,
                ItemName.杏仁酒,
                ItemName.芦酒,
                ItemName.羊酒,
                ItemName.黄酒,
                ItemName.青酒,
                ItemName.五香粉,
                ItemName.女儿红,
                ItemName.杜康酒,
                ItemName.竹叶青,
                ItemName.木须肉,
                ItemName.蒜薹炒肉,
                ItemName.清炒菜心,
                ItemName.红烧茄子,
                ItemName.酸菜粉条,
                ItemName.木须柿子,
                ItemName.八宝野鸭,
                ItemName.龙井竹荪,
                ItemName.高汤白菜,
            }
        },
        {
            BuildingType.客栈, new List<ItemName>()
            {
                ItemName.清炒豆芽,
                ItemName.拍黄瓜,
                ItemName.蛋炒饭,
                ItemName.清蒸白萝卜,
                ItemName.水酒,
                ItemName.银条酒,
                ItemName.杏仁酒,
                ItemName.芦酒,
                ItemName.羊酒,
                ItemName.黄酒,
                ItemName.青酒,
                ItemName.五香粉,
                ItemName.女儿红,
                ItemName.杜康酒,
                ItemName.竹叶青,
                ItemName.木须肉,
                ItemName.蒜薹炒肉,
                ItemName.清炒菜心,
                ItemName.红烧茄子,
                ItemName.酸菜粉条,
                ItemName.木须柿子,
                ItemName.八宝野鸭,
                ItemName.龙井竹荪,
                ItemName.高汤白菜,
            }
        },
        {
            BuildingType.丹房, new List<ItemName>()
            {
                ItemName.过山龙,
                ItemName.当归,
                ItemName.人参,
                ItemName.轻粉,
                ItemName.三七,
                ItemName.黄精,
                ItemName.血风藤,
                ItemName.罗汉果,
                ItemName.黄芪,
                ItemName.八角莲,
                ItemName.乌桕子,
                ItemName.何首乌,
                ItemName.麝香,
                ItemName.红花,
                ItemName.羊乳,
                ItemName.陈皮,
                ItemName.谷芽,
                ItemName.良姜,
                ItemName.沉香

            }
        },
        {
            BuildingType.仙鼎台, new List<ItemName>()
            {
                ItemName.过山龙,
                ItemName.当归,
                ItemName.人参,
                ItemName.轻粉,
                ItemName.三七,
                ItemName.黄精,
                ItemName.血风藤,
                ItemName.罗汉果,
                ItemName.黄芪,
                ItemName.八角莲,
                ItemName.乌桕子,
                ItemName.何首乌,
                ItemName.麝香,
                ItemName.红花,
                ItemName.羊乳,
                ItemName.陈皮,
                ItemName.谷芽,
                ItemName.良姜,
                ItemName.沉香
            }
        },
        {
            BuildingType.医院, new List<ItemName>()
            {
            }
        },
        {
            BuildingType.研究院, new List<ItemName>()
            {
            }
        },
        {
            BuildingType.杂货铺, new List<ItemName>()
            {
                ItemName.糖,
                ItemName.铁矿,        
                ItemName.布匹,
                ItemName.木头,
                ItemName.皮革,
                ItemName.铆钉,
                ItemName.硬木,
                ItemName.油,
                ItemName.绳子,
                ItemName.酱油,
                ItemName.醋,
                ItemName.盐,
                ItemName.咖啡,
                ItemName.毛笔,
                ItemName.拂尘,
                ItemName.佛珠,
                ItemName.杂技,
                ItemName.剪刀,
                ItemName.锤子,
                ItemName.刻刀,
                ItemName.绣花针,
                ItemName.舒服的椅子
            }
        },
        {
            BuildingType.百货店, new List<ItemName>()
            {
                ItemName.咖啡,
                ItemName.毛笔,
                ItemName.拂尘,
                ItemName.佛珠,
                ItemName.杂技,
                ItemName.剪刀,
                ItemName.锤子,
                ItemName.刻刀,
                ItemName.绣花针,
                ItemName.舒服的椅子,
            }
        },
        {
            BuildingType.万仙楼, new List<ItemName>()
            {
                ItemName.阴阳八卦盘,
                ItemName.浑天仪,
                ItemName.咖啡,
                ItemName.毛笔,
                ItemName.拂尘,
                ItemName.佛珠,
                ItemName.毒奶瓶,
                ItemName.杂技,
                ItemName.剪刀,
                ItemName.锤子,
                ItemName.刻刀,
                ItemName.绣花针,
                ItemName.文化沙漠,
                ItemName.舒服的椅子,
            }
        },
        {
            BuildingType.当铺, new List<ItemName>()
            {
                ItemName.阴阳八卦盘,
                ItemName.浑天仪,
                ItemName.咖啡,
                ItemName.毛笔,
                ItemName.拂尘,
                ItemName.佛珠,
                ItemName.毒奶瓶,
                ItemName.杂技,
                ItemName.剪刀,
                ItemName.锤子,
                ItemName.刻刀,
                ItemName.绣花针,
                ItemName.文化沙漠,
                ItemName.舒服的椅子
            }
        },
        {
            BuildingType.拍卖行, new List<ItemName>()
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
                ItemName.剪刀,
                ItemName.锤子,
                ItemName.刻刀,
                ItemName.绣花针,
                ItemName.文化沙漠,
                ItemName.舒服的椅子

            }
        },
        {
            BuildingType.戏馆, new List<ItemName>()
            {
            }
        },
        {
            BuildingType.青楼, new List<ItemName>()
            {
            }
        },
        {
            BuildingType.红人馆, new List<ItemName>()
            {
            }
        },
        {
            BuildingType.戏院, new List<ItemName>()
            {
                ItemName.山海经,
                ItemName.机关残卷,
                ItemName.蛤蟆功秘籍,
                ItemName.东洋词典,
                ItemName.西洋词典,
                ItemName.杂技,
                ItemName.混元功,
                ItemName.九阳真经,
                ItemName.九阴真经,
                ItemName.毒经,
                ItemName.唯物论,
                ItemName.棋诀,
                ItemName.货殖列传,
                ItemName.伤寒杂病论,
                ItemName.官宸书,
                ItemName.洗冤录,
                ItemName.孝经,
                ItemName.马经,
                ItemName.药材大全,
                ItemName.演员的自我修养,
                ItemName.汤头歌诀,
            }
        },
        {
            BuildingType.鼓瑟楼, new List<ItemName>()
            {
                ItemName.山海经,
                ItemName.机关残卷,
                ItemName.蛤蟆功秘籍,
                ItemName.东洋词典,
                ItemName.西洋词典,
                ItemName.杂技,
                ItemName.混元功,
                ItemName.九阳真经,
                ItemName.九阴真经,
                ItemName.毒经,
                ItemName.唯物论,
                ItemName.棋诀,
                ItemName.货殖列传,
                ItemName.伤寒杂病论,
                ItemName.官宸书,
                ItemName.洗冤录,
                ItemName.孝经,
                ItemName.马经,
                ItemName.药材大全,
                ItemName.演员的自我修养,
                ItemName.汤头歌诀,
            }
        }
    };

    public static Dictionary<ItemName, List<ItemName>> MergeItemDict = new Dictionary<ItemName,List<ItemName>>
    {
        {ItemName.刀,new List<ItemName>(){ItemName.铁矿,ItemName.皮革}},
        {ItemName.枪,new List<ItemName>(){ItemName.铁矿,ItemName.木头}},
        {ItemName.剑,new List<ItemName>(){ItemName.铜矿,ItemName.铁矿}},
        {ItemName.戟,new List<ItemName>(){ItemName.铁矿,ItemName.铁矿}},
        {ItemName.弓,new List<ItemName>(){ItemName.木头,ItemName.绳子}},
        {ItemName.穿石烈风弓,new List<ItemName>(){ItemName.黄金弓, ItemName.祖母绿}},
        {ItemName.烈火斩云刀,new List<ItemName>(){ItemName.大砍刀, ItemName.鸽血红}},
        {ItemName.紫木雷电枪,new List<ItemName>(){ItemName.白银枪, ItemName.紫水晶}},
        {ItemName.皮甲,new List<ItemName>(){ItemName.布衣,ItemName.皮革}},
        {ItemName.铁甲,new List<ItemName>(){ItemName.布衣,ItemName.铁矿}},
        {ItemName.黄金甲,new List<ItemName>(){ItemName.铁甲,ItemName.有破损的黄金}},
        {ItemName.云纹袍,new List<ItemName>(){ItemName.长袖装,ItemName.绣花针}},
        {ItemName.朱户衣,new List<ItemName>(){ItemName.云纹袍,ItemName.红宝石}},
        {ItemName.锦绣华服,new List<ItemName>(){ItemName.羽衣,ItemName.祖母绿,ItemName.红宝石}},
        {ItemName.袖炮,new List<ItemName>(){ItemName.袖箭,ItemName.火炮}},
        {ItemName.金钱镖,new List<ItemName>(){ItemName.袖箭,ItemName.有破损的黄金}},
        {ItemName.金疮药,new List<ItemName>(){ItemName.黄精,ItemName.八角莲}},
        {ItemName.沸腾散,new List<ItemName>(){ItemName.罗汉果,ItemName.乌桕子}},
        {ItemName.长生不老药,new List<ItemName>(){ItemName.三七,ItemName.灵芝,ItemName.何首乌}},
        {ItemName.十全大补丸,new List<ItemName>(){ItemName.当归,ItemName.人参,ItemName.黄芪}},
        {ItemName.洗髓丹,new List<ItemName>(){ItemName.轻粉,ItemName.核桃}},
        {ItemName.龙虎丹,new List<ItemName>(){ItemName.当归,ItemName.核桃}},
        {ItemName.阴阳玄龙丹,new List<ItemName>(){ItemName.白花蛇舌草,ItemName.过山龙}},
        {ItemName.落日神弓,new List<ItemName>(){ItemName.穿石烈风弓, ItemName.紫木雷电枪}},
        {ItemName.白银枪,new List<ItemName>(){ItemName.银矿, ItemName.枪}},
        {ItemName.黄金弓,new List<ItemName>(){ItemName.有破损的黄金, ItemName.弓}},
        {ItemName.大砍刀,new List<ItemName>(){ItemName.铁矿, ItemName.木头, ItemName.刀}},
        {ItemName.血滴子,new List<ItemName>(){ItemName.绳子, ItemName.铆钉,ItemName.峨眉刺}},
        {ItemName.暴雨梨花针,new List<ItemName>(){ItemName.峨眉刺, ItemName.浪击连弩}},
        {ItemName.奉子丹,new List<ItemName>(){ItemName.当归, ItemName.人参}},
        {ItemName.止血膏,new List<ItemName>(){ItemName.三七, ItemName.血风藤}},
        {ItemName.羽衣,new List<ItemName>(){ItemName.吵闹的鹦鹉, ItemName.丝绸}},
        {ItemName.长袖装,new List<ItemName>(){ItemName.布衣, ItemName.丝绸}}
    };
    public Sprite NullSprite;




}
