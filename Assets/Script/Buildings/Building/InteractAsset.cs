using PixelCrushers.QuestMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.EventSystems;
using TMPro;
public class InteractAsset : MonoBehaviour, IDetailAble
{
    private Building building;
    public bool Active = false;
    public Material defaultMaterial;
    public Material highlightMaterial;
    public Material unreachMaterial;
    public TextMeshPro BuildingName;
    public TMP_FontAsset fontAsset;
    public string buildingNameText = "";
    public Color ReachableColor;
    public Color UnreachableColor;
    private void Awake()
    {
        building = GetComponent<Building>();
        GetComponent<Renderer>().material = defaultMaterial;
        BuildingName = GetComponentInChildren<TextMeshPro>(true);
        BuildingName.font = fontAsset;
        buildingNameText = building.buildingType.ToString();
        BuildingName.text = buildingNameText;
        BuildingName.fontSize = 40f;
        BuildingName.renderer.sortingOrder = 100;
        BuildingName.gameObject.SetActive(false);
    }
    private void OnMouseDown()
    {
        AudioManager.Play("按钮");
        if (Active == false) return;
        if (IsPointerOver.IsPointerOverUIObject())
        {
            //Debug.Log("Clicked on UI");
            return;
        }
        building.OpenMenu();
    }
    private void OnMouseEnter()
    {
        BuildingName.renderer.sortingOrder = 100;
        if (IsPointerOver.IsPointerOverUIObject())
        {
            //Debug.Log("OverUI");
            return;
        }
        SetOnDetail(building.buildingType.ToString());
        if (ChapterCounter.Instance.Chapter == 3)
        {
            GetComponent<Renderer>().material = unreachMaterial;
            BuildingName.fontSize = 30f;
            BuildingName.color = UnreachableColor;
            BuildingName.text = $"无人营业";
            BuildingName.gameObject.SetActive(true);
            return;
        }
        if (Active == false)
        {
            GetComponent<Renderer>().material = unreachMaterial;
            BuildingName.fontSize = 20f;
            BuildingName.color = UnreachableColor;
            BuildingName.text = $"{buildingNameText}\n (太远了)";
            BuildingName.gameObject.SetActive(true);
            return;
        }
        GetComponent<Renderer>().material = highlightMaterial;
        BuildingName.fontSize = 40f;
        BuildingName.color = ReachableColor;
        BuildingName.text = buildingNameText;
        BuildingName.gameObject.SetActive(true);

    }
    private void OnMouseOver()
    {
        if (IsPointerOver.IsPointerOverUIObject())
        {
            SetOffDetail();
        }
    }
    private void OnMouseExit()
    {
        GetComponent<Renderer>().material = defaultMaterial;
        BuildingName.gameObject.SetActive(false);
        SetOffDetail();
        if (Active == false) return;
        if (IsPointerOver.IsPointerOverUIObject())
        {
            return;
        }
    }
    IEnumerator HideUIUntilClose()
    {
        var hud = FindObjectOfType<UnityUIQuestHUD>();
        hud.Hide();
        yield return new WaitUntil(() => building.currentUI.gameObject.activeSelf == false);
        hud.Show();
    }

    public void SetOffDetail()
    {
        MenuDescriptionUI.Hide();
    }
    public void SetOnDetail(string target)
    {
        MenuDescriptionUI.Show(target);
    }
}