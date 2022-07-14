using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideAndShowMainUI : MonoBehaviour
{
    public void HideMain()
    {
        FindObjectOfType<MainUI>(true).gameObject.SetActive(false);
    }
    public void ShowMain()
    {
        FindObjectOfType<MainUI>(true).gameObject.SetActive(true);
    }
}
