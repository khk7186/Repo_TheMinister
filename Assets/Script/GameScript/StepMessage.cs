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

    public static string AssassinStepMessage()
    {
        return AssassinStepMessages[Random.Range(0, AssassinStepMessages.Length - 1)];
    }
}
