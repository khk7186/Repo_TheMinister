using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum HorseRank
{
    N = 1,
    R = 2,
    SR = 3,
    SSR = 4,
    UR = 5
}
public class HorseRent : MonoBehaviour
{
    private List<int> rates = new List<int>()
    {
        50,
        40,
        10,
        1,
        0
    };
    public int numberOfSpawn = 5;

    private void Start()
    {
        var target = Resources.Load<HorseCardUI>("BuildingUI/HorseCard");
        for (int i = 0; i < numberOfSpawn; i++)
        {
            var current = Instantiate(target, transform);
            current.SetUp(RandomHorse());
        }
    }

    public HorseRank RandomHorse()
    {
        int MaxValue = rates[0] + rates[1] + rates[2] + rates[3] + rates[4];
        int DrawValue = Random.Range(0, MaxValue);
        if (DrawValue < rates[0])
        {
            return HorseRank.N;
        }
        else if (DrawValue < (rates[0]+ rates[1]))
        {
            return HorseRank.R;
        }
        else if (DrawValue < (rates[0] + rates[1]+rates[2]))
        {
            return HorseRank.SR;
        }
        else if (DrawValue < (rates[0] + rates[1] + rates[2]+rates[3]))
        {
            return HorseRank.SSR;
        }
        else
        {
            return HorseRank.UR;
        }
    }


    
}
