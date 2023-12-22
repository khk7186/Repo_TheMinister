using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnUI : MonoBehaviour
{
    public Transform ThingToSpawn;
    public Transform CurrentTarget;
    public Canvas specificCanvas;

    public void Spawn()
    {
        if (specificCanvas != null)
        {
            CurrentTarget = Instantiate(ThingToSpawn, specificCanvas.transform);
        }
        else
        {
            CurrentTarget = Instantiate(ThingToSpawn, MainCanvas.FindMainCanvas());
        }
    }
    public Transform SpawnWithReturn()
    {
        CurrentTarget = Instantiate(ThingToSpawn, MainCanvas.FindMainCanvas());
        return CurrentTarget;
    }

    public void SpawnHere()
    {
        CurrentTarget = Instantiate(ThingToSpawn, MainCanvas.FindMainCanvas());
    }

    public void ChangePosition(Vector2 targetPos)
    {
        CurrentTarget.position = targetPos;
    }
}
