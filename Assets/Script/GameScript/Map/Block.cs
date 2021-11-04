using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Building BuildingOne;
    public Building BuildingTwo;
    public Building BuildingThree;

    public void Away()
    {
        BuildingOne.GetComponent<InteractAsset>().Active = false;
        BuildingTwo.GetComponent<InteractAsset>().Active = false;
        BuildingThree.GetComponent<InteractAsset>().Active = false;
    }

    public void Stay()
    {
        BuildingOne.GetComponent<InteractAsset>().Active = true;
        BuildingTwo.GetComponent<InteractAsset>().Active = true;
        BuildingThree.GetComponent<InteractAsset>().Active = true;
    }
}
