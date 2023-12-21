using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetThemeModeForCharacterStorage : MonoBehaviour
{
    public bool SetOnEnable = false;
    public bool ThemeModeOn = false;
    public void Set()
    {
        InGameCharacterStorage.Instance?.ThemeMode(ThemeModeOn);
    }
    private void OnEnable()
    {
        if (SetOnEnable)
            Set();
    }
    public void OnDestroy()
    {
        InGameCharacterStorage.Instance?.ThemeMode(false);
    }
}
