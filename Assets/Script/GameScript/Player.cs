using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private Map map;
    public static Dictionary<Tag, List<int>> TagInfDict = new Dictionary<Tag, List<int>>() {
        {Tag.Null, new List<int>(){0,0,0,0, 0,0}},
        {Tag.书痴,new List<int>(){40,0,0,0,0,0}} ,
        {Tag.略有才名,new List<int>(){0,40,0,0,0,0}},
        {Tag.小有谋略,new List<int>(){0,0,40,0,0,0}},
        {Tag.武痴,new List<int>(){0,0,0,40,0,0}},
        {Tag.身形矫健,new List<int>(){0,0,0,0,40,0}},
        {Tag.老罴当道,new List<int>(){0,0,0,0,0,40}},
        {Tag.文贞,new List<int>(){15,15,15,0,0,0}},
        {Tag.武勇,new List<int>(){0,0,0,15,15,15}},
        {Tag.干饭人,new List<int>(){-20,-20,-20,-20,-20,-20}},
        {Tag.有勇无谋,new List<int>(){0,0,-20,18,0,0}},
        {Tag.花言巧语,new List<int>(){0,-20,18,0,0,0}},
        {Tag.绣花枕头,new List<int>(){-20,18,0,0,0,0}},
        {Tag.梧鼠五技,new List<int>(){-20,0,0,0,18,0}},
        {Tag.自是三公,new List<int>(){18,0,0,0,-20,0}},
        {Tag.敝帚自珍,new List<int>(){0,0,18,0,0,-20}},
        {Tag.双目失明,new List<int>(){-10,-10,-10,-10,-10,-10}},
        {Tag.独臂,new List<int>(){0,0,0,-12,-12,-12}},
        {Tag.痴呆,new List<int>(){-20,-20,-20,0,0,0}},
        {Tag.身怀六甲,new List<int>(){-5,-5,-5,-18,-18,-18}},
        {Tag.不孕不育,new List<int>(){0,0,0,0,0,0}},
        {Tag.巨人症,new List<int>(){0,0,0,22,0,0}},
        {Tag.侏儒症,new List<int>(){22,0,0,0,0,0}},
        {Tag.小儿麻痹,new List<int>(){0,0,0,-22,-22,-22}},
        {Tag.目不识丁,new List<int>(){-22,-22,-22,0,0,0}},
        {Tag.儒生,new List<int>(){0,25,0,0,0,0}},
        {Tag.道士,new List<int>(){0,0,25,0,0,0}},
        {Tag.僧人,new List<int>(){25,0,0,0,0,0}},
        {Tag.讼棍,new List<int>(){12,12,12,0,0,0}},
        {Tag.冷血无情,new List<int>(){0,0,0,12,12,12}},
        {Tag.蛤蟆功,new List<int>(){0,0,0,18,18,6}},
        {Tag.近视,new List<int>(){6,6,0,-3,0,0}},
        {Tag.嗜甜如命,new List<int>(){0,0,0,-5,0,0}},
        {Tag.营养不良,new List<int>(){0,0,0,0,0,0}},
        {Tag.夜不能寐,new List<int>(){0,0,0,0,0,0}},
        {Tag.阉人,new List<int>(){0,0,0,0,0,0}},
        {Tag.吸血鬼,new List<int>(){0,0,0,14,28,0}},
        {Tag.狼人,new List<int>(){0,0,0,28,14,0}},
        {Tag.膝盖僵硬,new List<int>(){0,0,0,0,0,0}},
        {Tag.通晓天文,new List<int>(){0,0,42,0,0,0}},
        {Tag.多动症,new List<int>(){0,0,0,21,0,0}},
        {Tag.不孝子,new List<int>(){0,-12,0,0,0,0}},
        {Tag.冰霜宝剑,new List<int>(){0,0,0,40,0,0}},
        {Tag.巫妖领主,new List<int>(){0,0,0,90,0,0}},
        {Tag.飞毛腿,new List<int>(){0,0,0,0,40,0}},
        {Tag.火炮,new List<int>(){0,0,0,40,0,0}},
        {Tag.龙骑士,new List<int>(){0,0,0,50,50,50}},
        {Tag.能歌善舞,new List<int>(){0,0,0,0,30,0}},
        {Tag.东洋语,new List<int>(){15,15,0,0,0,0}},
        {Tag.西洋语,new List<int>(){15,15,0,0,0,0}},
        {Tag.平平无奇,new List<int>(){1,1,1,1,1,1}},
        {Tag.雕,new List<int>(){0,0,0,0,10,0}},
        {Tag.腿脚不便,new List<int>(){0,0,0,-20,-20,-20}},
        {Tag.年老体衰,new List<int>(){0,0,0,-10,-10,-10}},
        {Tag.习武之人,new List<int>(){0,0,0,10,10,10}},
        {Tag.状元,new List<int>(){120,0,0,0,0,0}},
        {Tag.诗仙,new List<int>(){0,120,0,0,0,0}},
        {Tag.卧龙,new List<int>(){0,0,120,0,0,0}},
        {Tag.武圣,new List<int>(){0,0,0,120,0,0}},
        {Tag.无影,new List<int>(){0,0,0,0,120,0}},
        {Tag.磐石,new List<int>(){0,0,0,0,0,120}},
        {Tag.文,new List<int>(){40,40,40,0,0,0}},
        {Tag.武,new List<int>(){0,0,0,40,40,40}},
        {Tag.书通二酉,new List<int>(){80,0,0,0,0,0}},
        {Tag.才华横溢,new List<int>(){0,80,0,0,0,0}},
        {Tag.工于心计,new List<int>(){0,0,80,0,0,0}},
        {Tag.力拔山兮,new List<int>(){0,0,0,80,0,0}},
        {Tag.出没无常,new List<int>(){0,0,0,0,80,0}},
        {Tag.广厦之荫,new List<int>(){0,0,0,0,0,80}},
        {Tag.智勇双全,new List<int>(){0,-20,60,60,0,0}},
        {Tag.偃师,new List<int>(){60,0,0,-20,60,0}},
        {Tag.奇门遁甲,new List<int>(){0,60,0,0,-20,60}},
        {Tag.大人时代变了,new List<int>(){0,0,0,999,0,0}},
        {Tag.弈星下凡,new List<int>(){0,0,300,-2,-2,-2}},
        {Tag.八斗之才,new List<int>(){80,80,80,0,0,0}},
        {Tag.诸武精通,new List<int>(){0,0,0,80,80,80}},
        {Tag.文武双全,new List<int>(){50,50,50,50,50,50}},
        {Tag.纸上谈兵,new List<int>(){180,0,-40,0,0,0}},
        {Tag.徒有虚名,new List<int>(){-40,180,0,0,0,0}},
        {Tag.投机取巧,new List<int>(){0,-40,180,0,0,0}},
        {Tag.混世魔王,new List<int>(){0,0,0,180,0,-40}},
        {Tag.心狠手辣,new List<int>(){0,0,0,0,180,-40}},
        {Tag.天生神力,new List<int>(){0,0,0,48,0,0}},
        {Tag.阳明学派,new List<int>(){50,50,50,0,0,0}},
        {Tag.法外狂徒,new List<int>(){30,30,30,30,30,30}},
        {Tag.吸星大法,new List<int>(){0,0,0,43,37,0}},
        {Tag.糖尿病,new List<int>(){0,0,0,-30,0,0}},
        {Tag.欢喜佛,new List<int>(){40,0,0,0,0,0}},
        {Tag.恶魔人,new List<int>(){0,0,0,28,0,14}},
        {Tag.外交官,new List<int>(){50,50,0,0,0,0}},
        {Tag.黯然销魂掌,new List<int>(){0,0,0,100,100,100}},
        {Tag.围棋十段,new List<int>(){0,0,120,0,0,0}},
        {Tag.老当益壮,new List<int>(){0,0,0,32,32,32}},
        {Tag.文正,new List<int>(){30,30,30,0,0,0}},
        {Tag.武忠,new List<int>(){0,0,0,30,30,30}},
        {Tag.成道,new List<int>(){99,99,99,99,99,99}}
    };
    public static Dictionary<Raitity, List<Tag>> GivenableTagRareDict = new Dictionary<Raitity, List<Tag>>()
        {{ Raitity.SSR, new List<Tag>()
        {
            Tag.状元,
            Tag.诗仙,
            Tag.卧龙,
            Tag.武圣,
            Tag.无影,
            Tag.磐石
        } },
        { Raitity.R, new List<Tag>()
        {
            Tag.书痴,
            Tag.略有才名,
            Tag.小有谋略,
            Tag.武痴,
            Tag.身形矫健,
            Tag.老罴当道,
            Tag.蛤蟆功,
            Tag.吸血鬼,
            Tag.狼人,
            Tag.通晓天文,
            Tag.冰霜宝剑,
            Tag.飞毛腿,
            Tag.火炮,
            Tag.能歌善舞,
            Tag.东洋语,
            Tag.西洋语
        } },
        { Raitity.N, new List<Tag>() {
            Tag.文贞,
            Tag.武勇,
            Tag.干饭人,
            Tag.有勇无谋,
            Tag.花言巧语,
            Tag.绣花枕头,
            Tag.梧鼠五技,
            Tag.自是三公,
            Tag.敝帚自珍,
            Tag.双目失明,
            Tag.独臂,
            Tag.痴呆,
            Tag.身怀六甲,
            Tag.不孕不育,
            Tag.巨人症,
            Tag.侏儒症,
            Tag.小儿麻痹,
            Tag.目不识丁,
            Tag.儒生,
            Tag.道士,
            Tag.僧人,
            Tag.讼棍,
            Tag.冷血无情,
            Tag.近视,
            Tag.嗜甜如命,
            Tag.营养不良,
            Tag.夜不能寐,
            Tag.阉人,
            Tag.膝盖僵硬,
            Tag.多动症,
            Tag.不孝子,
            Tag.平平无奇,
            Tag.雕,
            Tag.腿脚不便,
            Tag.年老体衰,
            Tag.习武之人
        }},
        { Raitity.SR, new List<Tag>() {
            Tag.文,
            Tag.武,
            Tag.书通二酉,
            Tag.才华横溢,
            Tag.工于心计,
            Tag.力拔山兮,
            Tag.广厦之荫,
            Tag.智勇双全,
            Tag.偃师,
            Tag.奇门遁甲,
            Tag.天生神力,
            Tag.阳明学派,
            Tag.吸星大法,
            Tag.成道,
            Tag.巫妖领主,
            Tag.外交官,
            Tag.老当益壮
        } },
        { Raitity.UR, new List<Tag>(){
            Tag.大人时代变了,
            Tag.弈星下凡
        }}
};
    public static Dictionary<Raitity, List<Tag>> MergeableTagRareDict = new Dictionary<Raitity, List<Tag>> { };
    public static Dictionary<List<Tag>, Tag> MergeTagDict = new Dictionary<List<Tag>, Tag>
    {

    };
    public static Dictionary<Raitity, List<Tag>> ItemgiveTagRareDict = new Dictionary<Raitity, List<Tag>>()
    {

    };
    public static Dictionary<ItemName, Tag> ItemToTag = new Dictionary<ItemName, Tag>
    {
        { ItemName.Null, Tag.Null }
    };


    public static Dictionary<Tag, GameObject> TagPrefabDict = new Dictionary<Tag, GameObject> { };






}
