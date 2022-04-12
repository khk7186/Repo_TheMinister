using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCurrentPlayer : MonoBehaviour
{
    public void SpawnCharacterChooseUI()
    {
        PlayerCharactersInventory playerCharactersInventory = Resources.Load<PlayerCharactersInventory>("CharacterInvUI/ChraInvUI");
        PlayerCharactersInventory current = Instantiate(playerCharactersInventory, GameObject.FindGameObjectWithTag("MainUICanvas").transform);
        current.SetupMode(CardMode.ItemSelectMode);
    }
}
