using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingUI : MonoBehaviour
{
    public Building building;

    public BuildingCharacterStoreUI buildingCharacterUI;
    private MeetPeopleCharacterCardUI MeetPeopleLayoutPrefab;

    private void Awake()
    {
        MeetPeopleLayoutPrefab = Resources.Load<MeetPeopleCharacterCardUI>("BuildingUI/MeetCharacter");
    }

    public void UpdateUI()
    {
        //SetMeetCharacterUI();
    }

    public void UpdateUI(Building building)
    {
        this.building = building;
        UpdateUI();
    }

    private void SetMeetCharacterUI()
    {
        var charList = building.charactersHere;
        foreach (Character character in charList)
        {
            MeetPeopleCharacterCardUI thisLayout = Instantiate(MeetPeopleLayoutPrefab, buildingCharacterUI.transform);
            thisLayout.UpdateUI(character);
        }
    }
    private void FixedUpdate()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }
}
