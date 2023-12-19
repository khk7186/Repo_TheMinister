using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressureView : MonoBehaviour
{
    public Image fillImage;
    public RectTransform textWrapper;
    public Text PercentageText;
    public Text AddPerDayText;
    private void Start()
    {
        SetAddPerDay();
    }
    public void SetPercentage(int percentage)
    {
        fillImage.fillAmount = percentage / 100f;
        PercentageText.text = $"{percentage}%";
        ForceLayout();
    }
    public void SetAddPerDay()
    {
        int add = PressureManager.Instance.pressureAddPerDay;
        AddPerDayText.text = $"»’‘ˆ\r\n<color=red>{add}</color>µ„";
        ForceLayout();
    }
    public void FixedUpdate()
    {
        ForceLayout();
    }
    private void ForceLayout()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(textWrapper);
    }
    private void OnLevelWasLoaded(int level)
    {
        SetPercentage(PressureManager.Instance.pressure);
    }
}
