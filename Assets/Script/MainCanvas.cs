using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvas
{
    public static Transform FindMainCanvas()
    {
        var canvas = GameObject.FindGameObjectWithTag("MainUICanvas");
        return canvas == null ? canvas.transform : null;
    }


}
