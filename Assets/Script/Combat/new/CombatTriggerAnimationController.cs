using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CombatTriggerAnimationController : MonoBehaviour
{
    public Animator combatTrigger;
    public bool Showing = false;
    public bool stop = false;
    public List<CombatCharacterUnit> ShowPlayerUnits
    {
        get
        {
            while (playerUnits == null || playerUnits.Count == 0)
            {
                playerUnits = FindObjectsOfType<CombatCharacterUnit>()
                    .Where(x => x.IsFriend).ToList();
            }
            return playerUnits.Where(x => x.character.health > 0).ToList();
        }
    }
    private bool AllFriendlyUnitSet
    {
        get
        {
            if (ShowPlayerUnits == null || ShowPlayerUnits.Count == 0) return false;
            foreach (CombatCharacterUnit unit in ShowPlayerUnits)
            {
                if (unit.gameObject.activeSelf == false)
                {
                    playerUnits.Remove(unit);
                    continue;
                }
                if (unit.currentAction == CombatAction.NoSelect) return false;
            }
            return true;
        }
    }
    [SerializeField]
    private List<CombatCharacterUnit> playerUnits = null;
    private void Update()
    {
        if (stop) return;
        if (!Showing)
        {
            if (AllFriendlyUnitSet)
            {
                Show();
            }
        }
        else if (Showing)
        {
            var allShowing = AllFriendlyUnitSet;
            if (!allShowing) Hide();
        }
    }
    public void Stop()
    {
        stop = true;
    }
    public void Hide()
    {
        Showing = false;
        combatTrigger.Play("Hide");
    }
    public void Show()
    {
        Showing = true;
        combatTrigger.Play("Show");
    }
}
