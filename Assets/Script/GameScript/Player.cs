using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private Map map;
    public static Dictionary<Tag, List<int>> TagInfDict = new Dictionary<Tag, List<int>>() {
        {Tag.Null, new List<int>(){0,0,0,0, 0,0}},
        {Tag.大人时代变了,new List<int>(){0,0,0,12,0,0}},
        {Tag.弈星下凡,new List<int>(){0,0,12,0,0,0}},
        {Tag.钜子,new List<int>(){4,0,0,-4,12,0}},
        {Tag.文武双全,new List<int>(){6,6,6,6,6,6}},
        {Tag.成道,new List<int>(){10,10,10,10,10,10}},
        {Tag.黯然销魂掌,new List<int>(){-6,-5,-6,9,9,9}},
        {Tag.围棋十段,new List<int>(){0,0,10,0,0,0}},
        {Tag.状元,new List<int>(){8,0,0,0,0,0}},
        {Tag.诗仙,new List<int>(){0,8,0,0,0,0}},
        {Tag.卧龙,new List<int>(){0,0,8,0,0,0}},
        {Tag.八斗之才,new List<int>(){7,7,7,-3,-4,-4}},
        {Tag.武圣,new List<int>(){0,0,0,8,0,0}},
        {Tag.无影,new List<int>(){0,0,0,0,8,0}},
        {Tag.磐石,new List<int>(){0,0,0,0,0,8}},
        {Tag.诸武精通,new List<int>(){-4,-4,-3,7,7,7}},
        {Tag.纸上谈兵,new List<int>(){10,0,-1,0,0,0}},
        {Tag.徒有虚名,new List<int>(){-1,10,0,0,0,0}},
        {Tag.投机取巧,new List<int>(){0,-1,10,0,0,0}},
        {Tag.混世魔王,new List<int>(){0,0,0,10,0,-1}},
        {Tag.心狠手辣,new List<int>(){0,0,0,0,10,-1}},
        {Tag.墨守成规,new List<int>(){0,0,0,0,-1,10}},
        {Tag.巧夺天工,new List<int>(){3,0,-1,0,0,8}},
        {Tag.悬壶济世,new List<int>(){10,7,0,-3,-2,-2}},
        {Tag.墨者,new List<int>(){7,-3,0,-4,10,0}},
        {Tag.文,new List<int>(){3,3,3,-1,0,-1}},
        {Tag.武,new List<int>(){-1,-1,0,3,3,3}},
        {Tag.书通二酉,new List<int>(){5,0,0,0,0,0}},
        {Tag.才华横溢,new List<int>(){0,5,0,0,0,0}},
        {Tag.工于心计,new List<int>(){0,0,5,0,0,0}},
        {Tag.力拔山兮,new List<int>(){0,0,0,5,0,0}},
        {Tag.出没无常,new List<int>(){0,0,0,0,5,0}},
        {Tag.广厦之荫,new List<int>(){0,0,0,0,0,5}},
        {Tag.智勇双全,new List<int>(){0,-4,5,5,0,0}},
        {Tag.偃师,new List<int>(){5,0,0,-4,5,0}},
        {Tag.奇门遁甲,new List<int>(){0,5,0,0,-4,5}},
        {Tag.天生神力,new List<int>(){0,0,-1,8,0,0}},
        {Tag.阳明学派,new List<int>(){4,4,4,-2,-2,-1}},
        {Tag.吸星大法,new List<int>(){0,0,0,37,43,0}},
        {Tag.巫妖领主,new List<int>(){0,0,0,7,0,0}},
        {Tag.龙骑士,new List<int>(){-2,0,-3,4,4,4}},
        {Tag.外交官,new List<int>(){4,4,0,-1,0,0}},
        {Tag.老当益壮,new List<int>(){0,-3,0,2,2,6}},
        {Tag.炼金术师,new List<int>(){6,-5,0,0,6,0}},
        {Tag.近战精通,new List<int>(){-4,-4,0,5,5,5}},
        {Tag.古神转世,new List<int>(){8,-25,4,8,4,8}},
        {Tag.理财大师,new List<int>(){0,2,3,0,0,0}},
        {Tag.纵横家,new List<int>(){0,2,5,0,0,0}},
        {Tag.大锤,new List<int>(){0,0,-1,0,0,8}},
        {Tag.戏精,new List<int>(){0,3,3,0,0,0}},
        {Tag.黄帝内经,new List<int>(){8,5,0,-6,0,0}},
        {Tag.本草纲目,new List<int>(){7,0,0,0,0,0}},
        {Tag.御马监,new List<int>(){0,0,0,0,0,5}},
        {Tag.驯兽大师,new List<int>(){0,0,0,0,3,3}},
        {Tag.朝奉,new List<int>(){0,3,4,0,0,0}},
        {Tag.文正,new List<int>(){2,2,2,-1,-1,0}},
        {Tag.武忠,new List<int>(){-1,-1,0,2,2,2}},
        {Tag.书痴,new List<int>(){3,0,0,0,0,0}},
        {Tag.略有才名,new List<int>(){0,3,0,0,0,0}},
        {Tag.小有谋略,new List<int>(){0,0,3,0,0,0}},
        {Tag.武痴,new List<int>(){0,0,0,3,0,0}},
        {Tag.身形矫健,new List<int>(){0,0,0,0,3,0}},
        {Tag.老罴当道,new List<int>(){0,0,0,0,0,3}},
        {Tag.法外狂徒,new List<int>(){0,-4,4,0,4,0}},
        {Tag.蛤蟆功,new List<int>(){0,-2,-2,2,2,4}},
        {Tag.欢喜佛,new List<int>(){4,0,0,0,0,0}},
        {Tag.恶魔人,new List<int>(){0,0,0,2,1,1}},
        {Tag.通晓天文,new List<int>(){0,0,4,0,0,0}},
        {Tag.冰霜宝剑,new List<int>(){0,0,0,4,0,0}},
        {Tag.飞毛腿,new List<int>(){0,0,0,0,2,0}},
        {Tag.火炮,new List<int>(){0,0,0,0,0,3}},
        {Tag.东洋语,new List<int>(){2,1,0,0,0,0}},
        {Tag.能歌善舞,new List<int>(){0,0,0,0,2,0}},
        {Tag.西洋语,new List<int>(){2,1,0,0,0,0}},
        {Tag.毒师,new List<int>(){0,0,0,0,3,0}},
        {Tag.离经叛道,new List<int>(){2,0,0,0,0,0}},
        {Tag.外乡人,new List<int>(){0,0,1,0,2,0}},
        {Tag.疯子,new List<int>(){-1,-1,-1,3,0,2}},
        {Tag.棋道,new List<int>(){0,0,3,0,0,0}},
        {Tag.心算,new List<int>(){0,2,0,0,0,0}},
        {Tag.经济学,new List<int>(){0,0,2,0,0,0}},
        {Tag.小锤,new List<int>(){0,0,0,0,0,4}},
        {Tag.郎中,new List<int>(){2,1,0,0,0,0}},
        {Tag.老戏骨,new List<int>(){0,0,3,0,0,0}},
        {Tag.驯兽术,new List<int>(){0,0,0,0,3,0}},
        {Tag.御马司,new List<int>(){0,0,0,0,0,3}},
        {Tag.牧民,new List<int>(){0,0,0,0,0,2}},
        {Tag.兼爱,new List<int>(){0,0,0,0,0,0}},
        {Tag.货郎,new List<int>(){0,2,0,0,0,0}},
        {Tag.非攻,new List<int>(){5,0,0,-1,0,0}},
        {Tag.文贞,new List<int>(){1,1,1,-1,0,-1}},
        {Tag.武勇,new List<int>(){-1,-1,0,1,1,1}},
        {Tag.有勇无谋,new List<int>(){0,0,-2,1,0,0}},
        {Tag.花言巧语,new List<int>(){0,-2,1,0,0,0}},
        {Tag.绣花枕头,new List<int>(){-2,1,0,0,0,0}},
        {Tag.梧鼠五技,new List<int>(){-2,0,0,0,1,0}},
        {Tag.自是三公,new List<int>(){1,0,0,0,-2,0}},
        {Tag.敝帚自珍,new List<int>(){0,0,1,0,0,-2}},
        {Tag.不孕不育,new List<int>(){0,0,0,0,0,0}},
        {Tag.巨人症,new List<int>(){0,0,0,1,0,0}},
        {Tag.侏儒症,new List<int>(){1,0,0,0,0,0}},
        {Tag.儒生,new List<int>(){0,1,0,0,0,0}},
        {Tag.道士,new List<int>(){0,0,1,0,0,0}},
        {Tag.僧人,new List<int>(){1,0,0,0,0,0}},
        {Tag.讼师,new List<int>(){0,0,1,0,0,0}},
        {Tag.冷血无情,new List<int>(){-3,0,0,1,2,1}},
        {Tag.阉人,new List<int>(){0,0,0,-1,1,-1}},
        {Tag.吸血鬼,new List<int>(){0,-2,0,1,2,0}},
        {Tag.狼人,new List<int>(){0,0,-2,2,0,1}},
        {Tag.膝盖僵硬,new List<int>(){0,0,0,0,-1,0}},
        {Tag.多动症,new List<int>(){0,0,0,1,-1,0}},
        {Tag.平平无奇,new List<int>(){0,0,0,0,0,0}},
        {Tag.雕,new List<int>(){-1,-2,0,0,2,2}},
        {Tag.习武之人,new List<int>(){0,-2,0,1,1,1}},
        {Tag.丹童,new List<int>(){2,0,0,-1,-1,0}},
        {Tag.弓,new List<int>(){0,0,0,0,2,-1}},
        {Tag.剑,new List<int>(){0,0,0,1,0,0}},
        {Tag.枪,new List<int>(){0,0,0,1,-1,1}},
        {Tag.贪污狼藉,new List<int>(){-1,-1,2,0,0,0}},
        {Tag.演员,new List<int>(){0,1,0,0,0,0}},
        {Tag.六根不净,new List<int>(){-1,0,0,0,0,0}},
        {Tag.刀,new List<int>(){0,0,0,0,0,1}},
        {Tag.戟,new List<int>(){0,0,0,0,-1,2}},
        {Tag.医术,new List<int>(){2,1,0,-2,0,0}},
        {Tag.马倌,new List<int>(){0,0,0,0,0,0}},
        {Tag.厄运缠身,new List<int>(){0,0,-4,0,0,0}},
        {Tag.不孝子,new List<int>(){0,-3,0,0,0,0}},
        {Tag.腿脚不便,new List<int>(){0,0,0,-1,-1,-1}},
        {Tag.年老体衰,new List<int>(){1,0,0,-2,-2,-2}},
        {Tag.醉酒,new List<int>(){0,0,0,-1,-1,-1}},
        {Tag.身世悲苦,new List<int>(){-5,-5,2,1,1,2}},
        {Tag.精神病,new List<int>(){-2,-2,-2,2,0,0}},
        {Tag.近视,new List<int>(){0,0,0,-3,0,0}},
        {Tag.嗜甜如命,new List<int>(){0,0,0,-2,0,0}},
        {Tag.营养不良,new List<int>(){0,0,0,-2,0,0}},
        {Tag.糖尿病,new List<int>(){0,0,0,-5,0,0}},
        {Tag.夜不能寐,new List<int>(){0,0,0,-3,-3,2}},
        {Tag.干饭人,new List<int>(){-1,-1,-1,-1,-1,-1}},
        {Tag.双目失明,new List<int>(){0,0,0,-2,0,-3}},
        {Tag.独臂,new List<int>(){0,0,0,-1,-2,-2}},
        {Tag.痴呆,new List<int>(){-2,-2,-2,1,0,0}},
        {Tag.身怀六甲,new List<int>(){0,0,0,-1,-1,-1}},
        {Tag.小儿麻痹,new List<int>(){0,0,-1,-2,-1,-1}},
        {Tag.目不识丁,new List<int>(){-2,-2,-1,0,0,0}}

    };
    public static Dictionary<Rarerity, List<Tag>> GivenableTagRareDict = new Dictionary<Rarerity, List<Tag>>()
        {
        {Rarerity.B,new List<Tag>()
        {
        Tag.厄运缠身,
        Tag.腿脚不便,
        Tag.年老体衰,
        Tag.身世悲苦,
        Tag.精神病,
        Tag.近视,
        Tag.嗜甜如命,
        Tag.干饭人,
        Tag.双目失明,
        Tag.独臂,
        Tag.痴呆,
        Tag.小儿麻痹,
        Tag.目不识丁
    }},

        {Rarerity.R,new List<Tag>()
        {
        Tag.书痴,
        Tag.略有才名,
        Tag.小有谋略,
        Tag.武痴,
        Tag.身形矫健,
        Tag.老罴当道,
        Tag.离经叛道,
        Tag.外乡人,
        Tag.疯子,
        Tag.棋道,
        Tag.郎中,
        Tag.货郎
    }},
        {Rarerity.N,new List<Tag>()
       {
        Tag.有勇无谋,
        Tag.自是三公,
        Tag.敝帚自珍,
        Tag.巨人症,
        Tag.侏儒症,
        Tag.儒生,
        Tag.道士,
        Tag.僧人,
        Tag.冷血无情,
        Tag.近视,
        Tag.营养不良,
        Tag.膝盖僵硬,
        Tag.多动症,
        Tag.平平无奇,
        Tag.习武之人,
        Tag.弓,
        Tag.刀,
        Tag.枪,
        Tag.剑,
        Tag.戟,
        Tag.身世悲苦,
        Tag.贪污狼藉,
        Tag.六根不净,
        Tag.吸血鬼,
        Tag.狼人
    }},
        {Rarerity.SR,new List<Tag>()
       {
        Tag.才华横溢,
        Tag.工于心计,
        Tag.力拔山兮,
        Tag.广厦之荫,
        Tag.智勇双全,
    }},
        {Rarerity.SSR,new List<Tag>()
       {
        Tag.状元,
        Tag.诗仙,
        Tag.卧龙,
        Tag.武圣,
        Tag.无影,
        Tag.磐石
    }},
        {Rarerity.UR,new List<Tag>()
       {}}

};
    public static Dictionary<Rarerity, List<Tag>> MergeableTagRareDict = new Dictionary<Rarerity, List<Tag>> {
        {Rarerity.B,new List<Tag>()
        {
        Tag.糖尿病
    }},

        {Rarerity.R,new List<Tag>()
        {
        Tag.文正,
        Tag.武忠,
        Tag.法外狂徒,
        Tag.欢喜佛,
        Tag.恶魔人,
        Tag.老戏骨,
        Tag.牧民

    }},
        {Rarerity.N,new List<Tag>()
       {
           }},
        {Rarerity.SR,new List<Tag>()
       {
        Tag.文,
        Tag.武,
        Tag.天生神力,
        Tag.阳明学派,
        Tag.吸星大法,
        Tag.巫妖领主,
        Tag.龙骑士,
        Tag.外交官,
        Tag.老当益壮,
        Tag.炼金术师,
        Tag.近战精通,
        Tag.古神转世,
        Tag.理财大师,
        Tag.戏精,
        Tag.御马监,
        Tag.驯兽大师,
        Tag.朝奉
    }},
        {Rarerity.SSR,new List<Tag>()
       {
        Tag.黯然销魂掌,
        Tag.围棋十段,
        Tag.八斗之才,
        Tag.诸武精通,
        Tag.纸上谈兵,
        Tag.徒有虚名,
        Tag.投机取巧,
        Tag.混世魔王,
        Tag.心狠手辣,
        Tag.墨守成规,
        Tag.巧夺天工,
        Tag.悬壶济世,
        Tag.墨者

    }},
        {Rarerity.UR,new List<Tag>()
       {
        Tag.大人时代变了,
        Tag.弈星下凡,
        Tag.钜子,
        Tag.文武双全
}}

};
    public static Dictionary<List<Tag>, Tag> MergeTagDict = new Dictionary<List<Tag>, Tag>
    {
        {new List<Tag>(){Tag.文贞,Tag.文贞},Tag.文正},
        {new List<Tag>(){Tag.武勇,Tag.武勇},Tag.武忠},
        {new List<Tag>(){Tag.文正,Tag.文正},Tag.文},
        {new List<Tag>(){Tag.武忠,Tag.武忠},Tag.武},
        {new List<Tag>(){Tag.武忠,Tag.武忠},Tag.武},
        {new List<Tag>(){Tag.围棋十段,Tag.纵横家},Tag.弈星下凡},
        {new List<Tag>(){Tag.独臂,Tag.雕,Tag.平平无奇},Tag.黯然销魂掌},
        {new List<Tag>(){Tag.书通二酉,Tag.才华横溢,Tag.工于心计},Tag.八斗之才},
        {new List<Tag>(){Tag.刀,Tag.枪,Tag.剑,Tag.戟,Tag.弓},Tag.诸武精通},
        {new List<Tag>(){Tag.文,Tag.武},Tag.文武双全},
        {new List<Tag>(){Tag.工于心计,Tag.书痴,Tag.自是三公},Tag.纸上谈兵},
        {new List<Tag>(){Tag.才华横溢,Tag.略有才名,Tag.绣花枕头},Tag.徒有虚名},
        {new List<Tag>(){Tag.工于心计,Tag.小有谋略,Tag.花言巧语}, Tag.投机取巧},                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               {new List<Tag>(){Tag.力拔山兮,Tag.武痴,Tag.法外狂徒},Tag.混世魔王},
        {new List<Tag>(){Tag.冷血无情,Tag.出没无常},Tag.心狠手辣},
        {new List<Tag>(){Tag.老罴当道,Tag.广厦之荫,Tag.火炮},Tag.墨守成规},
        {new List<Tag>(){Tag.略有才名,Tag.儒生},Tag.才华横溢},
        {new List<Tag>(){Tag.经济学,Tag.棋道},Tag.工于心计},
        {new List<Tag>(){Tag.武痴,Tag.巨人症},Tag.力拔山兮},
        {new List<Tag>(){Tag.老罴当道,Tag.火炮},Tag.广厦之荫},
        {new List<Tag>(){Tag.小有谋略,Tag.武痴},Tag.智勇双全},
        {new List<Tag>(){Tag.巨人症,Tag.侏儒症},Tag.天生神力},
        {new List<Tag>(){Tag.儒生,Tag.道士,Tag.僧人},Tag.阳明学派},
        {new List<Tag>(){Tag.蛤蟆功,Tag.年老体衰},Tag.吸星大法},
        {new List<Tag>(){Tag.冰霜宝剑,Tag.不孝子},Tag.巫妖领主},
        {new List<Tag>(){Tag.火炮,Tag.飞毛腿},Tag.龙骑士},
        {new List<Tag>(){Tag.东洋语,Tag.西洋语},Tag.外交官},
        {new List<Tag>(){Tag.习武之人,Tag.年老体衰},Tag.老当益壮},
        {new List<Tag>(){Tag.丹童,Tag.毒师,Tag.离经叛道},Tag.炼金术师},
        {new List<Tag>(){Tag.弓,Tag.剑},Tag.近战精通},
        {new List<Tag>(){Tag.膝盖僵硬,Tag.外乡人,Tag.疯子},Tag.古神转世},
        {new List<Tag>(){Tag.经济学,Tag.心算},Tag.理财大师},
        {new List<Tag>(){Tag.演员,Tag.精神病},Tag.戏精},
        {new List<Tag>(){Tag.经济学,Tag.棋道},Tag.工于心计},
        {new List<Tag>(){Tag.御马司,Tag.马倌},Tag.御马监},
        {new List<Tag>(){Tag.牧民,Tag.驯兽术},Tag.驯兽大师},
        {new List<Tag>(){Tag.演员,Tag.年老体衰},Tag.老戏骨},
        {new List<Tag>(){Tag.马倌,Tag.驯兽术},Tag.牧民},
        {new List<Tag>(){Tag.营养不良,Tag.嗜甜如命},Tag.糖尿病},
        {new List<Tag>(){Tag.墨者,Tag.兼爱},Tag.钜子},
        {new List<Tag>(){Tag.大锤,Tag.小锤},Tag.巧夺天工},
        {new List<Tag>(){Tag.医术,Tag.郎中,Tag.本草纲目,Tag.黄帝内经},Tag.悬壶济世},
        {new List<Tag>(){Tag.偃师,Tag.非攻},Tag.墨者}

    };
    public static Dictionary<Rarerity, List<Tag>> ItemgiveTagRareDict = new Dictionary<Rarerity, List<Tag>>()
    {
        {Rarerity.B,new List<Tag>()
        {
            Tag.不孝子,
            Tag.醉酒,
            Tag.夜不能寐,
            Tag.身怀六甲
    }},

        {Rarerity.R,new List<Tag>()
        {
            Tag.蛤蟆功,
            Tag.通晓天文,
            Tag.冰霜宝剑,
            Tag.飞毛腿,
            Tag.火炮,
            Tag.东洋语,
            Tag.能歌善舞,
            Tag.西洋语,
            Tag.毒师,
            Tag.心算,
            Tag.经济学,
            Tag.小锤,
            Tag.驯兽术,
            Tag.御马司,
            Tag.兼爱,
            Tag.非攻

    }},
        {Rarerity.N,new List<Tag>()
       {
            Tag.文贞,
            Tag.武勇,
            Tag.花言巧语,
            Tag.绣花枕头,
            Tag.梧鼠五技,
            Tag.不孕不育,
            Tag.讼师,
            Tag.阉人,
            Tag.雕,
            Tag.丹童,
            Tag.演员,
            Tag.医术,
            Tag.马倌
           }},
        {Rarerity.SR,new List<Tag>()
       {
            Tag.书通二酉,
            Tag.偃师,
            Tag.奇门遁甲,
            Tag.纵横家,
            Tag.大锤,
            Tag.黄帝内经,
            Tag.本草纲目
    }},
        {Rarerity.SSR,new List<Tag>()
       {

    }},
        {Rarerity.UR,new List<Tag>()
       {
}}
    };
    public static Dictionary<ItemName, Tag> ItemToTag = new Dictionary<ItemName, Tag>
    {
        {ItemName.山海经,Tag.书通二酉},
        {ItemName.机关残卷,Tag.偃师},
        {ItemName.阴阳八卦盘,Tag.奇门遁甲},
        {ItemName.鬼谷子,Tag.纵横家},
        {ItemName.欧冶子的大锤,Tag.大锤},
        {ItemName.黄帝内经,Tag.黄帝内经},
        {ItemName.本草纲目,Tag.本草纲目},
        {ItemName.蛤蟆功秘籍,Tag.蛤蟆功},
        {ItemName.浑天仪,Tag.通晓天文},
        {ItemName.冰霜宝剑,Tag.冰霜宝剑},
        {ItemName.火炮,Tag.火炮},
        {ItemName.东洋词典,Tag.东洋语},
        {ItemName.西洋词典,Tag.西洋语},
        {ItemName.羽衣,Tag.能歌善舞},
        {ItemName.墨子非攻,Tag.非攻},
        {ItemName.墨子兼爱,Tag.兼爱},
        {ItemName.御马官印,Tag.御马司},
        {ItemName.毒经,Tag.毒师},
        {ItemName.唯物论,Tag.离经叛道},
        {ItemName.毒奶瓶,Tag.厄运缠身},
        {ItemName.棋诀,Tag.棋道},
        {ItemName.货殖列传,Tag.经济学},
        {ItemName.欧冶子的小锤,Tag.小锤},
        {ItemName.伤寒杂病论,Tag.郎中},
        {ItemName.文官状,Tag.文贞},
        {ItemName.武官状,Tag.武勇},
        {ItemName.吵闹的鹦鹉,Tag.花言巧语},
        {ItemName.官宸书,Tag.绣花枕头},
        {ItemName.杂技,Tag.梧鼠五技},
        {ItemName.奉子丹,Tag.身怀六甲},
        {ItemName.麝香,Tag.不孕不育},
        {ItemName.洗冤录,Tag.讼师},
        {ItemName.咖啡,Tag.夜不能寐},
        {ItemName.剪刀,Tag.阉人},
        {ItemName.孝经暂,Tag.不孝子},
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
        {ItemName.汤头歌诀,Tag.医术}
    };
    public static Dictionary<Tag, GameObject> TagPrefabDict = new Dictionary<Tag, GameObject> { };






}
