using PixelCrushers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterCounter : MonoBehaviour
{
    public int Chapter
    {
        get
        {
            return count;
        }
        set
        {
            Chapter = value;
            RegularQuestEventHandler.ChapterShiftMessage(value);
        }
    }
    public int count = 0;

    public static ChapterCounter Instance;
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
