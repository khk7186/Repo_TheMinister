using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnUI : MonoBehaviour
{
    public Transform ThingToSpawn;
    public Transform CurrentTarget;

    public void Spawn()
    {
        CurrentTarget = Instantiate(ThingToSpawn, GameObject.FindGameObjectWithTag("MainUICanvas").transform);
    }
    public Transform SpawnWithReturn()
    {
        CurrentTarget = Instantiate(ThingToSpawn, GameObject.FindGameObjectWithTag("MainUICanvas").transform);
        return CurrentTarget;
    }

    public void SpawnHere()
    {
        CurrentTarget = Instantiate(ThingToSpawn, transform);
    }

    public void ChangePosition(Vector2 targetPos)
    {
        CurrentTarget.position = targetPos;
    }
}
