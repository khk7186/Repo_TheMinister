using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public enum BuildingType
{
    Âí¾Ç
}

public enum BuildingLevel
{
    LevelOne,
    LevelTwo,
    LevelThree,
}
public class Building : MonoBehaviour, IPointerClickHandler
{
    public BuildingType buildingType;
    public List<Character> charactersHere;

    public Transform BuildingCharacterSlot;

    [SerializeField] private BuildingUI buildingUI;

    public void Stable()
    {
        BuildingUI targetUI = Instantiate(buildingUI,GameObject.FindGameObjectWithTag("MainUICanvas").transform);
        targetUI.UpdateUI(this);
    }

    public void Encounter()
    {
        
    }

    public void Upgrade(BuildingType upGradeType)
    {
        buildingType = upGradeType;
    }

    public void OpenMenu()
    {
        if (charactersHere.Count <= 0)
        {
            WhoLiveInHere();
        }
        
        switch (buildingType)
        {
            default:
            case BuildingType.Âí¾Ç:
                Stable();
                break;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OpenMenu();
        Debug.Log(1);
    }


    public void WhoLiveInHere()
    {
        InGameCharacterStorage inGameCharacterStorage = 
            GameObject.FindGameObjectWithTag("InGameCharacterInventory")
            .GetComponent<InGameCharacterStorage>();
        charactersHere.AddRange(inGameCharacterStorage.SelectCharacterForBuilding(5));
    }
}
