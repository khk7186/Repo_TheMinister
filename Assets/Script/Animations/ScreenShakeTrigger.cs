using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeTrigger : MonoBehaviour
{
    public string shakeType = string.Empty;
    public bool isShakeOnStart = false;

    public static void TryScreenShake(string shakeType)
    {
        FindObjectOfType<CinemachineScreenShake>()?.TriggerShake(shakeType);
    }
    public void Shake()
    {
        if (isShakeOnStart)
        {
            FindObjectOfType<CinemachineScreenShake>().TriggerShake(shakeType);
        }
    }
}
