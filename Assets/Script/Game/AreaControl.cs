using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaControl : MonoBehaviour, IAreaChangeHandler
{
    public static AreaControl instant;
    public char CurrentArea = 'A';
    public void OnAreaChange(char areaCode)
    {
        CurrentArea = areaCode;
    }
    private void OnEnable()
    {
        if (instant == null)
        {
            instant = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        if (instant == this)
        {
            instant = null;
        }
    }


}
