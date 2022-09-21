using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectsOnEnable : MonoBehaviour
{
    public List<GameObject> GameObjectsToDestroy;
    public bool DestroyOnEnable = false;
    private void OnEnable()
    {
        if (DestroyOnEnable)
        {
            DestroyMethod();
        }
    }
    public void DestroyMethod()
    {
        foreach (GameObject go in GameObjectsToDestroy)
        {
            Destroy(go);
        }
    }
}
