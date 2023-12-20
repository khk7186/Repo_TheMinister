using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SaveSystem
{
    public static class SaveEvent
    {
        public static GameSave Save(SaveAndLoadManager manager)
        {
            //Create new save
            var newGameSave = new GameSave();
            newGameSave.saveTime = System.DateTime.Now.ToString();

            //Save player characters
            var playerCharacters = manager.playerCharacterInventory.GetComponentsInChildren<Character>();
            newGameSave.playerOwnedCharacters = new List<SerializedCharacter>();
            foreach (Character character in playerCharacters)
            {
                var saveData = SerializedCharacter.SerializingCharacter(character);
                newGameSave.playerOwnedCharacters.Add(saveData);
            }
            //SaveInCityCharacters
            var incityCharacters = manager.inGameCharacterStorage.CurrentCharacters;
            foreach (Character character in incityCharacters)
            {
                var saveData = SerializedCharacter.SerializingCharacter(character);
                newGameSave.InCityCharacters.Add(saveData);
            }

            //Save player items and money
            var playerItems = manager.itemInventory.ItemDict;
            newGameSave.playerOwnedItems = new List<ItemInString>();
            foreach (ItemName item in playerItems.Keys)
            {
                var itemData = SerializedInventory.SerializingItem(item, playerItems[item]);
                newGameSave.playerOwnedItems.Add(itemData);
            }
            newGameSave.Money = manager.currencyInventory.Money;

            //Save map data
            var map = manager.map;
            var mapData = SerializedMapData.SerializingMapData(map);
            newGameSave.serializedMapData = mapData;

            //Save Pressure data
            newGameSave.Pressure = PressureManager.Instance.pressure;

            //Save roit data
            var roitManager = manager.roitManager;
            newGameSave.roitData = SerializedRoitData.Serializing(roitManager);

            //Save player position
            var player = manager.player;
            var currenBlock = player.GetComponent<CharacterMovement>().currentBlock;
            newGameSave.currentBlock = currenBlock;

            //Save player facing
            var playerSideChanger = player.GetComponent<SideChanger>();
            newGameSave.isFront = playerSideChanger.isFront;
            newGameSave.isRight = playerSideChanger.isRight;

            //Save Main Quest Progress
            if (manager.gameEventManager.nextEvent != null)
                newGameSave.currentMainEventName = manager.gameEventManager.nextEvent.profileName;
            newGameSave.MainEventRemainToShow = manager.gameEventManager.timeRemain;

            //Save Side Quests objects
            manager.questionAIManager.Save(newGameSave);

            //Save questMachine system
            //PixelCrushers.SaveSystem.BeforeSceneChange();
            //PixelCrushers.SaveSystem.SaveToSlot(0);
            var origin = PixelCrushers.SaveSystem.RecordSavedGameData();
            newGameSave.questMachineSave = (PixelCrushers.SavedGameData)origin.Clone();


            //Save Chapter & background music
            newGameSave.chapter = ChapterCounter.Instance.Chapter;

            //delayToSpawn data
            if (manager.delayToSpawn != null)
                newGameSave.delayToSpawn = manager.delayToSpawn.name;

            return newGameSave;
        }

    }
}