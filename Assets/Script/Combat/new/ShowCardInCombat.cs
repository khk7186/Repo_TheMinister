using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCardInCombat : MonoBehaviour
{
    CombatSceneController csc;
    CombatCharacterUnit thisUnit;
    private void Awake()
    {
        csc = FindObjectOfType<CombatSceneController>();
        thisUnit = GetComponent<CombatCharacterUnit>();
    }
    public void OnMouseEnter()
    {
        // || Input.GetMouseButtonDown(1)

        bool show = !csc.OnAction
            || csc.CurrentOnActionCCU.currentAction == Action.Defence && thisUnit.IsFriend
            || csc.CurrentOnActionCCU.currentAction != Action.Defence && !thisUnit.IsFriend;
        if (show)
        {
            CombatSceneController.ShowCard(thisUnit);
        }
    }
}
