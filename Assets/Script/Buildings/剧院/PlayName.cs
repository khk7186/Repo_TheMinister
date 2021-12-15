using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayName
{
    大王别姬吧,
    唐僧大战白骨精,
    宋江打虎,
    十面埋伏,
    
}

public static class PlayList
{
    public static Dictionary<PlayName, ArrayList> PlayListDict
        = new Dictionary<PlayName, ArrayList>()
    {
            {
                PlayName.大王别姬吧,
                new ArrayList()
                {
                    "大王！别姬吧！",
                    "大王！不要！那里不行！那里是拉屎的地方！不要舔马桶啊！",
                    new List<Tag>()
                    {
                        Tag.习武之人,
                        Tag.半身不遂,
                        Tag.头疼,
                        Tag.戏精,
                        Tag.欢喜佛,
                        Tag.略有才名,
                        Tag.醉生梦死,
                        Tag.醉酒,
                        Tag.鹰之力
                    }
                }
            } ,
            {
                PlayName.唐僧大战白骨精,
                new ArrayList()
                {
                    "唐僧大战白骨精！",
                    "只见那唐僧用金箍棒哼哼哈嘿，三下五除二得制服了白骨精。",
                    new List<Tag>()
                    {
                        Tag.驯兽大师,
                        Tag.黄帝内经,
                        Tag.身形矫健,
                        Tag.调皮鬼,
                        Tag.象虎之力,
                        Tag.营养不良,
                        Tag.百毒不侵,
                        Tag.略有才名,
                        Tag.鹰之力
                    }
                }
            },
            {
                PlayName.宋江打虎,
                new ArrayList()
                {
                    "宋江打虎",
                    "宋江呼保义上梁山时，路遇猛虎，指顾从容，只见他从怀中取出一壶酒喝了一大口后直奔虎口，三拳两脚就把猛虎制服。"
                }
            },
            {
                PlayName.十面埋伏,
                new ArrayList()
                {
                    "十面埋伏",
                    "楚汉相争，汉王刘邦携数十万大军把项羽团团困住，只见胜利在望一只大雕却突然从空中俯冲而下，那项羽竟然抓住了大雕脱身而去，大笑道：“没想到吧！这才是我的逃跑路线！”"

                }

            },


    };
}