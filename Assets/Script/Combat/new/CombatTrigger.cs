using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTrigger : MonoBehaviour
{
    private Combat combat = null;
    public bool inCombat => combat != null;
    private void Awake()
    {
    }
    public void NewCombat()
    {
        combat = Combat.NewCombat();
        CombatInteractableUnit.SetActiveAllLine(false);
    }

    public void Update()
    {

    }

}
