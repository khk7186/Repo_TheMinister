using Language.Lua;
using SaveSystem;
using Spine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SerializeSave
{
    public static bool SaveData(GameSave gameSave)
    {
        //string projectRootPath = Application.dataPath.Substring(0, Application.dataPath.LastIndexOf("/Assets/SaveData"));
        //QuickSaveWriter.Create(gameSave.saveName)
        //                                                .Write(gameSave.saveTime, gameSave)
        //                                                .Commit();
        string jsonData = JsonUtility.ToJson(gameSave);
        string path = $"{Application.persistentDataPath}/Save";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        Debug.Log(Application.persistentDataPath);
        string filePath = $"{path}/{gameSave.saveTime.Replace("/", string.Empty).Replace(":", string.Empty).Replace(" ", string.Empty)}.json";
        System.IO.File.WriteAllText(filePath, jsonData);
        return false;
    }
}
