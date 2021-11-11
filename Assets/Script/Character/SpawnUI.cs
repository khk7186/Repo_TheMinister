using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUI : MonoBehaviour
{
    public Transform ThingToSpawn;

    public void Spawn()
    {
        Instantiate(ThingToSpawn, GameObject.FindGameObjectWithTag("MainUICanvas").transform);
    }
}
