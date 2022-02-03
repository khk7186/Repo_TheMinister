using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGroupLayerSorting : MonoBehaviour
{
    public List<Canvas> ChangeList = new List<Canvas>();
    public int GroupLayerLevel = 0;

    private void Start()
    {
        foreach (Canvas canvas in ChangeList)
        {
            canvas.sortingOrder += GroupLayerLevel * 10;
        }
    }
    public void Setup(int level)
    {
        foreach (Canvas canvas in ChangeList)
        {
            canvas.sortingOrder += (level-GroupLayerLevel) * 10;
        }
        GroupLayerLevel = level;
    }
}
