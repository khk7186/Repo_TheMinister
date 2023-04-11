using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AssetDatabase", menuName = "ScriptableObjects/SOAssetDB", order = 1)]
[Serializable]
public class SOAssetDB : ScriptableObject
{
    public GameObject CombatEnv1Day;
    public GameObject CombatEnv1Evening;
    public GameObject CombatEnv1Night;
    public GameObject CombatEnv2Day;
    public GameObject CombatEnv2Evening;
    public GameObject CombatEnv2Night;
    public GameObject CombatEnv3Day;
    public GameObject CombatEnv3Evening;
    public GameObject CombatEnv3Night;
    public GameObject CombatEnv4Day;
    public GameObject CombatEnv4Evening;
    public GameObject CombatEnv4Night;

    public GameObject LoadCombatEnv(char area = 'A', TimeInDay time = TimeInDay.Morning)
    {
        switch (area)
        {
            case 'A':
                switch (time)
                {
                    case TimeInDay.Noon:
                        return CombatEnv1Day;
                    case TimeInDay.Morning:
                        return CombatEnv1Evening;
                    case TimeInDay.Evening:
                        return CombatEnv1Night;
                }
                break;
            case 'B':
                switch (time)
                {
                    case TimeInDay.Noon:
                        return CombatEnv2Day;
                    case TimeInDay.Morning:
                        return CombatEnv2Evening;
                    case TimeInDay.Evening:
                        return CombatEnv2Night;
                }
                break;
            case 'C':
                switch (time)
                {
                    case TimeInDay.Noon:
                        return CombatEnv3Day;
                    case TimeInDay.Morning:
                        return CombatEnv3Evening;
                    case TimeInDay.Evening:
                        return CombatEnv3Night;
                }
                break;
            case 'D':
                switch (time)
                {
                    case TimeInDay.Noon:
                        return CombatEnv4Day;
                    case TimeInDay.Morning:
                        return CombatEnv4Evening;
                    case TimeInDay.Evening:
                        return CombatEnv4Night;
                }
                break;
        }
        return null;
    }
}
