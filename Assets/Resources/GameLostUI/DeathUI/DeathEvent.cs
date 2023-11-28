 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEvent : MonoBehaviour
{
    public static void TriggerDeath()
    {
        var origin = FindObjectOfType<PressureManager>(true).gameDeathUI;
        Instantiate(origin);
    }
}
