using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllMainUIActivation : MonoBehaviour
{
    public bool On = false;
    private void Start()
    {
        var parent = GameObject.FindObjectOfType<MainCanvasTag>(true).transform;
        parent.gameObject.SetActive(true);
        var GameUI = parent.Find("GameUI").gameObject;
        GameUI.transform.Find("日期").gameObject.SetActive(On);
        GameUI.transform.Find("财产").gameObject.SetActive(On);
        GameUI.transform.Find("ButtomPart").gameObject.SetActive(On);
    }
}
