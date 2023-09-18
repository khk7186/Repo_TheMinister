using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLostEvent : MonoBehaviour
{
    public static void TriggerGameLost()
    {
        var origin = FindObjectOfType<PressureManager>(true).gameLostUI;
        Instantiate(origin);
    }
}
