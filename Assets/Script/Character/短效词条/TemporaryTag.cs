using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TemporaryTag
{
    public Tag tag = Tag.Null;
    public int timeLeft = 0;
    public TemporaryTag(Tag tag, int timeLeft)
    {
        this.tag = tag;
        this.timeLeft = timeLeft;
    }
}
