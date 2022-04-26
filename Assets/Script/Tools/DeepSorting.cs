using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DeepSorting : MonoBehaviour
{
    int IsometricRangePerYUnit = 1;
    private void Update()
    {
        SortingGroup sg = GetComponent<SortingGroup>();
        sg.sortingOrder = 100 - (int)(transform.position.y / IsometricRangePerYUnit);
    }
}
