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




    };
    public static Dictionary<string, string> AppointSuccessQuestMessages = new Dictionary<string, string>
    {
        {"S-01-偷吃贡品-a", "发现偷吃贡品的窃贼。" },
        {"S-01-医闹-a", "罗夫人的孩子吃下药后稍有好转。" },
        {"S-01-抓贼-a", "最终未能找到贼人。" },
        {"S-01-施粥-a", "孙小姐的施粥圆满成功。" },
        {"S-01-爱学习的歪果仁-a", "弥赛亚对此次的交流很满意。" },
        {"S-01-解决纠纷-a","混混供出了幕后主使。" },
        {"S-01-采花-a" ,"阿花拿到花后十分高兴。"}
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
