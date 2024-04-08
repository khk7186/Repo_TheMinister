using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class AchievementTrackingManager : MonoBehaviour
{
    public int currentIndex = 0;
    public int checkIndex = 50;
    public void FixedUpdate()
    {
        currentIndex++;
        if (currentIndex == checkIndex)
        {
            currentIndex = 0;
            //DO Stuff;
        }
    }
    public void UnlockAchievement(string achievementName)
    {
        if (SteamManager.Initialized)
        {
            SteamUserStats.SetAchievement(achievementName);
            SteamUserStats.StoreStats();
        }
    }
}
