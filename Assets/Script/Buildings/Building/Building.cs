using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public enum BuildingType
{
    马厩,
    御马场,
    天马阁,
    奇兽堂,
    百兽园,
    杂货铺,
    百货店,
    万仙楼,
    当铺,
    拍卖行,
    商行,
    珠宝店,
    西域珍品,
    胭脂铺,
    万香阁,
    铁匠铺,
    武器铺,
    机关阁,
    武侯楼,
    万兵阁,
    纺织铺,
    梭织坊,
    长安织造,
    服装店,
    玉服华裳,
    戏馆,
    青楼,
    红人馆,
    戏院,
    鼓瑟楼,
    药铺,
    丹房,
    仙鼎台,
    医院,
    研究院,
    酒馆,
    酒店,
    酒楼,
    馆驿,
    客栈,
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

    public int recordDay = -1;

    public Transform BuildingCharacterSlot;

    public List<ItemName> ShopList;

    public int shopMaxSpawn = 4;

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
            var map = FindObjectOfType<Map>();
            recordDay = map.Day;
        }
        shopRefSetUp();
    }

    public void shopRefSetUp()
    {
        var target = FindObjectOfType<BuildingUI>().GetComponent<ShopRef>();
        switch (buildingType)
        {
            case BuildingType.马厩:
                target.horseRent.GetComponent<HorseRentUI>().SetUp(horseList);
                break;
            case BuildingType.杂货铺:
                target.shopUI.GetComponent<IShopUI>().Setup(ShopList);
                break;
            case BuildingType.纺织铺:
            case BuildingType.长安织造:
                target.shopUI.GetComponent<IShopUI>().Setup(ShopList);
                SetupCraft();
                break;
            case BuildingType.商行:
                target.shopUI.GetComponent<IShopUI>().Setup(ShopList);
                break;
            case BuildingType.西域珍品:
                SetupCraft();
                target.shopUI.GetComponent<IShopUI>().Setup(ShopList);
                break;
            case BuildingType.药铺:
                target.shopUI.GetComponent<IShopUI>().Setup(ShopList);
                SetupCraft();
                break;
            case BuildingType.铁匠铺:
                target.shopUI.GetComponent<IShopUI>().Setup(ShopList);
                SetupCraft();
                break;
            case BuildingType.酒馆:
                target.shopUI.GetComponent<IShopUI>().Setup(ShopList);
                break;
            case BuildingType.戏馆:
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
            case BuildingType.杂货铺:
                return new List<ItemType>() { ItemType.杂货, ItemType.药材 };
            case BuildingType.酒馆:
                return new List<ItemType>() { };
            case BuildingType.药铺:
                CraftingList = SOItem.BuildingCraftDict[buildingType];
                return new List<ItemType>() { ItemType.丹药, ItemType.药材 };
            case BuildingType.商行:
                return new List<ItemType>() { ItemType.书籍 };
            case BuildingType.西域珍品:
            case BuildingType.珠宝店:
                CraftingList = SOItem.BuildingCraftDict[BuildingType.珠宝店];
                return new List<ItemType>() { ItemType.书籍 };
            case BuildingType.铁匠铺:
                CraftingList = SOItem.BuildingCraftDict[buildingType];
                return new List<ItemType>() { };
            case BuildingType.纺织铺:
            case BuildingType.长安织造:
                CraftingList = SOItem.BuildingCraftDict[buildingType];
                return new List<ItemType>() { ItemType.服装 };
            case BuildingType.戏馆:
                SetupNewCinemaPlay();
                break;
            case BuildingType.马厩:
                SetUpHorseRent();
                break;
        }
        return new List<ItemType>() { };
    }

    public void SpawnItemBasedOnType(List<ItemType> inputTypes)
    {
        int outputAmount = Random.Range(1, shopMaxSpawn);
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
        var map = FindObjectOfType<Map>();
        if (recordDay < map.Day) return true;
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
