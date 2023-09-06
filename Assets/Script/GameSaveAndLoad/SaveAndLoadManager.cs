using PixelCrushers.QuestMachine.Wrappers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SaveSystem
{
    public class SaveAndLoadManager : MonoBehaviour
    {
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


        public void LoadCharacters()
        {
            foreach (SerializedCharacter target in gameSave.playerOwnedCharacters)
            {
                SerializedCharacter.DeserializingCharacter(target);
            }
        }
    }
}