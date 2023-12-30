using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameItemFile")]
public class SOItem : ScriptableObject
{

    public static Dictionary<ItemName, Tag> ItemMap = new Dictionary<ItemName, Tag>()
    {
        {ItemName.长生不老药,Tag.长生不老},
        {ItemName.十全大补丸,Tag.生死肉骨},
        {ItemName.和氏璧,Tag.碧血丹心},
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
        {ItemName.山海经,Tag.书通二酉},
        {ItemName.机关残卷,Tag.偃师},
        {ItemName.阴阳八卦盘,Tag.奇门遁甲},
        {ItemName.鬼谷子,Tag.纵横家},
        {ItemName.欧冶子的大锤,Tag.大锤},
        {ItemName.黄帝内经,Tag.黄帝内经},
        {ItemName.本草纲目,Tag.本草纲目},
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
        {ItemName.文化沙漠,Tag.文化沙漠},
        {ItemName.八宝野鸭,Tag.盛食厉兵},
        {ItemName.佛手金卷,Tag.盛食厉兵},
        {ItemName.神气丹,Tag.武功小成},
        {ItemName.养气筑基散,Tag.武功小成},
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
        {ItemName.袖炮,Tag.袖炮},
        {ItemName.血滴子,Tag.血滴子},
        {ItemName.灵芝,Tag.妙手丹心},
        {ItemName.锦绣华服,Tag.理财大师},
        {ItemName.玉手镯,Tag.珠圆玉润},
        {ItemName.木须柿子,Tag.素餐},
        {ItemName.酸菜粉条,Tag.素餐},
        {ItemName.红烧茄子,Tag.素餐},
        {ItemName.清炒菜心,Tag.素餐},
        {ItemName.蒜薹炒肉,Tag.荤菜},
        {ItemName.木须肉,Tag.荤菜},
        {ItemName.沸腾散,Tag.疯子},
        {ItemName.龙虎丹,Tag.武艺精湛},
        {ItemName.洗髓丹,Tag.根骨清奇},
        {ItemName.蛤蟆功秘籍,Tag.蛤蟆功},
        {ItemName.浑天仪,Tag.通晓天文},
        {ItemName.冰霜宝剑,Tag.冰霜宝剑},
        {ItemName.黄金弓,Tag.箭无虚发},
        {ItemName.白银枪,Tag.一点寒芒},
        {ItemName.大砍刀,Tag.买瓜人},
        {ItemName.铁片戟,Tag.武艺精湛},
        {ItemName.九阳真经,Tag.登堂入室},
        {ItemName.九阴真经,Tag.走火入魔},
        {ItemName.金绿宝石,Tag.鸿运当头},
        {ItemName.火炮,Tag.火炮},
        {ItemName.东洋词典,Tag.东洋语},
        {ItemName.西洋词典,Tag.西洋语},
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
        {ItemName.羽衣,Tag.能歌善舞},
        {ItemName.红宝石,Tag.珠光宝气},
        {ItemName.紫水晶,Tag.珠光宝气},
        {ItemName.蛋白石,Tag.珠光宝气},
        {ItemName.祖母绿,Tag.珠光宝气},
        {ItemName.墨子非攻,Tag.非攻},
        {ItemName.墨子兼爱,Tag.兼爱},
        {ItemName.御马官印,Tag.御马司},
        {ItemName.毒经,Tag.毒师},
        {ItemName.唯物论,Tag.离经叛道},
        {ItemName.毒奶瓶,Tag.厄运缠身},
        {ItemName.棋诀,Tag.棋道},
        {ItemName.竹叶青,Tag.好酒之人},
        {ItemName.杜康酒,Tag.好酒之人},
        {ItemName.女儿红,Tag.好酒之人},
        {ItemName.货殖列传,Tag.经济学},
        {ItemName.欧冶子的小锤,Tag.小锤},
        {ItemName.伤寒杂病论,Tag.郎中},
        {ItemName.五香粉,Tag.五味杂陈},
        {ItemName.活泼的快马,Tag.飞毛腿},
        {ItemName.吵闹的鹦鹉,Tag.花言巧语},
        {ItemName.老虎,Tag.驯兽术},
        {ItemName.狼,Tag.驯兽术},
        {ItemName.锤子,Tag.匠人},
        {ItemName.绣花针,Tag.匠人},
        {ItemName.朱砂脂,Tag.珠光宝气},
        {ItemName.刻刀,Tag.匠人},
        {ItemName.大宛马,Tag.飞毛腿},
        {ItemName.蒙古马,Tag.飞毛腿},
        {ItemName.凉州马,Tag.飞毛腿},
        {ItemName.峨眉刺,Tag.身形矫健},
        {ItemName.袖箭,Tag.箭无虚发},
        {ItemName.小刀,Tag.毒师},
        {ItemName.背剑,Tag.武艺精湛},
        {ItemName.文官状,Tag.文贞},

        {ItemName.武官状,Tag.武勇},
        {ItemName.蓑衣,Tag.平平无奇},
        {ItemName.布衣,Tag.平平无奇},
        {ItemName.青酒,Tag.醉酒},
        {ItemName.黄酒,Tag.醉酒},
        {ItemName.羊酒,Tag.醉酒},
        {ItemName.芦酒,Tag.醉酒},
        {ItemName.杏仁酒,Tag.醉酒},
        {ItemName.银条酒,Tag.醉酒},
        {ItemName.零落的宝石,Tag.敝帚自珍},
        {ItemName.缺口的宝石,Tag.敝帚自珍},
        {ItemName.有破损的黄金,Tag.敝帚自珍},
        {ItemName.良姜,Tag.无伤大雅},
        {ItemName.谷芽,Tag.无伤大雅},
        {ItemName.陈皮,Tag.无伤大雅},
        {ItemName.羊乳,Tag.无伤大雅},
        {ItemName.红花,Tag.无伤大雅},
        {ItemName.官宸书,Tag.绣花枕头},
        {ItemName.杂技,Tag.梧鼠五技},
        {ItemName.奉子丹,Tag.身怀六甲},
        {ItemName.麝香,Tag.不孕不育},
        {ItemName.洗冤录,Tag.讼师},
        {ItemName.咖啡,Tag.夜不能寐},
        {ItemName.剪刀,Tag.阉人},
        {ItemName.长脚马,Tag.飞毛腿},
        {ItemName.短尾马,Tag.飞毛腿},
        {ItemName.孝经,Tag.不孝子},
        {ItemName.雕,Tag.雕},
        {ItemName.毛笔,Tag.儒生},
        {ItemName.拂尘,Tag.道士},
        {ItemName.佛珠,Tag.僧人},
        {ItemName.马经,Tag.马倌},
        {ItemName.药材大全,Tag.丹童},
        {ItemName.弓,Tag.弓},
        {ItemName.刀,Tag.刀},
        {ItemName.枪,Tag.枪},
        {ItemName.剑,Tag.剑},
        {ItemName.戟,Tag.戟},
        {ItemName.演员的自我修养,Tag.演员},
        {ItemName.汤头歌诀,Tag.医术},
        {ItemName.飞蝗石,Tag.梧鼠五技},
        {ItemName.树叶,Tag.梧鼠五技},
        {ItemName.何首乌,Tag.毛发旺盛},
        {ItemName.金疮药,Tag.习武之人},
        {ItemName.糖,Tag.嗜甜如命},
        {ItemName.止血膏,Tag.习武之人},
        {ItemName.舒服的椅子 ,Tag.体态端正},
        {ItemName.清炒豆芽,Tag.饱腹},
        {ItemName.拍黄瓜,Tag.饱腹},
        {ItemName.蛋炒饭,Tag.饱腹},
        {ItemName.清蒸白萝卜,Tag.饱腹},
        {ItemName.铁矿,Tag.鸠工庀材},
        {ItemName.铜矿,Tag.鸠工庀材},
        {ItemName.银矿,Tag.鸠工庀材},
        {ItemName.布匹,Tag.鸠工庀材},
        {ItemName.木头,Tag.鸠工庀材},
        {ItemName.皮革,Tag.鸠工庀材},
        {ItemName.铆钉,Tag.鸠工庀材},
        {ItemName.硬木,Tag.鸠工庀材},
        {ItemName.唇纸,Tag.绣花枕头},
        {ItemName.胭脂,Tag.绣花枕头},
        {ItemName.油,Tag.杂七杂八},
        {ItemName.绳子,Tag.杂七杂八},
        {ItemName.酱油,Tag.杂七杂八},
        {ItemName.醋,Tag.杂七杂八},
        {ItemName.盐,Tag.杂七杂八},
        {ItemName.棍子,Tag.无用之人},
        {ItemName.乌桕子,Tag.药毒},
        {ItemName.铁苋,Tag.药毒},
        {ItemName.八角莲,Tag.药毒},
        {ItemName.黄芪,Tag.药毒},
        {ItemName.罗汉果,Tag.药毒},
        {ItemName.血风藤,Tag.药毒},
        {ItemName.黄精,Tag.药毒},
        {ItemName.白花蛇舌草,Tag.药毒},
        {ItemName.水酒,Tag.头疼},
        {ItemName.毒酒,Tag.身体孱弱},
        {ItemName.有缺口的武器,Tag.无能狂怒},
        {ItemName.烂衣服,Tag.衣不蔽体},
        {ItemName.肥马,Tag.肥胖症},
        {ItemName.三七,Tag.药毒},
        {ItemName.轻粉,Tag.药毒},
        {ItemName.核桃粉,Tag.杂七杂八},
        {ItemName.过山龙,Tag.药毒},
        {ItemName.星辰花,Tag.药毒},
        {ItemName.祈天玄衣,Tag.潜光隐耀},
        {ItemName.步辇袍衫,Tag.深仁厚泽},
        {ItemName.青织飞鱼袍,Tag.平步青云},
        {ItemName.酒葫芦,Tag.醉拳},
        {ItemName.木佛像,Tag.僧人},
        {ItemName.蚕丝,Tag.鸠工庀材},
        {ItemName.皮毛,Tag.鸠工庀材},
        {ItemName.麻布,Tag.鸠工庀材},
        {ItemName.弹劾文书,Tag.惹人嫌 },
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
                ItemName.铁片戟,
                ItemName.棍子
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
                ItemName.弹劾文书,
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
                ItemName.核桃粉,
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
                ItemName.盐,
                ItemName.蚕丝,
                ItemName.布匹,
                ItemName.麻布,

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
            BuildingType.五金店, new List<ItemName>()
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
                ItemName.棍子,
                ItemName.铁矿,
                ItemName.布匹,
                ItemName.铜矿,
                ItemName.银矿,
                ItemName.木头,
                ItemName.皮革,
                ItemName.绳子,
                ItemName.铆钉,
                ItemName.硬木
            }
        },
        {
            BuildingType.武器铺, new List<ItemName>()
            {
                ItemName.棍子,
                ItemName.棍子,
                ItemName.刀,
                ItemName.枪,
                ItemName.剑,
                ItemName.戟,
                ItemName.弓,
                ItemName.棍子,
                ItemName.刀,
                ItemName.枪,
                ItemName.剑,
                ItemName.戟,
                ItemName.弓,
                 ItemName.铁矿,
                ItemName.布匹,
                ItemName.铜矿,
                ItemName.银矿,
                ItemName.木头,
                ItemName.皮革,
                ItemName.绳子,
                ItemName.铆钉,
                ItemName.硬木
            }
        },
        {
            BuildingType.万兵阁, new List<ItemName>()
            {
                ItemName.棍子,
                ItemName.棍子,
                ItemName.刀,
                ItemName.枪,
                ItemName.剑,
                ItemName.戟,
                ItemName.弓,
                ItemName.棍子,
                ItemName.棍子,
                ItemName.刀,
                ItemName.枪,
                ItemName.剑,
                ItemName.戟,
                ItemName.弓,
                ItemName.刀,
                ItemName.枪,
                ItemName.剑,
                ItemName.戟,
                ItemName.弓,
                ItemName.铁矿,
                ItemName.布匹,
                ItemName.铜矿,
                ItemName.银矿,
                ItemName.木头,
                ItemName.皮革,
                ItemName.绳子,
                ItemName.铆钉,
                ItemName.硬木
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
                ItemName.核桃粉,
                ItemName.核桃粉,
                ItemName.过山龙,
                ItemName.当归,
                ItemName.当归,
                ItemName.人参,
                ItemName.轻粉,
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
                ItemName.蚕丝,
                ItemName.皮毛,
                ItemName.麻布,
                ItemName.蚕丝,
                ItemName.皮毛,
                ItemName.麻布,
                ItemName.蓑衣,
                ItemName.蓑衣,
                ItemName.布衣,
                ItemName.丝绸,

            }
        },
        {
            BuildingType.梭织坊, new List<ItemName>()
            {
                ItemName.蚕丝,
                ItemName.皮毛,
                ItemName.麻布,
                ItemName.蚕丝,
                ItemName.皮毛,
                ItemName.麻布,
                ItemName.蓑衣,
                ItemName.蓑衣,
                ItemName.布衣,
                ItemName.布衣,
                ItemName.丝绸


            }
        },
        {
            BuildingType.长安织造, new List<ItemName>()
            {
                ItemName.蚕丝,
                ItemName.皮毛,
                ItemName.麻布,
                ItemName.蓑衣,
                ItemName.布衣,
                ItemName.丝绸,
                ItemName.布衣,
                ItemName.丝绸,

            }
        },
        {
            BuildingType.服装店, new List<ItemName>()
            {
                ItemName.烂衣服,
                ItemName.烂衣服,
                ItemName.护心镜,
                ItemName.皮甲,
                ItemName.铁甲,
                ItemName.羽衣,
                ItemName.羽衣,
                ItemName.锦绣华服,

            }
        },
        {
            BuildingType.玉服华裳, new List<ItemName>()
            {
                ItemName.烂衣服,
                ItemName.护心镜,
                ItemName.皮甲,
                ItemName.铁甲,
                ItemName.羽衣,
                ItemName.羽衣,
                ItemName.锦绣华服,

            }
        },
        {
            BuildingType.商行, new List<ItemName>()
            {
                ItemName.有破损的黄金,
                ItemName.缺口的宝石,
                ItemName.零落的宝石,
                 ItemName.有破损的黄金,
                ItemName.缺口的宝石,
                ItemName.零落的宝石,
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
            BuildingType.珠宝店, new List<ItemName>()
            {
                ItemName.有破损的黄金,
                ItemName.缺口的宝石,
                ItemName.零落的宝石,
                ItemName.有破损的黄金,
                ItemName.缺口的宝石,
                ItemName.零落的宝石,
                ItemName.祖母绿,
                ItemName.金绿宝石,
                ItemName.蛋白石,
                ItemName.木佐绿
            }
        },
        {
            BuildingType.西域珍品, new List<ItemName>()
            {
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
                ItemName.核桃粉,
                ItemName.核桃粉,
                ItemName.过山龙,
                ItemName.当归,
                ItemName.人参,
                ItemName.轻粉,
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
                ItemName.人参,
                ItemName.轻粉,
                ItemName.三七,
                ItemName.黄精,
                ItemName.血风藤,
                ItemName.罗汉果,
                ItemName.罗汉果,
                ItemName.黄芪,
                ItemName.八角莲,
                ItemName.乌桕子,
                ItemName.何首乌,
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
    BuildingType.五金店, new List<ItemName>()
            {
                ItemName.糖,
                ItemName.铁矿,
                ItemName.铆钉,
                ItemName.硬木,
                ItemName.油,
                ItemName.酱油,
                ItemName.醋,
                ItemName.盐,
                ItemName.咖啡,
                ItemName.毛笔,

            }
        },
        {
    BuildingType.百货店, new List<ItemName>()
            {
                ItemName.糖,
                ItemName.油,
                ItemName.酱油,
                ItemName.醋,
                ItemName.盐,
                ItemName.咖啡,
                ItemName.毛笔,
                ItemName.毛笔,
                ItemName.毛笔,
                ItemName.咖啡,
                ItemName.毛笔,
                ItemName.拂尘,
                ItemName.拂尘,
                ItemName.拂尘,
                ItemName.佛珠,
                ItemName.佛珠,
                ItemName.佛珠,
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
                ItemName.糖,
                ItemName.油,
                ItemName.酱油,
                ItemName.醋,
                ItemName.盐,
                ItemName.咖啡,
                ItemName.毛笔,
                ItemName.毛笔,
                ItemName.毛笔,
                ItemName.阴阳八卦盘,
                ItemName.浑天仪,
                ItemName.咖啡,
                ItemName.毛笔,
                ItemName.拂尘,
                ItemName.拂尘,
                ItemName.拂尘,
                ItemName.拂尘,
                ItemName.佛珠,
                ItemName.佛珠,
                ItemName.佛珠,
                ItemName.佛珠,
                ItemName.毒奶瓶,
                ItemName.剪刀,
                ItemName.剪刀,
                ItemName.锤子,
                ItemName.锤子,
                ItemName.刻刀,
                ItemName.刻刀,
                ItemName.绣花针,
                ItemName.文化沙漠,
                ItemName.舒服的椅子,
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
                ItemName.糖,
                ItemName.油,
                ItemName.绳子,
                ItemName.酱油,
                ItemName.醋,
                ItemName.盐,
                ItemName.咖啡,
                ItemName.毛笔,
                ItemName.毛笔,
                ItemName.毛笔,
                ItemName.阴阳八卦盘,
                ItemName.阴阳八卦盘,
                ItemName.浑天仪,
                ItemName.浑天仪,
                ItemName.咖啡,
                ItemName.毛笔,
                ItemName.拂尘,
                ItemName.拂尘,
                ItemName.拂尘,
                ItemName.拂尘,
                ItemName.佛珠,
                ItemName.佛珠,
                ItemName.佛珠,
                ItemName.佛珠,
                ItemName.毒奶瓶,
                ItemName.剪刀,
                ItemName.锤子,
                ItemName.刻刀,
                ItemName.绣花针,
                ItemName.文化沙漠,
                ItemName.舒服的椅子,

            }
        },
        {
    BuildingType.戏馆, new List<ItemName>()
            {
                ItemName.杂技,
                ItemName.官宸书,
                ItemName.洗冤录,
                ItemName.演员的自我修养,
                ItemName.孝经,
                ItemName.药材大全
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

    public static Dictionary<ItemName, List<ItemName>> MergeItemDict = new Dictionary<ItemName, List<ItemName>>
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
        {ItemName.洗髓丹,new List<ItemName>(){ItemName.轻粉,ItemName.核桃粉}},
        {ItemName.龙虎丹,new List<ItemName>(){ItemName.当归,ItemName.核桃粉}},
        {ItemName.阴阳玄龙丹,new List<ItemName>(){ItemName.白花蛇舌草,ItemName.过山龙}},
        {ItemName.天机造化丹,new List<ItemName>(){ItemName.星辰花,ItemName.罗汉果,ItemName.八角莲,ItemName.鸽血红} },
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

    public static Dictionary<BuildingType, Dictionary<ItemType, List<int>>> ItempriceTag = new Dictionary<BuildingType, Dictionary<ItemType, List<int>>>
    {
        {BuildingType.商行,new Dictionary<ItemType, List<int>>(){{ItemType.饰品,new List<int>(){ 18, 43, 0, 0, 0, 0 } }}},
        {BuildingType.珠宝店,new Dictionary<ItemType, List<int>>(){{ItemType.饰品,new List<int>(){ 20, 49, 157, 716, 0, 0 } }}},
        {BuildingType.西域珍品,new Dictionary<ItemType, List<int>>(){{ItemType.饰品,new List<int>(){ 22, 56, 187, 898, 3886, 0 } }}},
        {BuildingType.胭脂铺,new Dictionary<ItemType, List<int>>(){{ItemType.材料,new List<int>(){ 22, 56, 187, 898, 0, 0 } }}},
        {BuildingType.万香阁,new Dictionary<ItemType, List<int>>(){{ItemType.材料,new List<int>(){ 24, 62, 214, 1070, 5145, 0 } }}},
        {BuildingType.马厩,new Dictionary<ItemType, List<int>>(){{ItemType.坐骑,new List<int>(){ 22, 56, 0, 0, 0, 0 } }}},
        {BuildingType.御马场,new Dictionary<ItemType, List<int>>(){{ItemType.坐骑, new List<int>(){ 24, 62, 214, 1070, 0, 0 } }}},
        {BuildingType.天马阁,new Dictionary<ItemType, List<int>>(){{ItemType.坐骑, new List<int>(){ 26, 69, 246, 1283, 6907, 0 } }}},
        {BuildingType.奇兽堂,new Dictionary<ItemType, List<int>>(){{ItemType.奇兽,new List<int>() { 24, 62, 214, 1070, 0, 0 } } }},
        {BuildingType.百兽园,new Dictionary<ItemType, List<int>>(){{ItemType.奇兽, new List<int>(){ 26, 69, 246, 1283, 6907, 0 } } }},
        {BuildingType.酒馆,new Dictionary<ItemType, List<int>>(){{ItemType.菜品,new List<int>(){ 15, 34, 0, 0, 0, 0 } },
                                                                {ItemType.酒品,new List<int>(){ 15, 34, 0, 0, 0, 0 } },
                                                                {ItemType.材料,new List<int>(){ 24, 62, 214, 1070, 5145, 0 } }} },
        {BuildingType.酒店,new Dictionary<ItemType, List<int>>(){{ItemType.菜品, new List<int>(){ 17, 40, 121, 510, 0, 0 } },
                                                                {ItemType.酒品,new List<int>(){ 17, 40, 121, 510, 0, 0 } },
                                                                {ItemType.材料,new List<int>(){ 22, 56, 187, 898, 0, 0 } }} },
        {BuildingType.酒楼,new Dictionary<ItemType, List<int>>(){{ItemType.菜品, new List<int>(){ 19, 46, 145, 656, 2320, 0 } },
                                                                {ItemType.酒品,new List<int>(){ 19, 46, 145, 656, 2320, 0 } },
                                                                {ItemType.材料,new List<int>(){ 24, 62, 214, 1070, 5145, 0 } }}},
        {BuildingType.馆驿,new Dictionary<ItemType, List<int>>(){{ItemType.菜品, new List<int>() { 17, 40, 121, 510, 0, 0 } },
                                                                {ItemType.酒品,new List<int>(){ 17, 40, 121, 510, 0, 0 } },
                                                                {ItemType.材料,new List<int>(){ 22, 56, 187, 898, 0, 0 } }}},
        {BuildingType.客栈,new Dictionary<ItemType, List<int>>(){{ItemType.菜品, new List<int>(){ 19, 46, 145, 656, 2320, 0 } },
                                                                {ItemType.酒品,new List<int>(){ 19, 46, 145, 656, 2320, 0 } },
                                                                {ItemType.材料,new List<int>(){ 24, 62, 214, 1070, 5145, 0 } }}},
        {BuildingType.药铺,new Dictionary<ItemType, List<int>>(){{ItemType.药材,new List<int>(){ 15, 34, 0, 0, 0, 0 }},
                                                                {ItemType.材料,new List<int>(){ 20, 49, 0, 0, 0, 0 }}} },
        {BuildingType.丹房,new Dictionary<ItemType, List<int>>(){{ItemType.药材, new List<int>(){ 17, 40, 121, 510, 0, 0 } },
                                                                {ItemType.材料,new List<int>() { 22, 56, 187, 898, 0, 0 } }} },
        {BuildingType.仙鼎台,new Dictionary<ItemType, List<int>>(){{ItemType.药材, new List<int>(){ 19, 46, 145, 656, 2320, 0 } },
                                                                {ItemType.材料,new List<int>() { 24, 62, 214, 1070, 5145, 0 } } } },
        {BuildingType.医院,new Dictionary<ItemType, List<int>>() { { ItemType.药材, new List<int>() { 17, 40, 121, 510, 0, 0 } } ,
                                                                 {ItemType.材料,new List<int>() { 22, 56, 187, 898, 0, 0 } }} },
        {BuildingType.研究院,new Dictionary<ItemType, List<int>>(){{ItemType.药材, new List<int>(){ 19, 46, 145, 656, 2320, 0 } },
                                                                 {ItemType.材料,new List<int>() { 24, 62, 214, 1070, 5145, 0 } }} },
        {BuildingType.五金店,new Dictionary<ItemType, List<int>>(){{ItemType.杂货,new List<int>(){ 21, 52, 0, 0, 0, 0 } },
                                                                {ItemType.材料,new List<int>(){ 20, 49, 0, 0, 0, 0 } }}},
        {BuildingType.百货店,new Dictionary<ItemType, List<int>>(){{ItemType.杂货, new List<int>(){ 23, 59, 200, 980, 0, 0 } },
                                                                {ItemType.材料,new List<int>(){ 22, 56, 187, 898, 0, 0 } }}},
        {BuildingType.万仙楼,new Dictionary<ItemType, List<int>>(){{ItemType.杂货, new List<int>(){ 25, 66, 232, 1189, 9948, 0 } },
                                                                {ItemType.材料,new List<int>(){ 24, 62, 214, 1070, 5145, 0 } }}},
        {BuildingType.拍卖行,new Dictionary<ItemType, List<int>>(){{ItemType.杂货, new List<int>(){ 25, 66, 232, 1189, 9948, 0 } },
                                                                {ItemType.材料,new List<int>(){ 24, 62, 214, 1070, 5145, 0 } }}},
        {BuildingType.铁匠铺,new Dictionary<ItemType, List<int>>(){{ItemType.兵器,new List<int>(){ 23, 59, 0, 0, 0, 0 } },
                                                                {ItemType.材料,new List<int>(){ 20, 49, 0, 0, 0, 0 } }}},
        {BuildingType.武器铺,new Dictionary<ItemType, List<int>>(){{ItemType.兵器, new List<int>(){ 25, 66, 232, 1189, 0, 0 } },
                                                                {ItemType.材料,new List<int>(){ 22, 56, 187, 898, 0, 0 } }}},
        {BuildingType.万兵阁,new Dictionary<ItemType, List<int>>(){{ItemType.兵器, new List<int>(){ 27, 73, 264, 1406, 7737, 0 } },
                                                                {ItemType.材料,new List<int>(){ 24, 62, 214, 1070, 5145, 0 } }}},
        {BuildingType.机关阁,new Dictionary<ItemType, List<int>>(){{ItemType.兵器, new List<int>(){ 25, 66, 232, 1189, 0, 0 } },
                                                                                                                    {ItemType.机关, new List<int>(){ 27, 73, 264, 1406, 7737, 0 }},
                                                                {ItemType.材料,new List<int>(){ 22, 56, 187, 898, 0, 0 } }}},
        {BuildingType.武侯楼,new Dictionary<ItemType, List<int>>(){{ItemType.兵器, new List<int>(){ 27, 73, 264, 1406, 7737, 0 } },
                                                                {ItemType.机关, new List<int>(){ 27, 73, 264, 1406, 7737, 0 }},
                                                                {ItemType.材料,new List<int>(){ 24, 62, 214, 1070, 5145, 0 } }}},
        {BuildingType.纺织铺,new Dictionary<ItemType, List<int>>(){{ItemType.服装,new List<int>(){ 22, 56, 0, 0, 0, 0 } },
                                                                {ItemType.材料,new List<int>(){ 20, 49, 0, 0, 0, 0 } }}},
        {BuildingType.服装店,new Dictionary<ItemType, List<int>>(){{ItemType.服装, new List<int>(){ 24, 62, 214, 1070, 0, 0 } },
                                                                {ItemType.材料,new List<int>(){ 22, 56, 187, 898, 0, 0 } }}},
        {BuildingType.梭织坊,new Dictionary<ItemType, List<int>>(){{ItemType.服装, new List<int>(){ 24, 62, 214, 1070, 0, 0 } },
                                                                {ItemType.材料,new List<int>(){ 22, 56, 187, 898, 0, 0 } }}},
        {BuildingType.玉服华裳,new Dictionary<ItemType, List<int>>(){{ItemType.服装, new List<int>(){ 26, 69, 246, 1283, 6907, 0 } },
                                                                {ItemType.材料,new List<int>(){ 24, 62, 214, 1070, 5145, 0 } }}},
        {BuildingType.长安织造,new Dictionary<ItemType, List<int>>(){{ItemType.服装, new List<int>(){ 26, 69, 246, 1283, 6907, 0 } },
                                                                {ItemType.材料,new List<int>(){ 24, 62, 214, 1070, 5145, 0 } }}},
        {BuildingType.戏馆,new Dictionary<ItemType, List<int>>(){{ItemType.书籍,new List<int>(){ 23, 59, 0, 0, 0, 0 } } }},
        {BuildingType.戏院,new Dictionary<ItemType, List<int>>(){{ItemType.书籍, new List<int>(){ 25, 66, 232, 1189, 0, 0 } }}},
        {BuildingType.鼓瑟楼,new Dictionary<ItemType, List<int>>(){{ItemType.书籍, new List<int>(){ 27, 73, 264, 1406, 7737, 0 } }}},
    };

    public static Dictionary<ItemType, List<int>> PawnshopPrice = new Dictionary<ItemType, List<int>>()
    {
        { ItemType.丹药,new List<int>()
        {
            10,20,30,40,50,60,70
        } },
        { ItemType.书籍,new List<int>()
        {
            10,20,30,40,50,60,70
        } },
        { ItemType.兵器,new List<int>()
        {
            10,20,30,40,50,60,70
        } },
        { ItemType.坐骑,new List<int>()
        {
            10,20,30,40,50,60,70
        } },
        {ItemType.奇兽,new List<int>()
        {
            10,20,30,40,50,60,70
        }},
        { ItemType.服装,new List<int>()
        {
            10,20,30,40,50,60,70
        } },
        { ItemType.机关,new List<int>()
        {
            10,20,30,40,50,60,70
        } },
        { ItemType.杂货,new List<int>()
        {
            10,20,30,40,50,60,70
        } },
        { ItemType.材料,new List<int>()
        {
            10,20,30,40,50,60,70
        } },
        { ItemType.药材,new List<int>()
        {
            10,20,30,40,50,60,70
        } },
        { ItemType.菜品,new List<int>()
        {
            10,20,30,40,50,60,70
        } },
        { ItemType.酒品,new List<int>()
        {
            10,20,30,40,50,60,70
        } },
        { ItemType.饰品,new List<int>()
        {
            10,20,30,40,50,60,70
        } },
    };
    public static List<int> ItemRentPrice = new List<int>()
    {9,27,81,243,729,2187};
    public static Dictionary<ItemName, string> ItemDescription = new Dictionary<ItemName, string>()
    {
        {ItemName.长生不老药,"丹如其名服下之后长生不老  。获得词条<color=#942E1C>长生不老</color>"},
        {ItemName.十全大补丸,"生死人肉白骨的丹药。获得词条<color=#942E1C>生死肉骨</color>"},
        {ItemName.和氏璧,"象征碧血丹心的美玉。获得词条<color=#942E1C>碧血丹心</color>"},
        {ItemName.落日神弓,"可射下太阳的神弓。获得词条<color=#98640B>穿日</color>"},
        {ItemName.暴雨梨花针,"杀人于无形 短促而至。获得词条<color=#98640B>无声</color>"},
        {ItemName.青龙方戟,"青龙之力所至。获得词条<color=#98640B>青龙</color>"},
        {ItemName.百胜刀,"百战百胜之刀。获得词条<color=#98640B>必胜</color>"},
        {ItemName.擎天枪,"擎天之柱所锻造之枪 可撑天。获得词条<color=#98640B>撑天</color>"},
        {ItemName.龙源剑,"祖龙之佩剑。获得词条<color=#98640B>龙之力</color>"},
        {ItemName.浪击连弩,"射速犹如海浪一般 （可以合成UR 大人 时代变了 的道具 ）。获得词条<color=#98640B>火力压制</color>"},
        {ItemName.仙人醉,"曾有酒仙尝尽天下琼瑶佳酿独爱此酒。获得词条<color=#98640B>醉生梦死</color>"},
        {ItemName.黄金甲,"金闪闪的护甲。获得词条<color=#98640B>金光闪闪</color>"},
        {ItemName.钻石,"极其坚固的矿石，样貌喜人。获得词条<color=#98640B>光碎</color>"},
        {ItemName.龙马,"有龙之血统的马。获得词条<color=#98640B>龙马精神</color>"},
        {ItemName.大汗之鹰,"史书上征服王的猎鹰。获得词条<color=#98640B>鹰之力</color>"},
        {ItemName.天机造化丹,"传说中的丹药，迎合天理，服下后可推演未来。获得词条<color=#98640B>窥得天机</color>"},
        {ItemName.阴阳玄龙丹,"传说中的丹药，成丹时阴阳汇聚隐有龙吟，服下之后百毒不侵。获得词条<color=#98640B>百毒不侵</color>"},
        {ItemName.祈天玄衣,"祭天时太子的衣物。获得词条<color=#98640B>潜光隐耀</color>"},
        {ItemName.步辇袍衫,"国之重臣所穿着的服饰。获得词条<color=#98640B>深仁厚泽</color>"},
        {ItemName.青织飞鱼袍,"御赐的服饰，形如飞鱼类蟒，官运通达。获得词条<color=#98640B>平步青云</color>"},
        {ItemName.犬,"嘤嘤的叫声有极其强大的穿透力。获得词条<color=#694F70>嘤嘤狂吠</color>"},
        {ItemName.豹子,"速度的象征传言速度达到一定程度可以在水上奔跑。获得词条<color=#694F70>波纹行走</color>"},
        {ItemName.象虎,"传说中的生物似象似虎力大无穷。获得词条<color=#694F70>象虎之力</color>"},
        {ItemName.山海经,"流落江湖的奇书，其中包罗万象，通贯古今。获得词条<color=#694F70>书通二酉</color>"},
        {ItemName.机关残卷,"破烂的书卷，似乎记载了一些机关术。获得词条书通<color=#694F70>偃师</color>"},
        {ItemName.阴阳八卦盘,"遵循阴阳之理的宝盘。获得词条<color=#694F70>奇门遁甲</color>"},
        {ItemName.鬼谷子,"纵横家的书籍。获得词条<color=#694F70>纵横家</color>"},
        {ItemName.欧冶子的大锤,"欧冶子锻造用的大锤子。获得词条<color=#694F70>大锤</color>"},
        {ItemName.黄帝内经,"上古流传的医学经典。获得词条<color=#694F70>黄帝内经</color>"},
        {ItemName.本草纲目,"详细介绍所有药材的巨作。获得词条<color=#694F70>本草纲目</color>"},
        {ItemName.穿石烈风弓,"传说能射穿巨石的重弓。获得词条<color=#694F70>百步穿杨</color>"},
        {ItemName.烈火斩云刀,"厚背片圆的大刀，据说可断水流。获得词条<color=#694F70>刀王</color>"},
        {ItemName.紫木雷电枪,"混身闪烁着电光的紫木长枪。获得词条<color=#694F70>雷电法王</color>"},
        {ItemName.加十二的宝剑,"一把+12的五光十色的宝剑 但是攻击只加1 这是土豪的标配。获得词条<color=#694F70>氪金战士</color>"},
        {ItemName.美梦酒,"好喝的美酒。获得词条<color=#694F70>诗兴大发</color>"},
        {ItemName.三味酒,"好喝的美酒。获得词条<color=#694F70>如醉如狂</color>"},
        {ItemName.皇之剑,"皇帝之佩剑 传说皇命之人的标配。获得词条<color=#694F70>皇家血统</color>"},
        {ItemName.天霸方天戟,"霸者之方天戟  持有者都是气力过人之人。获得词条<color=#694F70>霸王</color>"},
        {ItemName.混元功,"绝世奇功 可离空飞行。获得词条<color=#694F70>气功达人</color>"},
        {ItemName.高汤白菜,"高汤撒在 十八种香料清蒸出的白菜。获得词条<color=#694F70>把素持斋</color>"},
        {ItemName.龙井竹荪,"这是一道香气扑鼻的江蘇地區名菜。 获得词条<color=#694F70>把素持斋</color>"},
        {ItemName.文化沙漠,"阿巴阿巴。获得词条<color=#694F70>文化沙漠</color>"},
        {ItemName.八宝野鸭,"鸭子里面放白果、红枣、芡实 ，优质香菇、火腿、松子、鸭肫、糯米 炖煮而成。获得词条<color=#694F70>盛食厉兵</color>"},
        {ItemName.佛手金卷,"用鸡蛋皮 包住精细猪肉末放在油锅里炸熟捞出即可。获得词条<color=#694F70>盛食厉兵</color>"},
        {ItemName.神气丹,"江湖武者中流传甚广的丹药。获得词条<color=#694F70>武功小成</color>"},
        {ItemName.养气筑基散,"江湖武者中流传甚广的丹药。获得词条<color=#694F70>武功小成</color>"},
        {ItemName.医圣的药箱,"古代医生遗留下的药箱。获得词条<color=#694F70>妙手丹心</color>"},
        {ItemName.鸽血红,"色泽纯净如同燃烧的火。获得词条<color=#694F70>侵略如火</color>"},
        {ItemName.木佐绿,"苍翠刚劲，如文人雅士。获得词条<color=#694F70>仁人君子</color>"},
        {ItemName.撕风赤兔马,"赤兔马中可以撕裂飓风的存在。获得词条<color=#694F70>宝马良驹</color>"},
        {ItemName.亮云白龙驹,"传说此白马一出可和月亮比亮度 。获得词条<color=#694F70>宝马良驹</color>"},
        {ItemName.堕云虎,"老虎上面有一层 黑色的云纹落在身上 夜晚显得黑暗和神秘。获得词条<color=#694F70>虎猛</color>"},
        {ItemName.弯月狼,"狼头上有一弯明月  狼皮十分光滑柔顺 摸起来很舒服。获得词条<color=#694F70>独狼</color>"},
        {ItemName.朱户衣,"朱红色的衣物为天子所赐以奖赏忠臣。获得词条<color=#694F70>忠贞之志</color>"},
        {ItemName.云纹袍,"纹有云纹的袍衫，据说穿上之后有气运加身。获得词条<color=#694F70>景星庆云</color>"},
        {ItemName.长袖装,"书生喜好的一种衣物。获得词条<color=#694F70>长袖善舞</color>"},
        {ItemName.金钱镖,"形似铜钱实则锋利无比的暗器。获得词条<color=#694F70>金钱镖</color>"},
        {ItemName.袖炮,"运用火药的特殊暗器。获得词条<color=#694F70>袖炮</color>"},
        {ItemName.血滴子,"极为复杂的暗器。获得词条<color=#694F70>血滴子</color>"},
        {ItemName.灵芝,"名贵的药材。获得词条<color=#694F70>妙手丹心</color>"},
        {ItemName.锦绣华服,"奢侈 的衣服上面装有 黄金宝石点缀。获得词条<color=#694F70>理财大师</color>"},
        {ItemName.玉手镯,"圆润的玉制手镯。获得词条<color=#694F70>珠圆玉润</color>"},
        {ItemName.木须柿子,"切好的柿子和鸡蛋抄在一块。获得词条<color=#535D77>素餐</color>"},
        {ItemName.酸菜粉条,"经过冲洗的酸菜和粉条一起炖煮  又酸又绸。\n 获得词条<color=#535D77>素餐</color>"},
        {ItemName.红烧茄子,"经过红烧做出来的的茄子 看起来十分好吃 。\n 获得词条<color=#535D77>素餐</color>"},
        {ItemName.清炒菜心,"精选的菜心清炒的菜肴。获得词条<color=#535D77>素餐</color>"},
        {ItemName.蒜薹炒肉,"切好的蒜薹和肉炒在一起  香飘四溢。获得词条<color=#535D77>荤食</color>"},
        {ItemName.木须肉,"黄瓜 鸡蛋 木耳加上猪肉 十分下饭 。获得词条<color=#535D77>荤餐</color>"},
        {ItemName.沸腾散,"以智商为代价提升武力的丹药。获得词条<color=#535D77>疯子</color>"},
        {ItemName.龙虎丹,"强健体魄的丹药。获得词条<color=#535D77>武艺精湛</color>"},
        {ItemName.洗髓丹,"可以提升根骨的丹药。获得词条<color=#535D77>根骨清奇</color>"},
        {ItemName.蛤蟆功秘籍,"记载了蛤蟆功的秘籍。获得词条<color=#535D77>蛤蟆功</color>"},
        {ItemName.浑天仪,"用来观察天体运动的仪器。获得词条<color=#535D77>通晓天文</color>"},
        {ItemName.冰霜宝剑,"充满寒气铭文的宝剑，似乎不是此界之物。获得词条<color=#535D77>冰霜宝剑</color>"},
        {ItemName.黄金弓,"一把黄金做的弓 十分漂亮 可惜一拉就断。获得词条<color=#535D77>箭无虚发</color>"},
        {ItemName.白银枪,"白银做枪头的枪。获得词条<color=#535D77>一点寒芒</color>"},
        {ItemName.大砍刀,"一把锋利的大砍刀 吹毛断发。获得词条<color=#535D77>买瓜人</color>"},
        {ItemName.铁片戟,"长戟周围布满铁片  习武之人练手的武器。获得词条<color=#535D77>武艺精湛</color>"},
        {ItemName.九阳真经,"流落江湖的武学秘籍。获得词条<color=#535D77>登堂入室</color>"},
        {ItemName.九阴真经,"流落江湖的武学残卷。获得词条<color=#535D77>走火入魔</color>"},
        {ItemName.金绿宝石,"美丽而庄重的宝石 忠诚+2  喜爱物+4。获得词条<color=#535D77>鸿运当头</color>"},
        {ItemName.火炮,"笨重却威力强大的武器，无法用来攻敌但是用来防卫效果极佳。获得词条<color=#535D77>火炮</color>"},
        {ItemName.东洋词典,"阅读词典可以学习东洋语。获得词条<color=#535D77>东洋语</color>"},
        {ItemName.西洋词典,"阅读词典可以学习西洋语。获得词条<color=#535D77>西洋语</color>"},
        {ItemName.丝绸,"织布的材料。获得词条<color=#535D77>丝绸</color>"},
        {ItemName.护心镜,"防护面积有限的护甲。获得词条<color=#535D77>护心</color>"},
        {ItemName.皮甲,"猎户经常穿着的护甲。获得词条<color=#535D77>皮甲</color>"},
        {ItemName.铁甲,"护卫经常穿着的护甲，有些笨重。获得词条<color=#535D77>铁甲</color>"},
        {ItemName.人参,"药材，可以炼丹也可以直接使用不过没什么用。获得词条<color=#535D77>辟邪安正</color>"},
        {ItemName.当归,"药材，可以炼丹也可以直接使用不过没什么用。获得词条<color=#535D77>辟邪安正</color>"},
        {ItemName.沉香,"药材，可以炼丹也可以直接使用不过没什么用。获得词条<color=#535D77>辟邪安正</color>"},
        {ItemName.水翁花,"药材，可以炼丹也可以直接使用不过没什么用。获得词条<color=#535D77>辟邪安正</color>"},
        {ItemName.虎骨,"药材，可以炼丹也可以直接使用不过没什么用。获得词条<color=#535D77>辟邪安正</color>"},
        {ItemName.守宫,"药材，可以炼丹也可以直接使用不过没什么用。获得词条<color=#535D77>辟邪安正</color>"},
        {ItemName.羽衣,"舞女的服装，增加穿戴之人的魅力。获得词条<color=#535D77>能歌善舞</color>"},
        {ItemName.红宝石,"闪亮的宝石。获得词条<color=#535D77>珠光宝气</color>"},
        {ItemName.紫水晶,"闪亮的宝石。获得词条<color=#535D77>珠光宝气</color>"},
        {ItemName.蛋白石,"闪亮的宝石。获得词条<color=#535D77>珠光宝气</color>"},
        {ItemName.祖母绿,"闪亮的宝石。获得词条<color=#535D77>珠光宝气</color>"},
        {ItemName.墨子非攻,"流落江湖的墨家典籍。获得词条<color=#535D77>非攻</color>"},
        {ItemName.墨子兼爱,"流落江湖的墨家重要典籍。获得词条<color=#535D77>兼爱</color>"},
        {ItemName.御马官印,"皇帝赐予的官印。获得词条<color=#535D77>御马司</color>"},
        {ItemName.毒经,"从南疆传来的奇技。获得词条<color=#535D77>毒师</color>"},
        {ItemName.唯物论,"不符合时代的哲学典籍。获得词条<color=#535D77>离经叛道</color>"},
        {ItemName.毒奶瓶,"传说中一黄姓仙人言出法随,持有此法宝将获得黄老仙的气运加持。获得词条<color=#535D77>厄运缠身</color>"},
        {ItemName.棋诀,"可以研习到颇为高深的棋术。获得词条<color=#535D77>棋道</color>"},
        {ItemName.竹叶青,"普遍的酒。获得词条<color=#535D77>好酒之人</color>"},
        {ItemName.杜康酒,"普遍的酒。获得词条<color=#535D77>好酒之人</color>"},
        {ItemName.女儿红,"普遍的酒。获得词条<color=#535D77>好酒之人</color>"},
        {ItemName.货殖列传,"经济著作。获得词条<color=#535D77>经济学</color>"},
        {ItemName.欧冶子的小锤,"欧冶子锻造用的小锤子。获得词条<color=#535D77>小锤子</color>"},
        {ItemName.伤寒杂病论,"郎中必学的医学作品。获得词条<color=#535D77>郎中</color>"},
        {ItemName.五香粉,"各种调料混合而成  酸甜苦辣咸。获得词条<color=#535D77>五味杂陈</color>"},
        {ItemName.活泼的快马,"毛毛躁躁的马。获得词条<color=#535D77>飞毛腿</color>"},
        {ItemName.老虎,"可以驯服的猛兽。获得词条<color=#535D77>驯兽术</color>"},
        {ItemName.狼,"可以驯服的猛兽。获得词条<color=#535D77>驯兽术</color>"},
        {ItemName.锤子,"打铁常用的工具。获得词条<color=#535D77>匠人</color>"},
        {ItemName.绣花针,"织布常用的工具。获得词条<color=#535D77>匠人</color>"},
        {ItemName.朱砂脂,"受女性喜爱的胭脂。获得词条<color=#535D77>珠光宝气</color>"},
        {ItemName.刻刀,"刻画常用的工具。获得词条<color=#535D77>匠人</color>"},
        {ItemName.大宛马,"普遍的马。获得词条<color=#535D77>飞毛腿</color>"},
        {ItemName.蒙古马,"普遍的马。获得词条<color=#535D77>飞毛腿</color>"},
        {ItemName.凉州马,"普遍的马。获得词条<color=#535D77>飞毛腿</color>"},
        {ItemName.峨眉刺,"一种暗器需要一定的身手。获得词条<color=#535D77>身形矫健</color>"},
        {ItemName.袖箭,"一种发射短箭的暗器。获得词条<color=#535D77>箭无虚发</color>"},
        {ItemName.小刀,"涂了毒的小刀。获得词条<color=#535D77>毒师</color>"},
        {ItemName.背剑,"单刃剑使用之人需要武学基础。获得词条<color=#535D77>武艺精湛</color>"},
        {ItemName.酒葫芦,"充满酒的葫芦。获得词条<color=#535D77>醉拳</color>"},
        {ItemName.文官状,"皇帝赐予的委任状。获得词条<color=#5E5D41>文贞</color>"},
        {ItemName.武官状,"皇帝赐予的委任状。获得词条<color=#5E5D41>武勇</color>"},
        {ItemName.弹劾文书,"用于弹劾的文书，拥有此物会被同行挤兑。获得词条<color=#785E57>惹人嫌</color>。" },
        {ItemName.蓑衣,"平常渔民的服装。获得词条<color=#5E5D41>平平无奇</color>"},
        {ItemName.布衣,"平民百姓的服装。获得词条<color=#5E5D41>平平无奇</color>"},
        {ItemName.青酒,"便宜的酒。获得词条<color=#5E5D41>醉酒</color>"},
        {ItemName.黄酒,"便宜的酒。获得词条<color=#5E5D41>醉酒</color>"},
        {ItemName.羊酒,"便宜的酒。获得词条<color=#5E5D41>醉酒</color>"},
        {ItemName.芦酒,"便宜的酒。获得词条<color=#5E5D41>醉酒</color>"},
        {ItemName.杏仁酒,"便宜的酒。获得词条<color=#5E5D41>醉酒</color>"},
        {ItemName.银条酒,"便宜的酒。获得词条<color=#5E5D41>醉酒</color>"},
        {ItemName.零落的宝石,"有残次的宝石。获得词条<color=#5E5D41>敝帚自珍</color>"},
        {ItemName.缺口的宝石,"有残次的宝石。获得词条<color=#5E5D41>敝帚自珍</color>"},
        {ItemName.有破损的黄金,"有残次的宝石。获得词条<color=#5E5D41>敝帚自珍</color>"},
        {ItemName.吵闹的鹦鹉,"会夸赞人的鹦鹉。获得词条<color=#5E5D41>花言巧语</color>"},
        {ItemName.良姜,"食材。获得词条<color=#5E5D41>无伤大雅</color>"},
        {ItemName.谷芽,"食材。获得词条<color=#5E5D41>无伤大雅</color>"},
        {ItemName.陈皮,"食材。获得词条<color=#5E5D41>无伤大雅</color>"},
        {ItemName.羊乳,"食材。获得词条<color=#5E5D41>无伤大雅</color>"},
        {ItemName.红花,"食材。获得词条<color=#5E5D41>无伤大雅</color>"},
        {ItemName.官宸书,"记录了各种小计谋的书。获得词条<color=#5E5D41>绣花枕头</color>"},
        {ItemName.杂技,"记载了各种杂技。获得词条<color=#5E5D41>梧鼠五技</color>"},
        {ItemName.奉子丹,"神奇的丹药专治不孕不育。获得词条<color=#5E5D41>身怀六甲</color>"},
        {ItemName.麝香,"药材。获得词条<color=#5E5D41>不孕不育</color>"},
        {ItemName.洗冤录,"记录了各种冤案的书册。获得词条<color=#5E5D41>讼师</color>"},
        {ItemName.咖啡,"西方传入的饮品，提神醒脑。获得词条<color=#5E5D41>夜不能寐</color>"},
        {ItemName.剪刀,"阉割用的锋利剪刀。获得词条<color=#5E5D41>阉人</color>"},
        {ItemName.长脚马,"腿十分长的马。获得词条<color=#5E5D41>飞毛腿</color>"},
        {ItemName.短尾马,"好像没有尾巴的马。获得词条<color=#5E5D41>飞毛腿</color>"},
        {ItemName.孝经,"教导如何为孝的书籍，好像效果不是很好。获得词条<color=#5E5D41>不孝子</color>"},
        {ItemName.雕,"训练有素的雕。获得词条<color=#5E5D41>雕</color>"},
        {ItemName.毛笔,"普通的硬毫笔用兔毫制成。获得词条<color=#5E5D41>儒生</color>"},
        {ItemName.拂尘,"道士常用的白色拂尘。获得词条<color=#5E5D41>道士</color>"},
        {ItemName.佛珠,"和尚常用的佛珠。获得词条<color=#5E5D41>僧人</color>"},
        {ItemName.木佛像,"平平无奇用木头雕刻的佛像。获得词条<color=#5E5D41>僧人</color>"},
        {ItemName.蚕丝,"纺织材料。获得词条<color=#5E5D41>鸠工庀材</color>"},
        {ItemName.皮毛,"纺织材料。获得词条<color=#5E5D41>鸠工庀材</color>"},
        {ItemName.麻布,"纺织材料。获得词条<color=#5E5D41>鸠工庀材</color>"},
        {ItemName.马经,"详细讲述了养马之术。获得词条<color=#5E5D41>马倌</color>"},
        {ItemName.药材大全,"记载了大部分常用药材。获得词条<color=#5E5D41>丹童</color>"},
        {ItemName.弓,"猎户常用的木制弓。获得词条<color=#5E5D41>弓</color>"},
        {ItemName.刀,"精铁打造的朴刀。获得词条<color=#5E5D41>刀</color>"},
        {ItemName.枪,"普普通通的红缨枪。获得词条<color=#5E5D41>枪</color>"},
        {ItemName.剑,"随处可见的铁剑。获得词条<color=#5E5D41>剑</color>"},
        {ItemName.戟,"平平无奇的长戟。获得词条<color=#5E5D41>戟</color>"},
        {ItemName.演员的自我修养,"什么斯夫拉基的著作。获得词条<color=#5E5D41>演员</color>"},
        {ItemName.汤头歌诀,"医学入门书籍，非常适合初学者。获得词条<color=#5E5D41>医术</color>"},
        {ItemName.飞蝗石,"可以作为暗器使用，效果甚微。获得词条<color=#5E5D41>梧鼠五技</color>"},
        {ItemName.树叶,"可以作为暗器使用，效果甚微。获得词条<color=#5E5D41>梧鼠五技</color>"},
        {ItemName.何首乌,"药材，可以使人毛发旺盛。获得词条毛发茂盛<color=#5E5D41>毛发茂盛</color>"},
        {ItemName.金疮药,"跌打药，习武之人常备。获得词条<color=#5E5D41>习武之人</color>"},
        {ItemName.糖,"调味品。获得词条<color=#5E5D41>嗜甜如命</color>"},
        {ItemName.止血膏,"跌打药，习武之人常备。获得词条<color=#5E5D41>习武之人</color>"},
        {ItemName.舒服的椅子,"可以纠正体态的膏药。获得词条<color=#5E5D41>体态端正</color>"},
        {ItemName.清炒豆芽,"清炒的豆芽 十分清脆。获得词条<color=#5E5D41>饱腹</color>"},
        {ItemName.拍黄瓜,"拍烂的黄瓜  撒盐来调味。获得词条<color=#5E5D41>饱腹</color>"},
        {ItemName.蛋炒饭,"加了鸡蛋的炒饭。获得词条<color=#5E5D41>饱腹</color>"},
        {ItemName.清蒸白萝卜,"洗净的白萝卜加了盐调味。获得词条<color=#5E5D41>饱腹</color>"},
        {ItemName.铁矿,"可以制作武器的的铁矿。获得词条<color=#5E5D41>鸠工庀材</color>"},
        {ItemName.铜矿,"可以制作武器的的铜矿。获得词条<color=#5E5D41>鸠工庀材</color>"},
        {ItemName.银矿,"可以制作武器的的银矿。获得词条<color=#5E5D41>鸠工庀材</color>"},
        {ItemName.布匹,"可以缝制衣服的布匹。获得词条<color=#5E5D41>鸠工庀材</color>"},
        {ItemName.木头,"工匠材料。获得词条<color=#5E5D41>鸠工庀材</color>"},
        {ItemName.皮革,"工匠材料。获得词条<color=#5E5D41>鸠工庀材</color>"},
        {ItemName.铆钉,"工匠材料。获得词条<color=#5E5D41>鸠工庀材</color>"},
        {ItemName.硬木,"工匠材料。获得词条<color=#5E5D41>鸠工庀材</color>"},
        {ItemName.唇纸,"受女子喜欢的化妆品。获得词条<color=#5E5D41>绣花枕头</color>"},
        {ItemName.胭脂,"受女子喜欢的化妆品。获得词条<color=#5E5D41>绣花枕头</color>"},
        {ItemName.油,"日常用品。获得词条<color=#5E5D41>杂七杂八</color>"},
        {ItemName.绳子,"日常用品。获得词条<color=#5E5D41>杂七杂八</color>"},
        {ItemName.酱油,"日常用品。获得词条<color=#5E5D41>杂七杂八</color>"},
        {ItemName.醋,"日常用品。获得词条<color=#5E5D41>杂七杂八</color>"},
        {ItemName.盐,"日常用品。获得词条<color=#5E5D41>杂七杂八</color>"},
        {ItemName.棍子,"一根棍子。获得词条<color=#785E57>无用之人</color>"},
        {ItemName.乌桕子,"药材吃了会中毒。获得词条<color=#785E57>药毒</color>"},
        {ItemName.铁苋,"药材吃了会中毒。获得词条<color=#785E57>药毒</color>"},
        {ItemName.八角莲,"药材吃了会中毒。获得词条<color=#785E57>药毒</color>"},
        {ItemName.黄芪,"药材吃了会中毒。获得词条<color=#785E57>药毒</color>"},
        {ItemName.罗汉果,"药材吃了会中毒。获得词条<color=#785E57>药毒</color>"},
        {ItemName.血风藤,"药材吃了会中毒。获得词条<color=#785E57>药毒</color>"},
        {ItemName.黄精,"药材吃了会中毒。获得词条<color=#785E57>药毒</color>"},
        {ItemName.白花蛇舌草,"药材吃了会中毒。获得词条<color=#785E57>药毒</color>"},
        {ItemName.水酒,"劣质酒。获得词条<color=#785E57>头疼</color>"},
        {ItemName.毒酒,"有毒的酒。获得词条<color=#785E57>身体孱弱</color>"},
        {ItemName.有缺口的武器,"已经不堪一用的武器。获得词条<color=#785E57>无能狂怒</color>"},
        {ItemName.烂衣服,"乞丐都不稀罕破破烂烂的衣服。获得词条<color=#785E57>衣不蔽体</color>"},
        {ItemName.肥马,"十分肥胖的马。获得词条<color=#785E57>肥胖症</color>"},
        {ItemName.三七,"药材吃了会中毒。获得词条<color=#785E57>药毒</color>"},
        {ItemName.轻粉,"药材吃了会中毒。获得词条<color=#785E57>药毒</color>"},
        {ItemName.核桃粉,"日常用品。获得词条<color=#785E57>杂七杂八</color>"},
        {ItemName.过山龙,"药材吃了会中毒。获得词条<color=#785E57>药毒</color>"},
        {ItemName.星辰花,"药材吃了会中毒。获得词条<color=#785E57>药毒</color>"},
    };
    public static ItemType FindType(ItemName item)
    {
        foreach (ItemType key in ItemTypeDict.Keys)
        {
            if (ItemTypeDict[key].Contains(item))
            {
                return key;
            }
        }
        return ItemType.服装;
    }
}
