using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepMessage : MonoBehaviour
{

    public static string[] AssassinStepMessages = new string[]
    {
         "正在树上隐藏，观察目标。",
         "正在市场上混迹，熟悉周围的街道和巷弄。",
         "正在铁匠铺里锻造一把匕首。",
         "正在绘制刺杀计划的详细地图。",
         "正在悄悄靠近目标的住所。",
         "正在茶馆中假装聊天，搜集关于目标的闲话。",
         "正在屋檐下暗中观察目标的随从。",
         "正在夜晚探索城墙下的秘密通道。",
         "正在测试毒药的效果。",
         "正在夜间练习在屋顶间的跳跃。",
         "正在市集中假扮小贩，注意目标的活动。",
         "正在高塔上观测天象，判断最佳行动时机。",
         "正在换上夜行衣。",
         "正在制作假面具和其他伪装道具。",
         "正在观察目标的生活习惯和偏好。",
         "正在密切关注目标的最新动态和变化。",
         "正在进行冥想，以稳定心态和集中精神。"
    };

    public static string[] AssassinCompleteMessages = new string[]
    {
        "正在清理现场",
        "正在伪装成下人撤离现场",
        "躲在满载干草的马车中离开。",
        "正在用河水清洗掉衣物上的血迹。",
        "在林中掩埋已使用的刺杀工具。",
        "暂时隐匿在偏僻的庙宇内。"
    };

    public static string[] AssassinFailMessages = new string[]
    {
        "在一条死胡同被敌人围困，无路可逃。",
        "为了保密，吞下藏有毒药的假牙。",
        "在潜藏时身份被揭露。",
        "刺杀时发出响声被守卫发现。",
        "与清除守卫时引起了注意。"

    };
    public static string AssassinStepMessage()
    {
        return AssassinStepMessages[Random.Range(0, AssassinStepMessages.Length - 1)];
    }

    public static string AssassinCompleteStepMessage()
    {
        return AssassinCompleteMessages[Random.Range(0, AssassinCompleteMessages.Length - 1)];
    }

    public static string AssassinFailStepMessage()
    {
        return AssassinFailMessages[Random.Range(0, AssassinFailMessages.Length - 1)];
    }

    public static Dictionary<string, List<string>> AppointQuestMessages = new Dictionary<string, List<string>>
    {
        {"S-01-偷吃贡品-a", new List<string>()
        {
            "正在前往白云寺。",
            "正在布下诱饵。",
            "正在布下诱饵。"
        } },
        {"S-01-医闹-a", new List<string>()
        {
            "正在前往罗夫人家中。",
            "正在为罗夫人孩子把脉诊断。",
            "正在考虑药方。"
        } },
        {"S-01-抓贼-a", new List<string>()
        {
            "正在围追盗贼。",
            "正在搀扶黄东。"
        } },
        {"S-01-施粥-a", new List<string>()
        {
            "正在帮助孙大小姐分发白粥。",
            "正在赶走前来闹事的流民。",
            "正在帮忙收摊。"
        } },
        {"S-01-爱学习的歪果仁-a", new List<string>()
        {
            "正在交流写诗的心得。",
            "正在纠正弥赛亚的发音。",
            "正在教授弥赛亚大靖的礼仪。"
        } },
        {"S-01-解决纠纷-a", new List<string>()
        {
            "正在赶往王伟家中。",
            "正在抓捕围住王伟家的混混。",
            "正在与审问混混。"
        } },
        {"S-01-采花-a", new List<string>()
        {
            "正在前往城郊。",
            "正在挑选花朵。"
        } },
        {"M-01-01-f", new List<string>()
        {
            "正在前往案发现场。",
            "正在寻找蛛丝马迹。"
        } },
        {"M-01-02-f", new List<string>()
        {
            "正在观察铅粉。",
            "正在统计京城内铅粉的流通。",
            "正在盘查商家。",
            "正在与城卫交流。",
            "正在与百姓交流。",
            "正在前往拍卖行找寻线索。",
            "正在梳理线索。",
            "正在前往白云寺。",
        } },
        {"M-01-04-f", new List<string>()
        {
            "正在统计阉党人员。",
            "正在找寻突破口。",
            "正在观察阉党动向。",
            "正在记录个别人员的行动。",
            "正在准备夜行衣。",
            "正在前往酒馆。",
            "正在酒馆偷听。",
            "正在跟踪形迹可疑的阉党人员。",
            "丢失目标，暂停调查以免打草惊蛇。",
            "继续观察阉党动向。",
            "正在接触阉党人员。",
            "正在潜入阉党。",
            "正在与太监接头。",
            "正在完成阉党所需任务。",
            "正在前往白云寺运送不知名物资。",
        } },
        {"M-03-11-f", new List<string>()
        {
            "正在修书一封。",
            "正在前往驿站。",
            "静等信使送达。",
            "不知书信是否抵达西南。",
            "若无意外，应已送达。",
            "静候大将军回信。",
            "思索对当下形式的对策。",
            "不知苗邈身处何处。",
            "回信应该不日送达。",
            "正在报告大将军的回复。",
        } },
        {"M-03-05-f", new List<string>()
        {
            "正在思考计策。",
            "正在商讨",
            "正在确认计策的可行性。"
        } },
        {"M-03-06-f", new List<string>()
        {
            "正在润色铝怖的身平。",
            "正在与户部官员交流。",
            "正在散布铝怖的传记。",
            "正在控制不利的舆论。",
            "正在与戏院合作。"
        } },
        {"M-03-07-f", new List<string>()
        {
            "等待云梦大师造势。",
            "前往白云寺附近查看。",
            "铝怖神明转世的消息不胫而走。",
            "百姓询问后得到白云寺方丈的肯定。",
            "铝怖的传言愈演愈烈。",
            "朝廷内大多数已经相信铝怖必定可以成功劝降北平王。"
        } },
        {"M-05-04-f", new List<string>()
        {
            "正在打探苗邈的消息。",
            "正在与叛军搏斗。",
            "正在潜入叛军驻地。",
            "正在偷听叛军对话。",
            "正在逃离叛军追捕。",
        } },
        {"M-05-05-f", new List<string>()
        {
            "正在打探清竹的消息。",
            "正在保护百姓。",
            "正在前往清竹驻地。",
            "正在打晕叛军。",
            "正在审问叛军。",
            "正在记录叛军所言。"
        } },
        {"M-05-06-f", new List<string>()
        {
            "正在聚集武卫。",
            "正在保养武器。",
            "正在准备军粮。",
            "正在绘制地图。",
            "正在计划行动。",
            "正在装配护甲。",
            "正在前往城西。",
            "正在靠近叛军驻地。",
            "正在引导百姓避难。",
            "正在与叛军交战。",
            "仍在与叛军交战。",
            "叛军略显败势。",
            "叛军似乎收到消息徐徐退去。",
            "正在清理战利品。",
            "正在返回"
        } },
        {"M-05-07-f", new List<string>()
        {
            "正在完成清竹的指示。",
            "正在暗中救出百姓。",
            "正在私通清竹手下。",
            "正在准备计划。",
            "正在教唆清竹。",
            "正在收集军资。",
            "正在囤积武器。",
            "正在暗中散布谣言。",
            "正在引导清竹。",
            "正在笼络叛军。",
        } },





    };
    public static Dictionary<string, string> AppointSuccessQuestMessages = new Dictionary<string, string>
    {
        {"S-01-偷吃贡品-a", "发现偷吃贡品的窃贼。" },
        {"S-01-医闹-a", "罗夫人的孩子吃下药后稍有好转。" },
        {"S-01-抓贼-a", "最终未能找到贼人。" },
        {"S-01-施粥-a", "孙小姐的施粥圆满成功。" },
        {"S-01-爱学习的歪果仁-a", "弥赛亚对此次的交流很满意。" },
        {"S-01-解决纠纷-a","混混供出了幕后主使。" },
        {"S-01-采花-a" ,"阿花拿到花后十分高兴。"},
        { "M-01-01-f" ,"在现场发现不寻常之物。"},
        { "M-01-02-f" ,"经过调查，白云寺似乎存有大量铅粉。"},
        {"M-01-04-f" ,"阉党似乎在执行一些任务并且与白云寺密切相关。"},
        { "M-03-11-f","大将军已经动身回京，不知来不来得及阻止叛军入京。"},
        { "M-03-05-f","与谋士商谈似乎有三种计策。"},
        { "M-03-06-f","铝怖的“辉煌”事迹已经传遍大街小巷。"},
        {"M-03-07-f","铝怖前去北方劝降已是板上钉钉。" },
        {"M-05-04-f","从叛军驻地得知苗邈将不日被叛军处刑。" },
        {"M-05-05-f","从清竹手下得知，清竹与刘维同是北平王手下四大将，为人疯癫，行事残暴"},
        {"M-05-06-f","城西的叛军已然败退，但是首领似乎不在城西。"},
        {"M-05-07-f","你偷偷使用一些技巧成功策反清竹，清竹被北平王拥趸乱刀砍杀。"},
    };

    public static string AppointMessage(string QuestID, int Step)
    {
        string succMessage;
        List<string> stepMessages = new List<string>();
        var target = StepMessage.AppointQuestMessages;
        if (Step != 0)
        {
            if (target.ContainsKey(QuestID))
            {
                Step--;
                target.TryGetValue(QuestID, out stepMessages);
                var targetList = stepMessages;
                targetList.Reverse();
                return targetList[Step];
            }
            else
            {
                return null;

            }


        }
        else
        {
            var sucTarget = StepMessage.AppointSuccessQuestMessages;
            sucTarget.TryGetValue(QuestID, out succMessage);
            return succMessage;
        }
    }
}
