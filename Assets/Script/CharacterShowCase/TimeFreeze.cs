using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFreeze : MonoBehaviour
{
    [SerializeField]
    public bool freezeTime = false;
    public bool actionOnEnable = false;
    public float waitTime = 1f;

    public static TimeFreeze StartATimeFreeze(GameObject gameObject, float waitTime)
    {
        var target = gameObject.AddComponent<TimeFreeze>();
        target.waitTime = waitTime;
        return target;
    }

    private void OnEnable()
    {
        if (actionOnEnable)
        {
            StartCoroutine(FreezeTimeForSeconds(waitTime));
        }
    }
    public void FreezeTime(bool freezTime)
    {
        if (freezTime)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
    public IEnumerator FreezeTimeForSeconds(float seconds)
    {
        FreezeTime(true);
        yield return new WaitForSecondsRealtime(seconds);
        FreezeTime(false);
    }
}
