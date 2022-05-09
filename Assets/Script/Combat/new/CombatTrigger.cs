using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTrigger : MonoBehaviour
{
    private Combat combat = null;
    public bool inCombat => combat != null;
    public void NewCombat()
    {
        combat = Combat.NewCombat();
        CombatInteractableUnit.SetActiveAllLine(false);
    }
}
