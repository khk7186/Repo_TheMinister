using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseRent : MonoBehaviour
{
    private enum HorseType
    {
        N = 1,
        R = 2,
        SR = 3,
        SSR = 4,
        UR = 5
    }

    private List<int> rates = new List<int>()
    {
        50,
        40,
        10,
        1,
        0
    };

    private HorseType RandomHorse()
    {
        int MaxValue = rates[0] + rates[1] + rates[2] + rates[3] + rates[4];
        int DrawValue = Random.Range(0, MaxValue);
        if (DrawValue < rates[0])
        {
            return HorseType.N;
        }
        else if (DrawValue < (rates[0]+ rates[1]))
        {
            return HorseType.R;
        }
        else if (DrawValue < (rates[0] + rates[1]+rates[2]))
        {
            return HorseType.SR;
        }
        else if (DrawValue < (rates[0] + rates[1] + rates[2]+rates[3]))
        {
            return HorseType.SSR;
        }
        else
        {
            return HorseType.UR;
        }
    }


    
}
