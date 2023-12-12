using SaveSystem;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GameSaveDatabase", menuName = "ScriptableObjects/GameSaveDatabase", order = 8)]
[Serializable]
public class SOGameSaveDatabase : ScriptableObject
{
    public List<GameSave> gameSaves = new List<GameSave>();
    public GameSave currentGameSave = null;

    public List<GameSave> OutputGameSaves()
    {
        gameSaves.RemoveAll(x => x == null);
        return gameSaves;
    }
    public void FindAllSaves()
    {
        gameSaves.Clear();
        string path = $"{Application.persistentDataPath}/Save";
        string[] jsonFiles = System.IO.Directory.GetFiles(path, "*.json");
        foreach (string file in jsonFiles)
        {
            string jsonData = System.IO.File.ReadAllText(file);
            gameSaves.Add(DeserializeSave.LoadSave(jsonData));
        }
    }
}
