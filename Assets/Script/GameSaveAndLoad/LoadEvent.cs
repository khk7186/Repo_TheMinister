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
        public static void Load(SaveAndLoadManager manager, GameSave save)
        {
            LoadPlayerCharacters(save);
            LoadMap(manager, save);
            LoadOtherCharacters(save);
            LoadInventory(manager, save);
            LoadPlayer(manager, save);
            LoadQuestMachine(save);
            manager.questionAIManager.Load(save);
        }
        public static void LoadPlayerCharacters(GameSave save)
        {
            foreach (SerializedCharacter target in save.playerOwnedCharacters)
            {
                SerializedCharacter.DeserializingCharacter(target);
            }
        }

        public static void LoadMap(SaveAndLoadManager manager, GameSave save)
        {
            var map = manager.map;
            map.DayTime = save.serializedMapData.DayTime;
            map.Day = save.serializedMapData.Day;
            var mainUI = GameObject.FindObjectOfType<MainUI>();
            mainUI.DayTimeIconAnimController.EnableEvent();
            mainUI.SetupTime();
        }

        public static void LoadOtherCharacters(GameSave save)
        {
            foreach (SerializedCharacter target in save.InCityCharacters)
            {
                SerializedCharacter.DeserializingCharacter(target);
            }
        }

        public static void LoadPlayer(SaveAndLoadManager manager, GameSave save)
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

        public static void LoadInventory(SaveAndLoadManager manager, GameSave save)
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
        public static void LoadQuestMachine(GameSave save)
        {
            PixelCrushers.SaveSystem.ApplySavedGameData(save.questMachineSave);
        }
    }
}