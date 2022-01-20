using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroySceneChange : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
