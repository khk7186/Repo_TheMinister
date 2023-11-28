using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeChapterOnEnable : MonoBehaviour
{
    public int chapter = 0;
    public void OnEnable()
    {
        ChapterCounter.Instance.Chapter = chapter;
    }
}
