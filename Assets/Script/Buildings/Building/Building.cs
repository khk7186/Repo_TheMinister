
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum BuildingType
{
    ¬Ìæ«,
    ‘”ªı∆Ã,
    …Ã––,
    Ã˙Ω≥∆Ã,
    ∑ƒ÷Ø∆Ã,
    œ∑π›,
    “©∆Ã,
    æ∆π›
}

public enum BuildingLevel
{
    LevelOne,
    LevelTwo,
    LevelThree
}
public class Building : MonoBehaviour, IPointerClickHandler
{
    public BuildingType buildingType;
    public List<Character> charactersHere;

    public int MaxBuildingQuest = 3;

    public Transform BuildingCharacterSlot;

    public List<ItemName> ShopList;

    [SerializeField] private BuildingUI buildingUI;
    public List<QuestLineAgent> questLineList = new List<QuestLineAgent>();
    private void Awake()
    {
        UpdateType();
    }
    public void UpdateType()
    {
        string FolderPath = ("BuildingUI/" + buildingType.ToString()).Replace(" ", string.Empty);
        buildingUI = Resources.Load<BuildingUI>(FolderPath);
    }
    public void UpdateType(BuildingType buildingType)
    {
        this.buildingType = buildingType;
        UpdateType();
    }

    public void UpdateQuests()
    {
        QuestMapAgent questMapAgent =
        GameObject
        .FindGameObjectWithTag("GameFiles")
        .GetComponentInChildren<QuestMapAgent>();

        questLineList = new List<QuestLineAgent>();
        var targetLine = questMapAgent.LoadShopQuest(buildingType);
        targetLine.InUse = true;
        questLineList.Add(targetLine);
    }

    public void CreateUI()
    {
        BuildingUI targetUI = Instantiate(buildingUI, GameObject.FindGameObjectWithTag("MainUICanvas").transform);
        targetUI.UpdateUI(this);
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

        
        UpdateType();
        CreateUI();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }

    public static bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
    public void WhoLiveInHere()
    {
        InGameCharacterStorage inGameCharacterStorage =
            GameObject.FindGameObjectWithTag("InGameCharacterInventory")
            .GetComponent<InGameCharacterStorage>();

        charactersHere.AddRange(inGameCharacterStorage.SelectCharacterForBuilding(5));
    }

    public List<ItemType> ShopType()
    {
        switch (buildingType)
        {
            case BuildingType.‘”ªı∆Ã:
                return new List<ItemType>() { ItemType.‘”ªı, ItemType.“©≤ƒ };
            case BuildingType.æ∆π›:
                return new List<ItemType>() { };
            case BuildingType.“©∆Ã:
                return new List<ItemType>() { };
            case BuildingType.…Ã––:
                return new List<ItemType>() { ItemType. ÈºÆ,ItemType. Œ∆∑ };
            case BuildingType.Ã˙Ω≥∆Ã:
                return new List<ItemType>() { };
            case BuildingType.∑ƒ÷Ø∆Ã:
                return new List<ItemType>() { };
        }
        return new List<ItemType>() { };
    }

    public void SpawnItemBasedOnType(List<ItemType> inputTypes)
    {
        int outputAmount = Random.Range(5, 10);
        List<ItemName> outputItems = new List<ItemName>(); 
        for(int i = 0; i <outputAmount; i++)
        {
            if (inputTypes.Count < 1) return;
            int randomTypeIndex = Random.Range(0, inputTypes.Count);
            ItemName currentItem = SOItem.ItemTypeDict[inputTypes[randomTypeIndex]][0];
            outputItems.Add(currentItem);
        }
        ShopList = outputItems;
    }

}
