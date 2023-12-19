using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public static class PressureEventHandler
{
    public static readonly int minPressure = 0;
    public static readonly int maxPressure = 100;
    private static PressureManager pressureManager => PressureManager.Instance;
    public static void OnPressureChange(int changeAmount = 0)
    {
        if (changeAmount != 0)
        {
            pressureManager.pressure = CalculatePressureChange(pressureManager.pressure, changeAmount);
        }
        GameObject.FindObjectOfType<PressureView>()?.SetPercentage(pressureManager.pressure);
    }
    public static void OnDayEndPressureChange()
    {
        OnPressureChange(pressureManager.pressureAddPerDay);
    }
    public static void OnAddPerDayChange(int index)
    {
        GameObject.FindObjectOfType<PressureView>()?.SetAddPerDay();
    }
    public static void SetPressureTo(int Amount = 0)
    {
        pressureManager.pressure = Amount;
        GameObject.FindObjectOfType<PressureView>()?.SetPercentage(pressureManager.pressure);
    }

    private static int CalculatePressureChange(int origin, int changeAmount)
    {
        int output = origin;
        output += changeAmount;
        if (output >= maxPressure)
        {
            GameLostEvent.TriggerGameLost();
            output = maxPressure;
        }
        else if (output < minPressure)
        {
            output = minPressure;
        }
        return output;
    }
}
