using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObjectOnDestroy : MonoBehaviour
{
    public List<GameObject> gameObjects;
    private void OnDestroy()
    {
        foreach (var item in gameObjects)
        {
            item.SetActive(true);
        }
    }
}
