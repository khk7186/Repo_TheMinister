using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CombatTutorManager : MonoBehaviour
{
    public static bool TutorialLevelIsOn = false;
    public static bool Pause = false;
    public int RountIndex = 0;
    public List<UnityEvent> EventByRound = new List<UnityEvent>();
    private void OnEnable()
    {
        TutorialLevelIsOn = true;
    }
    private void OnDisable()
    {
        TutorialLevelIsOn = false;
    }
    public void SetPause()
    {
        Pause = true;
    }
    public void SetResume()
    {
        Pause = false;
    }
    public void NextEvent()
    {
        SetPause();
    }
}
