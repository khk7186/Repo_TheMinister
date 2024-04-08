using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
