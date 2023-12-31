using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoliticLevelView : MonoBehaviour
{
    public Image fillImage;
    public Text LevelText;

    public void SetView(int Level, float expPercentage)
    {
        LevelText.text = "<size=15>ÊÆÁ¦</size>" + Level.ToString();
        fillImage.fillAmount = expPercentage;
    }
}
