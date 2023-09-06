using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SaveSystem
{

    [CreateAssetMenu(fileName = "GameSave", menuName = "ScriptableObjects/GameSave", order = 7)]
    [Serializable]
    public class SOGameSave : ScriptableObject
    {
        public List<ItemInString> playerOwnedItems;
        public List<SerializedCharacter> playerOwnedCharacters;
        public int Money = 0;
        public int Pressure = 0;
        //Map Data
        public Map map;
        public int DayTime = 0;
        public int Day = 0;

        //PlayerPositionData
        public int currentBlock = 0;

        //Player model & Side Data
        public bool isFront;
        public bool isRight;
        
        

    }
    [System.Serializable]
    public class ItemInString
    {
        [SerializeField]
        public string itemName;
        [SerializeField]
        public int amount;
    }

}