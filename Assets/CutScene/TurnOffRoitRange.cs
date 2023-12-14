using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffRoitRange : MonoBehaviour
{
    public List<string> roitRangeNames = new List<string>();

    public void TurnOff()
    {
        foreach (var item in roitRangeNames)
        {
            RoitManager.Instance.spawnRanges.Find(x => x.name == item)?.gameObject.SetActive(false);
        }
    }
    public void TurnOn()
    {
        foreach (var item in roitRangeNames)
        {
            RoitManager.Instance.spawnRanges.Find(x => x.name == item)?.gameObject.SetActive(true);
        }
    }
}
