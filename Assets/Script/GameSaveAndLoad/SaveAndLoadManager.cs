using PixelCrushers;
using PixelCrushers.QuestMachine.Wrappers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveSystem
{
    public class SaveAndLoadManager : MonoBehaviour
    {
        public SOGameSaveDatabase GameSaveDatabase;
        public GameSave gameSave;
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
        public QuestAIManager questionAIManager;
        public CharacterAwaitTributeManager characterAwaitTributeManager => CharacterAwaitTributeManager.Instance;

        public GameInitialization gameFiles;
        public LightController lightController = null;

        public GameEventManager gameEventManager = null;
        public SOMainGameEventDatabase gameEventDatabase = null;
        public List<SpawnAfterAwayGuest> gameGuests = new List<SpawnAfterAwayGuest>();
        public QuestDayCounterManager questDayCounterManager = null;
        private void Start()
        {
            GameSaveDatabase.FindAllSaves();
        }
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
        public void ReloadMainScene(GameSave save)
        {

            string path = $"SceneTransPrefab/{SceneType.MainGame}/{SceneType.MainGame}Animation";
            FindObjectOfType<SaveAndLoadManager>().gameSave = save;
            var canvas = Instantiate(Resources.Load<Canvas>("SceneTransPrefab/Canvas"));
            canvas.tag = "NeverTouch";
            SetGameLoadMode(gameSave);
            var animation = Instantiate(Resources.Load<SceneTransController>(path), canvas.transform);
            animation.transDelegate = ReloadGameSequence;
            animation.Close();
        }
        public void GameReset()
        {
            StartCoroutine(ResetScene());
        }
        public IEnumerator ResetScene()
        {
            GameSaveDatabase.currentGameSave = null;
            inGameCharacterStorage.Reset();
            pathManager.Reset();
            roitManager.Reset();
            itemInventory.Reset();
            gameEventManager.Reset();
            playerCharacterInventory.Clear();
            characterAwaitTributeManager.Reset();
            questionAIManager.Reset();
            map.ReloadPlayer();
            player = FindObjectOfType<Player>();
            gameEventManager.Reset();
            playerQuestJournal = player.GetComponent<QuestJournal>();
            playerQuestJournal.Reset();
            yield return null;
        }

        public IEnumerator ReloadGameSequence()
        {
            var animation = FindObjectOfType<SceneTransController>();
            yield return ResetScene();
            yield return new WaitUntil(() => animation.transition.GetCurrentAnimatorStateInfo(0).IsName("Wait"));
            FindObjectOfType<GameSaveUIController>()?.gameObject?.SetActive(false);
            FindObjectOfType<SaveAndLoadManager>().LoadGame(gameSave);

            var gameLostUI = FindObjectOfType<GameLostUI>();
            if (gameLostUI != null) Destroy(gameLostUI.gameObject);

            yield return new WaitForSeconds(2);
            animation.Open();
        }
        public void LoadGame(GameSave save)
        {
            //SceneTransController
            player = FindObjectOfType<Player>();
            playerQuestJournal = player.GetComponent<QuestJournal>();
            GameSaveDatabase.currentGameSave = save;
            LoadEvent.Load(this, GameSaveDatabase.currentGameSave);
            
        }
        public static void SetGameLoadMode(GameSave save)
        {
            var saveManager = FindObjectOfType<SaveAndLoadManager>();
            saveManager.gameSave = save;
            //FindObjectOfType<GameInitialization>().ReloadGame = true;
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
            GameSaveDatabase.gameSaves.Add(save);
            SerializeSave.SaveData(save);
        }

        public void DeleteGame(GameSave save)
        {
            string path = $"{Application.persistentDataPath}/Save";
            string filePath = $"{path}/{save.saveTime.Replace("/", string.Empty).Replace(":", string.Empty).Replace(" ", string.Empty)}.json";
            Debug.Log(filePath);
            if (System.IO.File.Exists(filePath))
            {
                Debug.Log("exist");
                System.IO.File.Delete(filePath);
            }
            GameSaveDatabase.gameSaves.Remove(save);
        }
    }
}