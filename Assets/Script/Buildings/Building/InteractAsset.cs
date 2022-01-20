using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractAsset : MonoBehaviour
{
    private Building building;
    public bool Active = false;

    private void Awake()
    {
        building = GetComponent<Building>();
    }

    private void OnMouseDown()
    {
        if (Active == false) return;
        if (!IsPointerOver.IsPointerOverUIObject())
        {
            building.OpenMenu();
        }
    }

}
