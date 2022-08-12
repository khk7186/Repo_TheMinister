using PixelCrushers.QuestMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.EventSystems;
using TMPro;
public class InteractAsset : MonoBehaviour
{
    private Building building;
    public bool Active = false;
    public Material defaultMaterial;
    public Material highlightMaterial;
    public TextMeshPro BuildingName;

    private void Awake()
    {
        building = GetComponent<Building>();
        GetComponent<Renderer>().material = defaultMaterial;
        BuildingName = GetComponentInChildren<TextMeshPro>();
        BuildingName.text = building.buildingType.ToString();
    }

    private void OnMouseDown()
    {
        if (Active == false) return;
        if (IsPointerOver.IsPointerOverUIObject())
        {
            Debug.Log("Clicked on UI");
            return;
        }
        building.OpenMenu();
        FindObjectOfType<UnityUIQuestHUD>(true).Hide();
    }
    private void OnMouseEnter()
    {
        if (IsPointerOver.IsPointerOverUIObject())
        {
            return;
        }
        GetComponent<Renderer>().material = highlightMaterial;
        BuildingName.gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        if (IsPointerOver.IsPointerOverUIObject())
        {
            return;
        }
        GetComponent<Renderer>().material = defaultMaterial;
        BuildingName.gameObject.SetActive(false);
    }
}