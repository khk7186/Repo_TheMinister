using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliticFactionTrigger : MonoBehaviour
{
    public PoliticFactionMenuUI politicFactionMenuUI = null;
    public void OnClick()
    {
        politicFactionMenuUI.Show();
    }
    private void OnEnable()
    {
        if (ChapterCounter.Instance.Chapter == 3)
        {
            gameObject.SetActive(false);
        }
    }
}
