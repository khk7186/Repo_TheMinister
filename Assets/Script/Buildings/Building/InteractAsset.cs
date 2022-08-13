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
        BuildingName = GetComponentInChildren<TextMeshPro>(true);
        BuildingName.text = building.buildingType.ToString();
        BuildingName.renderer.sortingOrder = GetComponent<Renderer>().sortingOrder + 1;
        BuildingName.gameObject.SetActive(false);
    }
    private void OnMouseDown()
    {
        if (Active == false) return;
        if (IsPointerOver.IsPointerOverUIObject())
        {
            //Debug.Log("Clicked on UI");
            return;
        }
        building.OpenMenu();
        FindObjectOfType<UnityUIQuestHUD>(true).Hide();
    }
    private void OnMouseEnter()
    {
        if (Active == false) return;
        if (IsPointerOver.IsPointerOverUIObject())
        {
            return;
        }
        GetComponent<Renderer>().material = highlightMaterial;
        BuildingName.gameObject.SetActive(true);
    }
    private void OnMouseExit()
    {
        if (Active == false) return;
        if (IsPointerOver.IsPointerOverUIObject())
        {
            return;
        }
        GetComponent<Renderer>().material = defaultMaterial;
        BuildingName.gameObject.SetActive(false);
    }
    IEnumerator HideUIUntilClose()
    {
        var hud =FindObjectOfType<UnityUIQuestHUD>();
        hud.Hide();
        yield return new WaitUntil(() => building.currentUI.gameObject.activeSelf == false);
        hud.Show();
    }
}