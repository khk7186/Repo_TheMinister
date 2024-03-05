using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CombatTutorManager : MonoBehaviour
{
    public static bool TutorialLevelIsOn = false;
    public static bool Pause = false;
    public int RountIndex = 0;
    public List<UnityEvent> EventByRound = new List<UnityEvent>();
    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        TutorialLevelIsOn = true;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
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
        EventByRound[RountIndex].Invoke();
        RountIndex++;
        var units = FindObjectsOfType<CombatCharacterUnit>();
        foreach (var unit in units)
        {
            unit.target = null;
            if (unit.IsFriend)
            {
                Destroy(unit.GetComponent<CombatInteractableUnit>().line.gameObject);
            }
            unit.currentAction = CombatAction.NoSelect;
        }
        SetPause();
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 2)
        {
            NextEvent();
        }
    }
}
