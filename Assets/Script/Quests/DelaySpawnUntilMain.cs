using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DelaySpawnUntilMain : MonoBehaviour
{
    public List<GameObject> spawnList;
    public Func<bool> IsMainScene = () => SceneManager.GetActiveScene().buildIndex == 1;

    public IEnumerator Start()
    {
        yield return new WaitUntil(IsMainScene);
        yield return new WaitForFixedUpdate();
        foreach (var item in spawnList)
        {
            Instantiate(item);
        }
        yield return null;
    }
}
