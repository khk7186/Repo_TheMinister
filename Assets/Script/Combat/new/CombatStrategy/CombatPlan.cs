using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatPlan : MonoBehaviour
{
    public Character character;
    public List<CombatAction> actions = new List<CombatAction>();
    public int index = -1;

    public CombatAction NextAction()
    {
        index++;
        if (index >= actions.Count) index = 0;
        return actions[index];
    }
}
