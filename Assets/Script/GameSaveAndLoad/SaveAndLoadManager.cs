using PixelCrushers.QuestMachine.Wrappers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

namespace SaveSystem
{
    public class SaveAndLoadManager : MonoBehaviour
    {
        public SOGameSaveDatabase GameSaveDatabase;
        public SOGameSave gameSave;
        public Map map;
        public PathManager pathManager;
        public CharacterSpawnPool characterSpawnPool;
        public RoitManager roitManager;
        public AreaControl areaControl;
        public Transform playerCharacterInventory;
        public ItemInventory itemInventory;
        public CurrencyInventory currencyInventory;
        public Player player;
        public QuestJournal playerQuestJournal;
        public InGameCharacterStorage inGameCharacterStorage;


        public void LoadCharacters()
        {
            foreach (SerializedCharacter target in gameSave.playerOwnedCharacters)
            {
                SerializedCharacter.DeserializingCharacter(target);
            }
        }
        public void LoadGame(string saveName)
        {
            player = FindObjectOfType<Player>();
            playerQuestJournal = player.GetComponent<QuestJournal>();
            GameSaveDatabase.currentGameSave = GameSaveDatabase.gameSaves.Find(x => x.saveName == saveName);
            LoadEvent.Load(this, GameSaveDatabase.currentGameSave);
        }
        public void LoadGame(SOGameSave save)
        {
            player = FindObjectOfType<Player>();
            playerQuestJournal = player.GetComponent<QuestJournal>();
            GameSaveDatabase.currentGameSave = save;
            LoadEvent.Load(this, GameSaveDatabase.currentGameSave);
        }
        //public void SaveGame()
        //{
        //    player = FindObjectOfType<Player>();
        //    playerQuestJournal = player.GetComponent<QuestJournal>();
        //    var save = SaveEvent.Save(this);
        //    save.saveName = System.DateTime.Now.ToString()
        //                            .Replace("/", string.Empty).Replace(" ", string.Empty).Replace(":", string.Empty);
        //    AssetDatabase.CreateAsset(save, $"Assets/Resources/SaveData/Save{save.saveName}.asset");
        //    AssetDatabase.SaveAssets();
        //    GameSaveDatabase.gameSaves.Enqueue(save);
        //}
        public void SaveGame(string SaveName = null)
        {
            player = FindObjectOfType<Player>();
            playerQuestJournal = player.GetComponent<QuestJournal>();
            var save = SaveEvent.Save(this);
            if (SaveName == null || SaveName == string.Empty)
            {
                save.saveName = System.DateTime.Now.ToString()
                                    .Replace("/", string.Empty).Replace(" ", string.Empty).Replace(":", string.Empty);
            }
            else
            {
                save.saveName = SaveName;
            }
            AssetDatabase.CreateAsset(save, $"Assets/Resources/SaveData/Save{save.saveName}.asset");
            AssetDatabase.SaveAssets();
            GameSaveDatabase.gameSaves.Add(save);
        }
    }
}