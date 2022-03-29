using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTrigger : MonoBehaviour
{
    public void NewCombat()
    {
        Combat.NewCombat();
        CombatInteractableUnit.SetActiveAllLine(false);
    }
}
