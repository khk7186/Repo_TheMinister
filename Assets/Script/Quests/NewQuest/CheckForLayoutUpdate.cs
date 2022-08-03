using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckForLayoutUpdate : MonoBehaviour
{
    int count = 0;
    private void FixedUpdate()
    {
        if (count != transform.childCount)
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
            count = transform.childCount;
        }
    }
}
