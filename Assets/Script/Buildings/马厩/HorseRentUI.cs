using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseRentUI : MonoBehaviour
{
    public Transform content;
    public HorseItemUI shopItemUI;
    public int numberOfSpawn = 5;
    public void Setup(List<ItemName> horseList, BuildingType buildingType)
    {
        shopItemUI.gameObject.SetActive(false);
        foreach (ItemName hr in horseList)
        {
            var current = Instantiate(shopItemUI, content);
            current.SetupHorseItem(hr, buildingType);
            current.gameObject.SetActive(true);
        }
    }
}
