using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoliticLevelView : MonoBehaviour
{
    public Image fillImage;
    public Text LevelText;

    private void OnEnable()
    {
        SetView(LevelManager.Instance.level, (float)LevelManager.Instance.exp / LevelManager.Instance.expPerLevel[LevelManager.Instance.level]);    
    }
    public void SetView(int Level, float expPercentage)
    {
        LevelText.text = "<size=15>ÊÆÁ¦</size>" + Level.ToString();
        fillImage.fillAmount = expPercentage;
    }
}
