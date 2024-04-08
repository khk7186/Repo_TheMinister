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
            if (HaveFiveCharacters())
                UnlockAchievement("FiveCharacters");
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
    //ACHIEVEMENTS_ID
    public bool HaveFiveCharacters()
    {
        var inv = GameObject.FindGameObjectWithTag("PlayerCharactersInventory");
        if (inv == null) return false;
        if (inv.transform.childCount >= 5)
            return true;
        return false;
    }
}
