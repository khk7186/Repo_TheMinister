using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustCurrencyOn : MonoBehaviour
{
    private void Start()
    {
        var parent = GameObject.FindObjectOfType<MainCanvasTag>(true).transform;
        parent.gameObject.SetActive(true);
        var GameUI = parent.Find("GameUI").gameObject;
        GameUI.transform.Find("财产").gameObject.SetActive(true);
        GameUI.transform.Find("日期").gameObject.SetActive(false);
        GameUI.transform.Find("ButtomPart").gameObject.SetActive(false);
    }
}
