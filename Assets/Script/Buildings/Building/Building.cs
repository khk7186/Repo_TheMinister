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


    public Transform BuildingCharacterSlot;

    [SerializeField] private GameObject StableCanvas;
    private MeetPeopleLayout MeetPeopleLayoutPrefab;

    private void Awake()
    {
        MeetPeopleLayoutPrefab = Resources.Load<MeetPeopleLayout>("BuildingUI/MeetCharacter");
    }

    public void Stable()
    {
        Instantiate(StableCanvas,GameObject.FindGameObjectWithTag("MainUICanvas").transform);
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
        inGameCharacterStorage.SelectCharacterForBuilding(5);
    }
}
