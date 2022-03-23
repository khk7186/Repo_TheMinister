using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatBattleSelectUI : MonoBehaviour
{
    public CombatCharacterUnit characterUnit;
    public void ActionChoose()
    {
        CombatSystem battleSystem = FindObjectOfType<CombatSystem>();
        if (battleSystem != null)
        {

        }
    }
    public void Attack()
    {
        CombatSystem battleSystem = FindObjectOfType<CombatSystem>();
        if (battleSystem != null)
        {

        }
        ActionChoose();
    }
    public void Defence()
    {
        CombatSystem battleSystem = FindObjectOfType<CombatSystem>();
        if (battleSystem != null)
        {

        }
        ActionChoose();
    }
    public void Assassinate()
    {
        CombatSystem battleSystem = FindObjectOfType<CombatSystem>();
        if (battleSystem != null)
        {

        }
        ActionChoose();
    }
}
