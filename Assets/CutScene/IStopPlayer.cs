using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStopPlayer
{
    int CurrentBlock { get; }
    GameObject gameObject { get; }
}
