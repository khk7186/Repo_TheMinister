using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.QuestMachine;

public class HideAndShowMainUI : MonoBehaviour
{
    public void HideMain()
    {
        FindObjectOfType<MainUI>(true).gameObject.SetActive(false);
        FindObjectOfType<UnityUIQuestHUD>(true).Hide();
    }
    public void ShowMain()
    {
        FindObjectOfType<MainUI>(true).gameObject.SetActive(true);
        FindObjectOfType<UnityUIQuestHUD>(true).Show();
    }
}
