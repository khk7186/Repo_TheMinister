using PixelCrushers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SaveSystem
{
    [Serializable]
    public class GameSave
    {
        public string saveName = string.Empty;
        public string saveTime = string.Empty;
        //Player Inventory
        public List<ItemInString> playerOwnedItems = new List<ItemInString>();
        public List<SerializedCharacter> playerOwnedCharacters = new List<SerializedCharacter>();
        public int Money = 0;
        public int Pressure = 0;
        //Map Data
        public SerializedMapData serializedMapData = null;

        //Roit Data
        public SerializedRoitData roitData = null;

        //PlayerPositionData
        public int currentBlock = 0;

        //Player model & Side Data
        public bool isFront = false;
        public bool isRight = false;

        //In City Characters
        public List<SerializedCharacter> InCityCharacters = new List<SerializedCharacter>();

        public int chapter = 0;

        //Quest AI Manager Data
        public QuestChainStateWrap questChainStateWrapper = null;
        public List<QuestGiverAI> InactiveQuestGivers;
        public List<QuestGiverAI> UntriggeredQuestGivers = new List<QuestGiverAI>();
        public List<QuestGiverAI> TriggeredQuestGivers = new List<QuestGiverAI>();

        //QuestMachine Data
        [SerializeField]
        public SavedGameData questMachineSave = new SavedGameData();
    }
    [System.Serializable]
    public class ItemInString
    {
        [SerializeField]
        public string itemName = string.Empty;
        [SerializeField]
        public int amount = 0;
    }

}