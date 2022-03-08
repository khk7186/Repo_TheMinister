using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBangMethod
{
    public static Dictionary<Tag, ArrayList> TagToMethodEffect =
        new Dictionary<Tag, ArrayList>()
        {
            { Tag.棋道, new ArrayList (){new BoxMethod(), 0} },
            { Tag.围棋十段, new ArrayList (){new BoxMethod(), 1} },
            { Tag.智勇双全, new ArrayList(){new DestroyMethod(),0 } },
            { Tag.工于心计, new ArrayList(){new DestroyMethod(),1 } },
            { Tag.卧龙, new ArrayList(){new DestroyMethod(),2 } },
            { Tag.纵横家, new ArrayList(){new DestroyMethod(),3 } },
            { Tag.小有谋略, new ArrayList(){new DestroyMethod(),4 } },
            { Tag.有勇无谋, new ArrayList(){new DestroyMethod(),5 } },
            { Tag.弈星下凡, new ArrayList(){new DestroyMethod(),100 } },
            { Tag.投机取巧, new ArrayList(){new DestroyMethod(),20 } },
            { Tag.窥得天机, new ArrayList(){new DestroyMethod(),10 } },
            { Tag.奇门遁甲, new ArrayList(){new DestroyMethod(),5 } },
        };
    public static GoBangMainLoop CurrentGame()
    {
        return UnityEngine.GameObject.FindObjectOfType<GoBangMainLoop>();
    }
    public virtual void Run(GoBangMainLoop.point local, int effect)
    {

    }
}
