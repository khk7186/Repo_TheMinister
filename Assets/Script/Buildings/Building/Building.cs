using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
public class Building : MonoBehaviour
{
    public BuildingType buildingType;

    [SerializeField] private GameObject StableCanvas;

    public void Stable()
    {
        
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
}
