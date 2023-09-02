using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvasOn : MonoBehaviour
{
    private void Start()
    {
        var canvas = GameObject.FindObjectOfType<MainCanvasTag>(true);
        canvas.gameObject.SetActive(true);
        canvas.transform.GetComponentInChildren<NoTouchMask>().gameObject.SetActive(false);
    }
}
