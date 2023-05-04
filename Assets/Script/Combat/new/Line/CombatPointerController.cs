using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatPointerController : MonoBehaviour
{
    public Image line;
    public Image top;
    public float lengthDifference = -40f;

    public void ChangeLength(float length)
    {
        var lineRect = line.rectTransform;
        var height = lineRect.sizeDelta.y;
        lineRect.sizeDelta = new Vector2(length + lengthDifference, height);
    }
    public void PointTo(Vector2 target)
    {
        
    }
}
