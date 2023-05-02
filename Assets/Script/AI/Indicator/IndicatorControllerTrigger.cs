using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorControllerTrigger : MonoBehaviour
{
    public bool StartOnEnable = false;
    public string StringSelected = "attack";
    public IndicatorController indicatorController;
    private void OnEnable()
    {
        indicatorController.ChangeSelected(StringSelected);
        indicatorController.gameObject.SetActive(false);
        indicatorController.gameObject.SetActive(true);
    }
}
