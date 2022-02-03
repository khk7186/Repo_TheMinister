using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public enum BuildingType
{
    ¬Ìæ«,
    ‘”ªı∆Ã,
    …Ã––,
    ÷È±¶µÍ,
    Œ˜”Ú’‰∆∑,
    ÎŸ÷¨∆Ã,
    ÕÚœ„∏Û,
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
public class Building : MonoBehaviour
{
    public BuildingType buildingType;
    public List<Character> charactersHere;

    public int MaxBuildingQuest = 3;

    public int recordWeek = -1;

    public Transform BuildingCharacterSlot;

    public List<ItemName> ShopList;

    [SerializeField] private BuildingUI buildingUI;
    public List<QuestLineAgent> questLineList = new List<QuestLineAgent>();
    private List<HorseRank> horseList;

    public List<ItemName> CraftingList = new List<ItemName>();

    public PlayName currentPlay;
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
        BuildingUI targetUI = Instantiate(buildingUI, MainCanvas.FindMainCanvas());
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
            SetPersonHere();
        }
        UpdateType();
        CreateUI();
        if (RecordWeekCheck())
        {
            SpawnItems();
            recordWeek = Map.Week;
        }
        shopRefSetUp();
    }

    public void shopRefSetUp()
    {
        var target = FindObjectOfType<BuildingUI>().GetComponent<ShopRef>();
        switch (buildingType)
        {
            case BuildingType.¬Ìæ«:
                target.horseRent.GetComponent<HorseRentUI>().SetUp(horseList);
                break;
            case BuildingType.‘”ªı∆Ã:
                target.shopUI.GetComponent<IShopUI>().Setup(ShopList);
                break;
            case BuildingType.∑ƒ÷Ø∆Ã:
                target.shopUI.GetComponent<IShopUI>().Setup(ShopList);
                SetupCraft();
                break;
            case BuildingType.…Ã––:
                target.shopUI.GetComponent<IShopUI>().Setup(ShopList);
                break;
            case BuildingType.Œ˜”Ú’‰∆∑:
                SetupCraft();
                target.shopUI.GetComponent<IShopUI>().Setup(ShopList);
                break;
            case BuildingType.“©∆Ã:
                target.shopUI.GetComponent<IShopUI>().Setup(ShopList);
                SetupCraft();
                break;
            case BuildingType.Ã˙Ω≥∆Ã:
                target.shopUI.GetComponent<IShopUI>().Setup(ShopList);
                SetupCraft();
                break;
            case BuildingType.æ∆π›:
                target.shopUI.GetComponent<IShopUI>().Setup(ShopList);
                break;
            case BuildingType.œ∑π›:
                target.CinemaUI.GetComponent<CinemaUI>().Setup(currentPlay);
                break;
        }
    }

    public void SetupCraft()
    {
        var target = FindObjectOfType<BuildingUI>().GetComponent<ShopRef>();
        var currentTarget = target.CraftingUI.GetComponent<CraftingUI>();
        currentTarget.Setup(CraftingList);
        if (CraftingList.Count > 0) target.CraftingUI.GetComponent<CraftingUI>().Setup(CraftingList[0]);
    }

    public void SetPersonHere()
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
                CraftingList = SOItem.BuildingCraftDict[buildingType];
                return new List<ItemType>() { ItemType.µ§“©, ItemType.“©≤ƒ };
            case BuildingType.…Ã––:
                return new List<ItemType>() { ItemType. ÈºÆ };
            case BuildingType.Œ˜”Ú’‰∆∑:
            case BuildingType.÷È±¶µÍ:
                CraftingList = SOItem.BuildingCraftDict[BuildingType.÷È±¶µÍ];
                return new List<ItemType>() { ItemType. ÈºÆ };
            case BuildingType.Ã˙Ω≥∆Ã:
                CraftingList = SOItem.BuildingCraftDict[buildingType];
                return new List<ItemType>() { };
            case BuildingType.∑ƒ÷Ø∆Ã:
                CraftingList = SOItem.BuildingCraftDict[buildingType];
                return new List<ItemType>() { ItemType.∑˛◊∞ };
            case BuildingType.œ∑π›:
                SetupNewCinemaPlay();
                break;
            case BuildingType.¬Ìæ«:
                SetUpHorseRent();
                break;
        }
        return new List<ItemType>() { };
    }

    public void SpawnItemBasedOnType(List<ItemType> inputTypes)
    {
        int outputAmount = Random.Range(5, 10);
        List<ItemName> outputItems = new List<ItemName>();
        for (int i = 0; i < outputAmount; i++)
        {
            if (inputTypes.Count < 1) return;
            int randomTypeIndex = Random.Range(0, inputTypes.Count);
            var targetList = SOItem.ItemTypeDict[inputTypes[randomTypeIndex]];
            int randomItemIndex = Random.Range(0, targetList.Count);
            ItemName currentItem = targetList[randomItemIndex];
            outputItems.Add(currentItem);
        }
        ShopList = outputItems;
    }

    public void SpawnItems()
    {
        var result = ShopType();
        if (result != null)
        {
            SpawnItemBasedOnType(result);
        }
    }

    public bool RecordWeekCheck()
    {
        if (recordWeek < Map.Week) return true;
        else return false;
    }

    public void SetUpHorseRent()
    {
        var targetRef = FindObjectOfType<BuildingUI>().GetComponent<ShopRef>();
        var horserent = targetRef.horseRent.GetComponent<HorseRentUI>();
        horseList = new List<HorseRank>();
        for (int i = 0; i < horserent.numberOfSpawn; i++)
        {
            horseList.Add(horserent.RandomHorse());
        }
    }

    public void AddCraftingToBuilding(ItemName item)
    {
        CraftingList.Add(item);
    }

    public void SetupNewCinemaPlay()
    {
        var keyList = PlayList.PlayListDict.Keys.ToList<PlayName>();
        int i = Random.Range(0, keyList.Count);
        currentPlay = keyList[i];
    }
}
