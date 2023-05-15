using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectForQuest : MonoBehaviour
{
    public void PreSelect()
    {
        GetComponent<SpawnUI>().SpawnWithReturn().GetComponent<PlayerCharactersInventory>().SetupMode(CardMode.UpgradeSelectMode);
    }
}
