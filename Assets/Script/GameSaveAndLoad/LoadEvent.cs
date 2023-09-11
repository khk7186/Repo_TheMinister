using PixelCrushers;
using PixelCrushers.DialogueSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SaveSystem
{
    public static class LoadEvent
    {
        public static void Load(SaveAndLoadManager manager, SOGameSave save)
        {
            LoadPlayerCharacters(save);
            LoadMap(manager, save);
            LoadOtherCharacters(save);
            LoadInventory(manager, save);
            LoadPlayer(manager, save);

        }
        public static void LoadPlayerCharacters(SOGameSave save)
        {
            foreach (SerializedCharacter target in save.playerOwnedCharacters)
            {
                SerializedCharacter.DeserializingCharacter(target);
            }
        }

        public static void LoadMap(SaveAndLoadManager manager, SOGameSave save)
        {
            var map = manager.map;
            map.DayTime = save.serializedMapData.DayTime;
            map.Day = save.serializedMapData.Day;
            var mainUI = GameObject.FindObjectOfType<MainUI>();
            mainUI.DayTimeIconAnimController.EnableEvent();
            mainUI.SetupTime();
        }

        public static void LoadOtherCharacters(SOGameSave save)
        {
            foreach (SerializedCharacter target in save.InCityCharacters)
            {
                SerializedCharacter.DeserializingCharacter(target);
            }
        }

        public static void LoadPlayer(SaveAndLoadManager manager, SOGameSave save)
        {
            var player = manager.player;
            var playerMovement = player.GetComponent<CharacterMovement>();
            playerMovement.currentBlock = save.currentBlock;
            playerMovement.finalBlock = save.currentBlock;
            var playerSideChanger = player.GetComponent<SideChanger>();
            playerSideChanger.changeSide(save.isFront, save.isRight);
            manager.map.SetPlayerPosition(save.currentBlock);
            manager.map.SetBuildings();
        }

        public static void LoadInventory(SaveAndLoadManager manager, SOGameSave save)
        {
            var inv = manager.itemInventory;
            var items = save.playerOwnedItems;
            foreach (var item in items)
            {
                for (int i = 0; i < item.amount; i++)
                {
                    inv.AddItem(SerializedInventory.DeserializingItem(item));
                }
            }
            manager.currencyInventory.MoneyLoad(save.Money);
        }
    }
}