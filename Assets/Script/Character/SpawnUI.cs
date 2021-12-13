using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUI : MonoBehaviour
{
    public Transform ThingToSpawn;
    public Transform CurrentTarget;

    public void Spawn()
    {
        CurrentTarget = Instantiate(ThingToSpawn, GameObject.FindGameObjectWithTag("MainUICanvas").transform);
    }

    public void SpawnHere()
    {
        CurrentTarget = Instantiate(ThingToSpawn, transform);
    }
}
