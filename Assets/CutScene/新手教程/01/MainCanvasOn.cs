using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvasOn : MonoBehaviour
{
    private void Start()
    {
        GameObject.FindObjectOfType<MainCanvasTag>(true).gameObject.SetActive(true);
    }
}
