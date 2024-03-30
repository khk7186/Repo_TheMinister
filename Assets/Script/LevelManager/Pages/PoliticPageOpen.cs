using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliticPageOpen : MonoBehaviour
{
    public void OpenPage()
    {

        FindObjectOfType<PoliticActionUI>().Show();
    }
    private void OnEnable()
    {
        if (ChapterCounter.Instance.Chapter == 3)
        {
            gameObject.SetActive(false);
        }
    }
}
