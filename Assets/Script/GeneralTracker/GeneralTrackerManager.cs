using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralTrackerManager : MonoBehaviour
{
    public static GeneralTrackerManager Instance;
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
