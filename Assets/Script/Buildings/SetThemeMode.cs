using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetThemeMode : MonoBehaviour
{
    public bool SetOnEnable = false;
    public bool ThemeModeOn = false;
    public void Set()
    {
        if (ChapterCounter.Instance.Chapter != 3)
        {
            InGameCharacterStorage.Instance?.ThemeMode(ThemeModeOn);
        }
        QuestAIManager.Instance?.ThemeMode(ThemeModeOn);
    }
    private void OnEnable()
    {
        if (SetOnEnable)
            Set();
    }
    public void OnDestroy()
    {
        if (ChapterCounter.Instance.Chapter != 3)
        {
            InGameCharacterStorage.Instance?.ThemeMode(false);
        }
        QuestAIManager.Instance?.ThemeMode(false);
    }
}
