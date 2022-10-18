using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabOnEnable : MonoBehaviour
{
    public List<GameObject> gameObjectsToSpawn = new List<GameObject>();
    public Vector3 spawnPosition = Vector3.zero;

    public bool spawnOnEnable = false;
    public void spawn()
    {
        foreach (GameObject go in gameObjectsToSpawn)
        {
            Instantiate(go, spawnPosition, Quaternion.identity).gameObject.SetActive(true);
        }
    }
    public void OnEnable()
    {
        if (spawnOnEnable)
        {
            spawn();
        }
    }
}
