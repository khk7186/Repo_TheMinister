using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureManager : MonoBehaviour
{
    public static PressureManager Instance;
    public int pressure = 0;
    public int maxPressure = 100;
    public List<int> pressureAddPerDayBaseOnChapter = new List<int> { 0, 3, 5, 6 };
    public int chapter => ChapterCounter.Instance.Chapter;
    public int pressureAddPerDay => pressureAddPerDayBaseOnChapter[chapter];
    public GameLostUI gameLostUI = null;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            pressure = 0;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        PressureEventHandler.OnPressureChange();
    }
}
