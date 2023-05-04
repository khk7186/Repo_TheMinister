using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEventManager : MonoBehaviour
{
    public static CameraEventManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
