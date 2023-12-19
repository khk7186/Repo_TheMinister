using SaveSystem;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "GameSaveDatabase", menuName = "ScriptableObjects/GameSaveDatabase", order = 8)]
[Serializable]
public class SOGameSaveDatabase : ScriptableObject
{
    public List<GameSave> gameSaves = new List<GameSave>();
    public GameSave currentGameSave = null;

    public List<GameSave> OutputGameSaves()
    {
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
        var sortedList = gameSaves.OrderByDescending(item =>
        {
            DateTime parsedDate;
            if (DateTime.TryParse(item.saveTime, out parsedDate))
            {
                return parsedDate;
            }
            else
            {
                return DateTime.MinValue; // Puts invalid or unparsable dates at the end
            }
        }).ToList();
        gameSaves = sortedList;
    }
    public GameSave FindLatest()
    {
        if (gameSaves.Count < 0) return null;
        return gameSaves[0];
    }
}
