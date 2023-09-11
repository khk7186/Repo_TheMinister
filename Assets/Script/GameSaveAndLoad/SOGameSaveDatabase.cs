using SaveSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GameSaveDatabase", menuName = "ScriptableObjects/GameSaveDatabase", order = 8)]
[Serializable]
public class SOGameSaveDatabase : ScriptableObject
{
    public List<SOGameSave> gameSaves = new List<SOGameSave>();
    public SOGameSave currentGameSave = null;

    public List<SOGameSave> OutputGameSaves()
    {
        gameSaves.RemoveAll(x => x == null);
        return gameSaves;
    }
}
