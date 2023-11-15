using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnDestroy : MonoBehaviour
{
    public GameObject GameObject;
    public void OnDestroy()
    {
        Instantiate(GameObject);
    }
}
