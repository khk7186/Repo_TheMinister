using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum BuildingType
{
    Âí¾Ç,
    ÔÓ»õÆÌ,
    ÉÌÐÐ,
    Ìú½³ÆÌ,
    ·ÄÖ¯ÆÌ,
    Ï·¹Ý,
    Ò©ÆÌ,
    ¾Æ¹Ý
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
            case BuildingType.Âí¾Ç:
                target.horseRent.GetComponent<HorseRent>().SetUp(horseList);
                break;
            case BuildingType.ÔÓ»õÆÌ:
                target.shopUI.GetComponent<IShopUI>().SetUp(ShopList);
                break;
            case BuildingType.·ÄÖ¯ÆÌ:
                target.shopUI.GetComponent<IShopUI>().SetUp(ShopList);
                break;
            case BuildingType.ÉÌÐÐ:
                target.shopUI.GetComponent<IShopUI>().SetUp(ShopList);
                break;
            case BuildingType.Ò©ÆÌ:
                target.shopUI.GetComponent<IShopUI>().SetUp(ShopList);
                break;
            case BuildingType.Ìú½³ÆÌ:
                target.shopUI.GetComponent<IShopUI>().SetUp(ShopList);
                break;
            case BuildingType.¾Æ¹Ý:
                target.shopUI.GetComponent<IShopUI>().SetUp(ShopList);
                break;
            case BuildingType.Ï·¹Ý:
                target.shopUI.GetComponent<IShopUI>().SetUp(ShopList);
                break;
        }
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
            case BuildingType.ÔÓ»õÆÌ:
                return new List<ItemType>() { ItemType.ÔÓ»õ, ItemType.Ò©²Ä };
            case BuildingType.¾Æ¹Ý:
                return new List<ItemType>() { };
            case BuildingType.Ò©ÆÌ:
                return new List<ItemType>() { };
            case BuildingType.ÉÌÐÐ:
                return new List<ItemType>() { ItemType.Êé¼®, ItemType.ÊÎÆ· };
            case BuildingType.Ìú½³ÆÌ:
                return new List<ItemType>() { };
            case BuildingType.·ÄÖ¯ÆÌ:
                return new List<ItemType>() { };
            case BuildingType.Âí¾Ç:
                SetUpHorseRent();
                return null;
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
            ItemName currentItem = SOItem.ItemTypeDict[inputTypes[randomTypeIndex]][0];
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
        var horserent = targetRef.horseRent.GetComponent<HorseRent>();
        horseList = new List<HorseRank>();
        for (int i = 0; i < horserent.numberOfSpawn; i++)
        {
            horseList.Add(horserent.RandomHorse());
        }
    }
}
