using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalizeGame : MonoBehaviour
{
    public bool On = false;
    private void OnEnable()
    {
        //UI normalize
        var parent = GameObject.FindObjectOfType<MainCanvasTag>(true).transform;
        parent.gameObject.SetActive(true);
        var GameUI = parent.Find("GameUI").gameObject;
        GameUI.transform.Find("日期").gameObject.SetActive(On);
        GameUI.transform.Find("财产").gameObject.SetActive(On);
        GameUI.transform.Find("ButtomPart").gameObject.SetActive(On);
        GameUI.transform.Find("SaveButton").gameObject.SetActive(On);
        GameObject.FindObjectOfType<PressureView>()?.SetPercentage(PressureManager.Instance.pressure);
        //In-game character spawn normalize
        var igcs = InGameCharacterStorage.Instance;
        if (igcs == null)
        {
            igcs = FindObjectOfType<InGameCharacterStorage>(true);
            igcs.Start();
        }
        igcs.gameObject.SetActive(On);
        igcs.AdjustCharacterStorage();

        GameInitialization.instance.StartComfortGame();
    }
}
