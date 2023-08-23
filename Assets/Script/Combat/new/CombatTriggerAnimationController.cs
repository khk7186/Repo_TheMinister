using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CombatTriggerAnimationController : MonoBehaviour
{
    public Animator combatTrigger;
    public bool Showing = false;
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
    private Func<bool> AllFriendlyUnitSet
    {
        get
        {
            return () =>
            {
                if (ShowPlayerUnits == null || ShowPlayerUnits.Count == 0) return false;
                foreach (CombatCharacterUnit unit in ShowPlayerUnits)
                {
                    if (unit.currentAction == Action.NoSelect) return false;
                }
                return true;
            };
        }
    }
    [SerializeField]
    private List<CombatCharacterUnit> playerUnits = null;
    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitUntil(AllFriendlyUnitSet);
            Show();
        }
    }
    private void Update()
    {
        if (Showing)
        {
            var allShowing = AllFriendlyUnitSet.Invoke();
            if (!allShowing) Hide();
        }
    }
    public void Hide()
    {
        Showing = false;
    }
    public void Show()
    {
        Showing = true;
    }
}
