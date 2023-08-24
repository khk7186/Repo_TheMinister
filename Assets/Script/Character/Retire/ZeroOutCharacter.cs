using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroOutCharacter : MonoBehaviour
{
    public bool health = false;
    public bool loyalty = false;

    public Character character;
    public void ZeroOut()
    {
        if (health)
        {
            character.FightHealthModify(20);
        }
        if (loyalty)
        {
            character.loyalty = 0;
            character.TryRetire();
        }
    }
}
