using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScene : MonoBehaviour
{
    private void Awake()
    {
        FindObjectOfType<BattleSystem>().StateAction();
    }
}
